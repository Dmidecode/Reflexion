using System;
using System.Collections.Generic;
using System.Text;

namespace Attribut
{
  [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
  public class CodeReview : System.Attribute
  {
    string Name;
    public string Commentaire;

    public CodeReview(string name)
    {
      this.Name = name;

      // Default value.  
      Commentaire = "Needs Work";
    }

    public string GetName()
    {
      return Name;
    }
  }
}
