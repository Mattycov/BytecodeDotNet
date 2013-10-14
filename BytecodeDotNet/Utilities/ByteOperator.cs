using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BytecodeDotNet.Java;

namespace BytecodeDotNet.Utilities
{
  public class ByteOperator
  {

    #region properties

    public byte[] Bytes { get; set; }
    public int Position { get; set; }
    public int Length
    {
      get { return Bytes.Length; }
    }
    public bool CanRead
    {
      get { return (Position + 1) < Length; }
    }
    public bool CanWrite
    {
      get { return false; } // TODO - Write a nice impl
    }

    #endregion

    #region ctor

    public ByteOperator(byte[] bytes)
    {
      Bytes = bytes;
    }

    public ByteOperator(Stream stream)
    {
      Bytes = new byte[stream.Length];
      stream.Read(Bytes, 0, Convert.ToInt32(stream.Length));
    }

    #endregion

    #region read impl

    public byte ReadByte()
    {
      Position++;
      return Bytes[Position - 1];
    }

    public ushort ReadUShortInverse()
    {
      Position += 2;
      return (ushort)BitConverter.ToInt16(new[]
        {
          Bytes[Position - 1], Bytes[Position - 2]
        }, 0);
    }

    public ushort ReadUShort()
    {
      Position += 2;
      return (ushort)BitConverter.ToInt16(new[]
        {
          Bytes[Position - 2], Bytes[Position - 1]
        }, 0);
    }

    public uint ReadUIntInverse()
    {
      Position += 4;
      return (uint)BitConverter.ToInt32(new[]
        {
          Bytes[Position - 1],  Bytes[Position - 2], Bytes[Position - 3], Bytes[Position - 4]
        }, 0);
    }

    public uint ReadUInt()
    {
      Position += 4;
      return (uint)BitConverter.ToInt32(new[]
        {
          Bytes[Position - 4],  Bytes[Position - 3], Bytes[Position - 2], Bytes[Position - 1]
        }, 0);
    }

    #endregion

    #region write impl

    // TODO - Figure out how to do this nicely

    #endregion

  }
}
