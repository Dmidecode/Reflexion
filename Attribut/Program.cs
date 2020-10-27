using System;

namespace Attribut
{
  [CodeReview("Megumin")]
  public class ClasseNonStyleCop
  {

  }

  public class ClasseStyleCop
  {

  }

  // Class with multiple Author attributes.  
  [CodeReview("Megumin"), CodeReview("Shirai Kuroko")]
  public class ClasseTresSale
  {
  }

  class Program
  {
    static void DisplayCodeReview(System.Type t)
    {
      System.Console.WriteLine("CodeReview information for {0}", t);

      System.Attribute[] attributs = System.Attribute.GetCustomAttributes(t);

      foreach (System.Attribute attribut in attributs)
      {
        if (attribut is CodeReview)
        {
          CodeReview c = (CodeReview)attribut;
          System.Console.WriteLine($"\t{c.GetName()}, Commentaire {c.Commentaire}");
        }
      }
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      DisplayCodeReview(typeof(ClasseNonStyleCop));
      DisplayCodeReview(typeof(ClasseStyleCop));
      DisplayCodeReview(typeof(ClasseTresSale));

    }
  }
}
