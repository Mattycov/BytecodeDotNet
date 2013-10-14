namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class FieldRefConstant : RefConstant
  {
    public FieldRefConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Fieldref; }
    }
  }
}
