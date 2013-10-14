using BytecodeDotNet.Exceptions;

namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public abstract class RefConstant: Constant
  {

    public ushort ClassIndex { get; set; }
    public ushort NameAndTypeIndex { get; set; }

    protected RefConstant(ConstantPool owner) : base(owner) {}
    
    public override string ToString()
    {
      ClassConstant classConstant = Owner[ClassIndex] as ClassConstant;
      NameAndTypeConstant nameAndTypeConstant = Owner[NameAndTypeIndex] as NameAndTypeConstant;
      if (classConstant == null || nameAndTypeConstant == null)
      {
        throw new ConstantPoolException("Invalid class or name and type index");
      }
      Utf8Constant classUtf8Constant = Owner[classConstant.NameIndex] as Utf8Constant;
      if (classUtf8Constant == null)
      {
        throw new ConstantPoolException("Invalid Utf8 index for class name");
      }
      Utf8Constant nameUtf8Constant = Owner[nameAndTypeConstant.NameIndex] as Utf8Constant;
      Utf8Constant descriptorUtf8Constant = Owner[nameAndTypeConstant.DescriptorIndex] as Utf8Constant;
      if (nameUtf8Constant == null || descriptorUtf8Constant == null)
      {
        throw new ConstantPoolException("Invalid name or descriptor Utf8 index");
      }
      return Tag.GetInfo() + ": " + classUtf8Constant.String + "#" + nameUtf8Constant.String + " " +
             descriptorUtf8Constant.String;
    }
  }
}
