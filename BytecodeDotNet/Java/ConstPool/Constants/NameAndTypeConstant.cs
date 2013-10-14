using BytecodeDotNet.Exceptions;

namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public class NameAndTypeConstant : Constant
  {

    public ushort NameIndex { get; set; }
    public ushort DescriptorIndex { get; set; }

    public NameAndTypeConstant(ConstantPool owner) : base(owner) {}

    public override ConstantType Tag
    {
      get { return ConstantType.NameAndType; }
    }

    public override string ToString()
    {
      Utf8Constant nameUtf8Constant = Owner[NameIndex] as Utf8Constant;
      Utf8Constant descriptorUtf8Constant = Owner[DescriptorIndex] as Utf8Constant;
      if (nameUtf8Constant == null || descriptorUtf8Constant == null)
      {
        throw new ConstantPoolException("Invalid name or descriptor Utf8 index");
      }
      return Tag.GetInfo() + ": " + nameUtf8Constant.String + " " + descriptorUtf8Constant.String;
    }
  }
}
