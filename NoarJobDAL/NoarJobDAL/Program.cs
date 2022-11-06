using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDt(CompanyTypes.GetAllCompanyTypes());
        }
        public static void PrintDt(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

    }
}
