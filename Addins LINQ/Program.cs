using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace Addins_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn a = new DataColumn("id", typeof(int));
            a.Unique = true;
            table.Columns.Add(a);
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("price", typeof(float));

            Random r = new Random();
            for (int i = 1; i <= 10; i++)
            {
                table.Rows.Add(new object[]{i,i.ToString() + "name", r.Next(10000)/100f});
            }

            IEnumerable<DataRow> q1 = table.AsEnumerable()
                .Where(x => (int)x["id"] > 3);
            Console.WriteLine("q1:");
            foreach (var item in q1)
            {
                Console.WriteLine("id - {0},\t name - {1},\t price - {2}", item[0], item[1], item[2]);
            } Console.ReadKey();

            IEnumerable<float> q2 = table.AsEnumerable()
                .Where(x => (int)x["id"] > 4)
                .Select(x => (float)x["price"]);
            Console.WriteLine("q2:");
            foreach (var item in q2)
            {
                Console.WriteLine(item);
            } Console.ReadKey();

            IEnumerable<float> q3 = table.AsEnumerable()
                .Select(x => (float)x["price"])
                .OrderBy(x => x);
            Console.WriteLine("q3:");
            foreach (var item in q3)
            {
                Console.WriteLine(item);
            } Console.ReadKey();

            var q4 = table.AsEnumerable()
                .Select(x => new { IdField = x["id"], NameField = x["name"], PriceField = x["price"]});
            Console.WriteLine("q4:");
            foreach (var item in q4)
            {
                Console.WriteLine(item);
            } Console.ReadKey();


            IEnumerable<DataRow> q5 = table.AsEnumerable()
                .Where(x => (int)x["id"] > 2 && (int)x["id"] < 8)
                .OrderByDescending(x => (float)x["price"]);
            Console.WriteLine("q5:");
            foreach (var item in q5)
            {
                Console.WriteLine("id - {0},\t name - {1},\t price - {2}", item[0],item[1],item[2]);
            } Console.ReadKey();
        }
    }
}
