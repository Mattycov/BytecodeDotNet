using System;
using System.IO;
using BytecodeDotNet.Java.ConstPool;
using Class = BytecodeDotNet.Java.Class;
using BytecodeDotNet.Parser.Impl;

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Testing actual class");
      using (FileStream stream = File.OpenRead(@"Resources\sq.class"))
      {
        ClassParser parser = new ClassParser(stream);
        Class clazz = parser.Parse();

        Console.WriteLine("\nVersion:");

        Console.WriteLine("\t" + clazz.Minor);
        Console.WriteLine("\t" + clazz.Major);

        Console.WriteLine("\nConstantPool:" + clazz.ConstantPool.Count);

        foreach (Constant constant in clazz.ConstantPool)
        {
          Console.WriteLine("\t" + constant.ToString());
        }

        Console.WriteLine(clazz.Name);
        Console.WriteLine(clazz.SuperName);

        Console.WriteLine();

        Console.WriteLine("Interfaces: " + clazz.Interfaces.Count);

        clazz.Interfaces.ForEach(Console.WriteLine);

        Console.Read();
      }
      
    }
  }
}
