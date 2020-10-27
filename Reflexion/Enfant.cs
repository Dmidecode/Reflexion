using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
  public class Enfant : Participant
  {
    private int nombrePrive;
    public string stringPublic;

    public static int TestStatic(string paramString, bool paramBool)
    {
      return 33;
    }

    public Enfant(int nb, string str) : base(nb, str)
    { }


    public Enfant() : base()
    { }

    public override string ToString()
    {
      Console.WriteLine("TOSTRING");
      return "RES";
    }

    public T Addition<T>(T num1, T num2)
    {
      dynamic a = num1;
      dynamic b = num2;
      return a + b;
    }
  }
}
