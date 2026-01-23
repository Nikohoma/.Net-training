// Attributes are used to change the metadata

namespace Attributes
{
    public class Calculator
    {
        // This attribute will generate a compiler warning
        [Obsolete("Use the NewAdd() Function")]
        public int OldAdd(int a, int b)
        {
            return a + b;
        }

        public int NewAdd(int a, int b)
        {
            return a + b;
        }
    }


}