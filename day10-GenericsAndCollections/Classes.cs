using System.Collections;

namespace day10;


/// <summary>
/// String Extender with Palindrome Check Functionality.
/// </summary>
#region StringExtension - Check Palindrome
public static class StringExtension
{
    public static string CheckPalindrome(this string str)
    {
        str = str.ToLower();
        int l = 0; int h = str.Length-1;
        
        while (l < h)
        {
            if (str[l] == str[h])
            {
                l++; h--;
            }
            else {return "Not Palindrome";}
            
        }
        return "Palindrome";
    }
}

#endregion


#region  Garbage Collection with auto dispose

public class Garbage : IDisposable
{
    public ArrayList Names { get; set; }

    public Garbage()
    {
        Names = new ArrayList(); // ArrayList initialised, Memory allocated.

    }   
    public void Dispose() {Names = null;}

    // Finalizer method: Only Garbage Collector can call. Modify if want custom functionality(create backup,logs,etc.)
    ~Garbage()
    {
        Names = null;
    }
}

#endregion


#region Generics Customization

public class GenericsCustomization
{
    public GenericsCustomization()
    {
        
    }

    public void ExampleList()
    {
        List<string> names = new List<string>();
    }

}

#endregion

#region Custom Collection

public class CustomCollection : IList   // Official List Interface.
{
    private ArrayList _items = new ArrayList();

    public object? this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }

    public int Count => _items.Count;

    public bool IsFixedSize => _items.IsFixedSize;

    public bool IsReadOnly => _items.IsReadOnly;

    public bool IsSynchronized => _items.IsSynchronized;

    public object SyncRoot => _items.SyncRoot;

    public int Add(object? value) => _items.Add(value);

    public void Clear() => _items.Clear();

    public bool Contains(object? value) => _items.Contains(value);

    public void CopyTo(Array array, int index) => _items.CopyTo(array, index);

    public IEnumerator GetEnumerator() => _items.GetEnumerator();

    public int IndexOf(object? value) => _items.IndexOf(value);

    public string Find(object? value)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (object.Equals(value,_items[i])) { return "Value Found.";}
            
        }
        return "Value not found.";
    }

    public void Insert(int index, object? value) => _items.Insert(index, value);

    public void Remove(object? value) => _items.Remove(value);

    public void RemoveAt(int index) => _items.RemoveAt(index);

    
}







#endregion