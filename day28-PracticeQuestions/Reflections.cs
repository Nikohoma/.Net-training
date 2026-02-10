using System.Reflection;

namespace ReflectionQues1
{
    public class DerivedSample
    {
        private void Hidden() { }
        protected void Shield() { }
        internal void Inside() { }
        public void Visible() { }

    }

    public class User
    {
        public static void Main(string[] args)
        {
            Type t = typeof(DerivedSample);
            var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            Console.WriteLine($"t : {t}");

            foreach (var m in methods)
            {
                Console.WriteLine(m.ReturnType.Name);
            }

            Console.WriteLine("Field Type: ");
            foreach (var m in t.GetFields())
            {
                Console.WriteLine(m.FieldType.Name + m.Name);
            }

            Console.WriteLine("Methods and Access Modifiers");
            foreach(var m in methods)
            {
                Console.WriteLine($"{m.Name} : {m}");
            }

        }

        private static string GetAccessModifier(MethodInfo m)
        {
            if (m.IsPublic) { return "Public"; }
            if (m.IsPrivate) { return "Private"; }
            else
            {
                return "Unknown";
            }

        }
    }
}

namespace ReflectionQues2
{
    public class Class1
    {
        public int Id { get; set; }
        private string _name { get;}

        private decimal _salary;

        public void Method1() { }
        private void Method2() { }
        protected void Method3() { }
        internal void Method4(string s) { Console.WriteLine($"{s} is printed."); }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Type t = typeof(Class1);

            var properties = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("\nProperties : ");
            foreach (var p in properties)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("\nMethods : ");
            var methods = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var m in methods)
            {
                Console.WriteLine(m.Name);
            }


            Class1 c = new Class1();
            var internalMethod = t.GetMethod("Method4", BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("\nInvoking Private method using Reflection :");
            internalMethod.Invoke(c, new object[] {"Reflection Message"} );


        }
    }
}