using System;
using System.Collections.Generic;
using System.IO;
using BytecodeDotNet.Exceptions;
using BytecodeDotNet.Java;
using BytecodeDotNet.Utilities;
using Version = BytecodeDotNet.Java.Version;

namespace BytecodeDotNet.Parser.Impl
{
  public class ClassParser : IParser<Class>
  {

    private readonly ByteOperator byteOperator;

    private Class javaClass;

    public ClassParser(Stream stream)
    {
      byteOperator = new ByteOperator(stream);
    }

    public ClassParser(byte[] bytes)
    {
      byteOperator = new ByteOperator(bytes);
    }

    public Class Parse()
    {
      if (Class.Magic != byteOperator.ReadUIntInverse())
      {
        throw new InvalidClassFileException();
      }

      javaClass = new Class();

      javaClass.Minor = (Version) Enum.ToObject(typeof(Version), byteOperator.ReadUShortInverse());
      javaClass.Major = (Version) Enum.ToObject(typeof(Version), byteOperator.ReadUShortInverse());
      javaClass.ConstantPool = new ConstantPoolParser(byteOperator).Parse();
      javaClass.AccessFlags = byteOperator.ReadUShortInverse();
      javaClass.NameIndex = byteOperator.ReadUShort();
      javaClass.SuperIndex = byteOperator.ReadUShort();

      ushort interfaceCount = byteOperator.ReadUShort();
      List<ushort> interfaceList = new List<ushort>();
      for (int i = 0; i < interfaceCount; i++)
      {
        interfaceList.Add(byteOperator.ReadUShort());
      }
      javaClass.InterfaceIndices = interfaceList;

      return javaClass;
    }
  }
}
