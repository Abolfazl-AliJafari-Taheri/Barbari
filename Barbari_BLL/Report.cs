using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Report
    {
        public static OperationResult<List<BarErsali_Tbl>> Select_Ranande(int codeRanande, string azTarikh, string TaTarikh)
        {
            var result = Barbari_DAL.Report.Select_Ranande(codeRanande, azTarikh, TaTarikh);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                { 
                    Success = false 
                };
            }
        }
    }
}
