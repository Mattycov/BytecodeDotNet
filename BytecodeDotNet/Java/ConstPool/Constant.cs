namespace BytecodeDotNet.Java.ConstPool
{
  public abstract class Constant
  {

    protected ConstantPool Owner { get; private set; }

    public abstract ConstantType Tag { get; }

    protected Constant(ConstantPool owner)
    {
      Owner = owner;
    }

    public new abstract string ToString();

  }
}
