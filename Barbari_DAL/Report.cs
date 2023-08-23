using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Report
    {
        public static OperationResult<List<BarErsali_Tbl>> Select_Ranande(int codeRanande, string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliCodeRanande == codeRanande &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
