using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class SMS
    {
        public static OperationResult<SMS_Tbl> Select_Last()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.SMS_Tbls.OrderByDescending(p => p.SMSCode).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<SMS_Tbl>
                    {
                        Success = true,
                        Data = query
                    };
                }
                else
                {
                    return new OperationResult<SMS_Tbl>
                    {
                        Success = false,
                    };
                }
            }
            catch
            {
                return new OperationResult<SMS_Tbl>
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert(SMS_Tbl SMS)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq.SMS_Tbls.InsertOnSubmit(SMS);
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
    }
}
