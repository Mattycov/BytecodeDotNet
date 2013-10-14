using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytecodeDotNet.Parser
{
  public interface IParser<TType>
  {
    TType Parse();
  }
}
