namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class StringConstant : Constant
  {

    public ushort StringIndex { get; set; }

    public StringConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.String; }
    }

    public override string ToString()
    {
      return Tag.GetInfo() + ": " + ((Utf8Constant) Owner[StringIndex]).String;
    }
  }
}
