using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BytecodeDotNet.Java.ConstPool;

namespace BytecodeDotNet.Java.Attribute.Attributes
{
  public class ConstantValueAttribute : Attribute
  {

    public ushort ValueIndex { get; set; }

    public ConstantValueAttribute(ConstantPool pool) : base(pool) {}

    public override string ToString()
    {
      return string.Empty;
    }
  }
}
