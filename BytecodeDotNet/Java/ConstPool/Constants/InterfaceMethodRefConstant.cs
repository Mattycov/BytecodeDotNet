namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class InterfaceMethodRefConstant : RefConstant
  {
    public InterfaceMethodRefConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.InterfaceMethodref; }
    }
  }
}
