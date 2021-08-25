using System;
using System.Net.Http;

namespace TestAPIviaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();


            Console.WriteLine("Making API call to Get All Categories");
            var response = client.GetAsync("http://localhost:18707/api/Category");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    Console.WriteLine(":: Data Recieved ::");
                    Console.WriteLine(data.Result);
                    Console.Write("Press Enter to Continue...");
                    Console.ReadLine();
                    
                }
            }

            Console.WriteLine();

            Console.WriteLine("Making API call to Get All Products");
            response = client.GetAsync("http://localhost:18707/api/Product");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    Console.WriteLine(":: Data Recieved ::");
                    Console.WriteLine(data.Result);
                    Console.Write("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("Making API call to Get Featured Products");
            response = client.GetAsync("http://localhost:18707/api/Product/Featured");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    Console.WriteLine(":: Data Recieved ::");
                    Console.WriteLine(data.Result);
                    Console.Write("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("Making API call to Get Products with Category Toys");
            response = client.GetAsync("http://localhost:18707/api/Product/Toys");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    Console.WriteLine(":: Data Recieved ::");
                    Console.WriteLine(data.Result);
                    Console.Write("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("Making API call to Test Sad Path");
            response = client.GetAsync("http://localhost:18707/api/Product/Cars");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    Console.WriteLine(":: Data Recieved ::");
                    Console.WriteLine(data.Result);
                    Console.Write("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }


        }
    }
}
