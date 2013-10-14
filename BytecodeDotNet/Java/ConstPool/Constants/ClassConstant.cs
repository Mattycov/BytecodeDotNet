namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class ClassConstant : Constant
  {

    public ushort NameIndex { get; set; }

    public ClassConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Class; }
    }

    public override string ToString()
    {
      return Tag.GetInfo() + ": " + ((Utf8Constant) Owner[NameIndex]).String;
    }
  }
}
