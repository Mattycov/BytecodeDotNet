using System;
using System.Text;
using BytecodeDotNet.Java.ConstPool;
using BytecodeDotNet.Java.ConstPool.Constants;
using BytecodeDotNet.Utilities;

namespace BytecodeDotNet.Parser.Impl
{
  public class ConstantPoolParser : IParser<ConstantPool>
  {

    private readonly ByteOperator buffer;

    public ConstantPoolParser(ByteOperator buffer)
    {
      this.buffer = buffer;
    }

    public ConstantPool Parse()
    {
      ConstantPool pool = new ConstantPool();
      ushort poolCount = buffer.ReadUShortInverse();
      for (int i = 0; i < poolCount; i++)
      {
        ConstantType type = (ConstantType) Enum.ToObject(typeof (ConstantType), buffer.ReadByte());
        switch (type)
        {
          case ConstantType.Class:
            ClassConstant classConstant = new ClassConstant(pool);
            classConstant.NameIndex = buffer.ReadUShortInverse();
            pool.Add(classConstant);
            break;
          case ConstantType.Fieldref:
            pool.Add(new FieldRefConstant(pool)
              {
                ClassIndex = buffer.ReadUShortInverse(),
                NameAndTypeIndex = buffer.ReadUShortInverse()
              });
            break;
          case ConstantType.Methodref:
            pool.Add(new MethodRefConstant(pool)
              {
                ClassIndex = buffer.ReadUShortInverse(),
                NameAndTypeIndex = buffer.ReadUShortInverse()
              });
            break;
          case ConstantType.InterfaceMethodref:
            pool.Add(new InterfaceMethodRefConstant(pool)
              {
                ClassIndex = buffer.ReadUShortInverse(),
                NameAndTypeIndex = buffer.ReadUShortInverse()
              });
            break;
          case ConstantType.String:
            pool.Add(new StringConstant(pool) {StringIndex = buffer.ReadUShortInverse()});
            break;
          case ConstantType.Integer:
            pool.Add(new IntegerConstant(pool) {Bytes = buffer.ReadUIntInverse()});
            break;
          case ConstantType.Float:
            pool.Add(new FloatConstant(pool) {Bytes = buffer.ReadUIntInverse()});
            break;
          case ConstantType.Long:
            LongConstant longConstant = new LongConstant(pool)
              {
                HighBytes = buffer.ReadUIntInverse(),
                LowBytes = buffer.ReadUIntInverse()
              };
            pool.Add(longConstant);
            pool.Add(longConstant);
            i++;
            break;
          case ConstantType.Double:
            DoubleConstant doubleConstant = new DoubleConstant(pool)
              {
                HighBytes = buffer.ReadUIntInverse(),
                LowBytes = buffer.ReadUIntInverse()
              };
            pool.Add(doubleConstant);
            pool.Add(doubleConstant);
            i++;
            break;
          case ConstantType.NameAndType:
            pool.Add(new NameAndTypeConstant(pool)
              {
                NameIndex = buffer.ReadUShortInverse(),
                DescriptorIndex = buffer.ReadUShortInverse()
              });
            break;
          case ConstantType.Utf8:
            Utf8Constant utf8Constant = new Utf8Constant(pool);
            utf8Constant.Length = buffer.ReadUShortInverse();
            utf8Constant.Bytes = new byte[utf8Constant.Length];
            for (int j = 0; j < utf8Constant.Length; j++)
            {
              utf8Constant.Bytes[j] = buffer.ReadByte();
            }
            utf8Constant.String =  Encoding.UTF8.GetString(utf8Constant.Bytes);
            pool.Add(utf8Constant);
            break;
          case ConstantType.MethodHandle:
          case ConstantType.MethodType:
          case ConstantType.InvokeDynamic:
            break;
          default:
            Console.WriteLine(type);
            break;
        }
      }

      return pool;
    }
  }
}
