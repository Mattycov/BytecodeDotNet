using System.Collections;
using System.Collections.Generic;

namespace BytecodeDotNet.Java.ConstPool
{
  public class ConstantPool : IEnumerable<Constant>, IEnumerator<Constant>
  {

    private List<Constant> items = new List<Constant>();
    private int index;

    public int Count
    {
      get { return items.Count; }
    }

    public ConstantPool() {}

    public ConstantPool(Constant[] items)
    {
      this.items.AddRange(items);
    }

    public void Add(Constant item)
    {
      items.Add(item);
    }

    public void Remove(Constant item)
    {
      items.Remove(item);
    }

    #region IEnumerable and IEnumerator impl

    public IEnumerator<Constant> GetEnumerator()
    {
      index = 0;
      return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void Dispose() { }

    public bool MoveNext()
    {
      if (++index >= items.Count)
      {
        return false;
      }
      Current = items[index];
      return true;
    }

    public void Reset()
    {
      index = 0;
    }

    public Constant Current { get; private set; }

    object IEnumerator.Current
    {
      get { return Current; }
    }

    #endregion

    #region this[] impl

    public Constant this[int position]
    {
      get { return items[position - 1]; }
    }

    #endregion

  }
}
