namespace BytecodeDotNet.Java.ConstPool
{
  public enum ConstantType
  {

    Class = 7,
    Fieldref = 9,
    Methodref = 10,
    InterfaceMethodref = 11,
    String = 8,
    Integer = 3,
    Float = 4,
    Long = 5,
    Double = 6,
    NameAndType = 12,
    Utf8 = 1,
    MethodHandle = 15,
    MethodType = 16,
    InvokeDynamic = 18

  }

  public static class Extensions
  {
    
    public static string GetInfo(this ConstantType type)
    {
      switch (type)
      {
        case ConstantType.Class:
          return "Class_info";
        case ConstantType.Fieldref:
          return "Fieldref_info";
        case ConstantType.Methodref:
          return "Methodref_info";
        case ConstantType.InterfaceMethodref:
          return "InterfaceMethodref_info";
        case ConstantType.String:
          return "String_info";
        case ConstantType.Integer:
          return "Integer_info";
        case ConstantType.Float:
          return "Float_info";
        case ConstantType.Long:
          return "Long_info";
        case ConstantType.Double:
          return "Double_info";
        case ConstantType.NameAndType:
          return "NameAndType_info";
        case ConstantType.Utf8:
          return "Utf8_info";
        case ConstantType.MethodHandle:
          return "MethodHandle_info";
        case ConstantType.MethodType:
          return "MethodType_info";
        case ConstantType.InvokeDynamic:
          return "InvokeDynamic_info";
      }
      return "N/A";
    }


  }

}
