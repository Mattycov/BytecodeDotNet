namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class MethodRefConstant : RefConstant
  {
    public MethodRefConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Methodref; }
    }
  }
}
