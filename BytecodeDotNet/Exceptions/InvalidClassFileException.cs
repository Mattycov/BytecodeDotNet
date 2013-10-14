using System;

namespace BytecodeDotNet.Exceptions
{
  public class InvalidClassFileException : Exception
  {

    public InvalidClassFileException() : base("Not a valid Java class file") { }

  }
}
