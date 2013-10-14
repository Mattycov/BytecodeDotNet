namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class DoubleConstant : EightByteConstant
  {

    public DoubleConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Double; }
    }
  }
}
