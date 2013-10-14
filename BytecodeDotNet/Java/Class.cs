using System;
using System.Collections.Generic;
using BytecodeDotNet.Exceptions;
using BytecodeDotNet.Java.ConstPool;
using BytecodeDotNet.Java.ConstPool.Constants;

namespace BytecodeDotNet.Java
{
  public class Class
  {

    public const uint Magic = 0xCAFEBABE;

    public Version Minor { get; set; }
    public Version Major { get; set; }
    public ConstantPool ConstantPool { get; set; }
    public ushort AccessFlags { get; set; }
    internal ushort NameIndex { get; set; }
    public string Name
    {
      get
      {
        ClassConstant constant = ConstantPool[NameIndex] as ClassConstant;
        if (constant == null)
        {
          throw new ConstantPoolException("Invalid class info index");
        }
        return ((Utf8Constant)ConstantPool[constant.NameIndex]).String;
      }
      set
      {
        throw new NotImplementedException(); // TODO -  with class writing
      }
    }
    internal ushort SuperIndex { get; set; }
    public string SuperName
    {
      get
      {
        ClassConstant constant = ConstantPool[SuperIndex] as ClassConstant;
        if (constant == null)
        {
          throw new ConstantPoolException("Invalid super class info index");
        }
        return ((Utf8Constant) ConstantPool[constant.NameIndex]).String;
      }
      set { throw new NotImplementedException(); // TODO -  with class writing
      }
    }
    internal List<ushort> InterfaceIndices { get; set; } 
    public List<string> Interfaces
    {
      get
      {
        List<string> interfaceNames = new List<string>();
        foreach (ushort index in InterfaceIndices)
        {
          ClassConstant classConstant = ConstantPool[index] as ClassConstant;
          if (classConstant == null)
          {
            throw new ConstantPoolException("Invalid class info index");
          }
          interfaceNames.Add(((Utf8Constant) ConstantPool[classConstant.NameIndex]).String);
        }
        return interfaceNames;
      } 
      internal set
      {
        throw new NotImplementedException();
      }
    }

  }
}
