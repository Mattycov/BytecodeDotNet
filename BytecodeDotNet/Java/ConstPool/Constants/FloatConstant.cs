using System;

namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class FloatConstant : Constant
  {

    public uint Bytes { get; set; }

    public FloatConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Float; }
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }
  }
}
