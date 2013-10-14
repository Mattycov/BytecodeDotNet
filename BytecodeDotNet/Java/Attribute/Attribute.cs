using BytecodeDotNet.Java.ConstPool;

namespace BytecodeDotNet.Java.Attribute
{
  public abstract class Attribute
  {

    protected ConstantPool Pool { get; private set; }

    public ushort NameIndex { get; set; }
    public uint AttributeLength { get; private set; }

    protected Attribute(ConstantPool pool)
    {
      Pool = pool;
    }

    public new abstract string ToString();

  }
}
