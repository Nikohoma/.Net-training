using System;
using System.Collections.Generic;
using System.Text;

namespace day19
{
    public class Class1 {
        /// <summary>
        /// Ref Struct : Stack only, short lived
        /// </summary>
        public ref struct TempBuffer
        {
            public void Dispose() { }
        }

        public static void UseBuffer()
        {
            using var buff = new TempBuffer();   // Using keyword to free up the memory when the var has executed.
            buff.Dispose();
        }


    }
}


    


