using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance
{
    public class AttendanceClass
    {
        public List<int> attendance(List<int> scans)
        {
            HashSet<int> hs = new HashSet<int>(scans);   // preserves order
            return hs.ToList();

        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            AttendanceClass ac = new AttendanceClass();
            List<int> input = new List<int> { 10, 20, 10, 30, 20, 40 };
            foreach(var h in ac.attendance(input))
            {
                Console.Write(h + " ");
            }
        }
    }
}
