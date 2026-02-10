
using System.Diagnostics;
using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;

using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            await SaveAsync();                // Task (no return)
            int total = await GetTotalAsync(); // Task<int> (returns value)
            Console.WriteLine(total);
        }

        static async Task SaveAsync()
        {
            await Task.Delay(3000); // pretend we saved to DB
            Console.WriteLine("Saved!");
        }

        static async Task<int> GetTotalAsync()
        {
            await Task.Delay(300); // pretend we calculated
            return 42;
        }
    }

}

namespace AsyncAwaitExample2
{
    using System.Net.Http;

    public class User
    {
        private async Task FetchJsonAsync()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos/1";
                string json = await GetAsync(url);
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task FetchGoogleAsync()
        {
            try
            {
                string url = "https://google.com/";
                string google = await GetAsync(url);
                Console.WriteLine(google);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task Main()
        {
            User u = new User();
            await u.FetchJsonAsync();
            await u.FetchGoogleAsync();
        }
    }
}



namespace AsyncExample3
{
    public class Calc
    {
        public async Task Method1()
        {
            await Task.Delay(5000);
            Console.WriteLine("Method 1 output");
        }
        public async Task Method2()
        {
            await Task.Delay(9000);
            Console.WriteLine("Method 2 output");
        }
    }
    public class User
    {
        public static async Task Main(string[] args)
        {
            Calc c = new Calc();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //await c.Method2();
            //await c.Method1();
            Task t1 = c.Method2();   // Off Loading method2  (started)
            Task t2 = c.Method1();    // Off Loading method2 (started)
            await t1;  // until the result of t1 is retreived, program cannot move forward
            await t2;
            sw.Stop();
            Console.WriteLine($"Total Time elapsed : {sw.ElapsedMilliseconds/1000} seconds");
        }
    }
}

namespace AsyncExample4
{
    public class Async
    {
        public async Task<int> Method1()
        {
            await Task.Delay(2000);
            return 1;
        }

        public async Task<int> Method2()
        {
            await Task.Delay(400);
            return 2;
        }

        public async Task<int> Method3()
        {
            await Task.Delay(700);
            return 3;
        }
    }

    public class User
    {
        public static async Task Main(string[] args)
        {
            Async a = new Async();
            Task<int> t1 = a.Method1();
            Task<int> t2 = a.Method2();
            Task<int> t3 = a.Method3();

            await Task.WhenAll(t1, t2, t3);   // wait till all of them executes
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);
            Console.WriteLine(t3.Result);

            var result = await Task.WhenAny(t1, t2, t3);   // wait till any one of the task executes
            Console.WriteLine(result.Result);

        }
    }
}


namespace AsyncExample5
{
    public class Cancellation
    {
        public static async Task Cancelling()
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(500);

            await LoopMethod();
        }

        public static async Task LoopMethod()
        {
            int count = 0;
            for(int i = 0; i < 10; i++)
            {
                count += 1;
                await Task.Delay(200);
            }
            Console.WriteLine($"Count : {count}");
        }
    }

    public class User
    {
        public static async Task Main()
        {
            await Cancellation.Cancelling();
        }
    }
}