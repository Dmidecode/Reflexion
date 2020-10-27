using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
  public class Participant
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public Participant()
    {
      this.Id = -1;
      this.Name = string.Empty;
    }

    public Participant(int id, string name)
    {
      this.Id = id;
      this.Name = name;
    }

    public void PrintId()
    {
      Console.WriteLine($"Id: { this.Id }");
    }

    public void Print()
    {
      Console.WriteLine($"Name: { this.Name }");
    }
  }
}
