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
            else if(result.Success == false && result.Data == null)
            {
                return new OperationResult<Company_Tbl>
                { 
                    Success = false,
                    Message = "لطفا اطلاعات شرکت را وارد کنید"
                };
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
            var result1 = Validation.Company_Validation(company);
            if (result1.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result1.Message
                };
            }
            else
            {
                var result = Barbari_DAL.Company.Insert(company);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true
                    };
                }
                else
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"

                    };
                }
            }
        }
    }
}
