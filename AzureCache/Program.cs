using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCache
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            EntityService entityService = new EntityService();
            IEntity e1 = await entityService.GetMyEntityAsync(1);
            Console.WriteLine("name of id 1 is: " + e1.Name);
            Console.ReadLine();
            IEntity e2 = await entityService.GetMyEntityAsync(2);
            Console.WriteLine("name of id 2 is: " + e2.Name);
            Console.ReadLine();
            IEntity e1again = await entityService.GetMyEntityAsync(1);
            Console.WriteLine("name of id 1 is: " + e1again.Name);
            Console.ReadLine();
        }
    }
}
