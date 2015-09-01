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

            IEnumerable<DataRow> q1 = table.AsEnumerable()
                .Where<DataRow>(x => (int)x.ItemArray[0] > 3);

            IEnumerable<float> q2 = table.AsEnumerable()
                .Where<DataRow>(x => (int)x.ItemArray[0] > 4)
                .Select<DataRow, float>(x => (float)x.ItemArray[2]);

            IEnumerable<float> q3 = table.AsEnumerable()
                .OrderBy<DataRow, float>(x => (float)x.ItemArray[2])
                .Select<DataRow, float>(x => (float)x.ItemArray[2]);
                
        }
    }
}
