using System;
using System.Linq;
using System.Reflection;

namespace Reflexion
{
  class Program
  {
    static void Main(string[] args)
    {
      // CHOIX 1
      //Type t = Type.GetType("Reflexion.Participant");

      // CHOIX 2
      //Type t = p.GetType();

      // CHOIX 3
      Type t = typeof(Enfant);


      // Constructeur 1
      Participant p = new Enfant(42, "Dmidecode");

      // Constructeur 2
      var participantConstructeur = (Enfant)Activator.CreateInstance(typeof(Enfant));

      // Constructeur 3
      var getConstructeurParticipant = typeof(Enfant).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { }, null);
      var instance = (Enfant)getConstructeurParticipant.Invoke(null);

      //Console.WriteLine("--------- MEMBRES ------------");
      //MemberInfo[] members = t.GetMembers();
      //foreach (MemberInfo member in members)
      //{
      //  Console.WriteLine($"{member.Name}");
      //  Console.WriteLine($"\tDeclaringType: {member.DeclaringType}");
      //  Console.WriteLine($"\tReflectedType: {member.ReflectedType}");
      //  Console.WriteLine($"\tMemberType: {member.MemberType}");
      //}

      Console.WriteLine("--------- PROPRIETES ------------");
      PropertyInfo[] properties = t.GetProperties();
      foreach (PropertyInfo property in properties)
      {
        Console.WriteLine($"{property.Name}");
        Console.WriteLine($"\tDeclaringType: {property.DeclaringType}");
        Console.WriteLine($"\tReflectedType: {property.ReflectedType}");
        Console.WriteLine($"\tMemberType: {property.MemberType}");
        Console.WriteLine($"\tPropertyType: {property.PropertyType}");
      }

      Console.WriteLine("--------- FIELDS ------------");
      FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                         BindingFlags.Instance);
      foreach (FieldInfo field in fields)
      {
        Console.WriteLine($"{field.Name}");
        Console.WriteLine($"\tDeclaringType: {field.DeclaringType}");
        Console.WriteLine($"\tReflectedType: {field.ReflectedType}");
        Console.WriteLine($"\tMemberType: {field.MemberType}");
        Console.WriteLine($"\tFieldType: {field.FieldType}");
        Console.WriteLine($"\tIsPublic: {field.IsPublic}");
        Console.WriteLine($"\tIsPrivate: {field.IsPrivate}");
      }

      Console.WriteLine();
      Console.WriteLine("--------- METHODES ------------");
      MethodInfo[] methods = t.GetMethods();
      foreach (MethodInfo method in methods)
      {
        Console.WriteLine($"{method.Name}");
        Console.WriteLine($"\tDeclaringType: {method.DeclaringType}");
        Console.WriteLine($"\tReflectedType: {method.ReflectedType}");
        Console.WriteLine($"\tMemberType: {method.MemberType}");
        Console.WriteLine($"\tReturnType: {method.ReturnType}");
        Console.WriteLine($"\tIsGenericMethod: {method.IsGenericMethod}");
        Console.WriteLine($"\tIsStatic: {method.IsStatic}");
        Console.WriteLine($"\tIsVirtual: {method.IsVirtual}");
        foreach (ParameterInfo info in method.GetParameters())
        {
          Console.WriteLine($"\t\tParamètre {info.Name}");
          Console.WriteLine($"\t\tIsOptional:{info.IsOptional}");
          Console.WriteLine($"\t\tParameterType:{info.ParameterType}");
          Console.WriteLine($"\t\tPosition:{info.Position}");
          Console.WriteLine();
        }

        if (string.Compare("ToString", method.Name) == 0)
        {
          method.Invoke(instance, null);
        }
      }

      // STATIC
      //var macroClasses = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace.Contains("StaticReflexion"));
      var macroClasses = Assembly.Load("StaticReflexion").GetTypes().Where(x => x.Namespace.Contains("StaticReflexion"));

      foreach (var tempClass in macroClasses)
      {
        tempClass.GetMethod("Display", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
      }
    }
  }
}
