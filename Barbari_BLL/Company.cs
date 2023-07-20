using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Company
    {
        public static OperationResult<Company_Tbl> Select()
        {
            var result = Barbari_DAL.Company.Select();
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<Company_Tbl>
                { 
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"

                };
            }
        }
        public static OperationResult Insert(Company_Tbl company)
        {

        }
    }
}
