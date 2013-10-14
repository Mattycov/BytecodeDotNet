namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class IntegerConstant : Constant
  {

    public uint Bytes { get; set; }

    public IntegerConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Integer; }
    }

    public override string ToString()
    {
      return Tag.GetInfo() + ": " + Bytes;
    }
  }
}
