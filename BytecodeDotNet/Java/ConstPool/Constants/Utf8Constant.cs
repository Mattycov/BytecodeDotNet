namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class Utf8Constant : Constant
  {

    public ushort Length { get; set; }
    public byte[] Bytes { get; set; }
    public string String { get; set; }

    public Utf8Constant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Utf8; }
    }

    public override string ToString()
    {
      return Tag.GetInfo() + ": " + String;
    }
  }
}
