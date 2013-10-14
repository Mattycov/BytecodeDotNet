namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class LongConstant : EightByteConstant
  {
    
    public LongConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.Long; }
    }

    public override string ToString()
    {
      return "Long_info: " + Value;
    }
  }
}
