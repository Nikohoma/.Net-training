using System.Collections;

public class collections
{   

    #region Generic List
    public void sample()
    {
        List<string> myList = new List<string>();
        myList.Add("A");
        myList.Add("B");
        myList.Add("C");
        myList.Add("Z");
        myList.Add("F");

        myList.Sort();

        foreach(var v in myList)
        {
            Console.Write(v + " ");
        }

        List<DateTime> List1 = new List<DateTime>();

    }
    #endregion
}