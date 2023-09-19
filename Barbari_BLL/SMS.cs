using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class SMS
    {
        public static OperationResult<SMS_Tbl> Select()
        {
            var result = Barbari_DAL.SMS.Select_Last();
            if (result.Success == true)
            {
                return result;
            }
            else if (result.Success == false && result.Data == null)
            {
                return new OperationResult<SMS_Tbl>
                {
                    Success = false,
                    Message = "لطفا اطلاعات ارسال پیامک را وارد کنید"
                };
            }
            else
            {
                return new OperationResult<SMS_Tbl>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"

                };
            }
        }
        public static OperationResult Insert(SMS_Tbl SMS)
        {
            var result1 = Validation.SMS_Validation(SMS);
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
                var result = Barbari_DAL.SMS.Insert(SMS);
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
