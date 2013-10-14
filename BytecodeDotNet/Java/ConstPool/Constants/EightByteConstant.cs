using System;

namespace BytecodeDotNet.Java.ConstPool.Constants
{
  public abstract class EightByteConstant : Constant
  {

    public uint LowBytes { get; set; }
    public uint HighBytes { get; set; }
    public double Value
    {
      get
      {
        long valueBytes = (HighBytes << 32) + LowBytes;

        double sLD = (valueBytes >> 63) == 0 ? 1 : -1;
        double eLD = (valueBytes >> 52) & 0x7FF;
        double mLD = eLD == 0
                       ? (valueBytes & 0xFFFFFFFFFFFFF) << 1
                       : (valueBytes & 0xFFFFFFFFFFFFF) | 0x10000000000000;

        return sLD * mLD * (Math.Pow(2, (eLD - 1075)));
      }
    }

    protected EightByteConstant(ConstantPool owner) : base(owner) {}

    public override string ToString()
    {
      return Tag.GetInfo() + ": " + Value;
    }

  }
}
