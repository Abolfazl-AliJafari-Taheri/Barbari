using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class BarTahvili
    {
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<List<BarTahvili_Tbl>> Select(string search)
        {
            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname.ToString().Contains(search)).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch 
            {
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false
                };
            }
            

        }

    }
}
