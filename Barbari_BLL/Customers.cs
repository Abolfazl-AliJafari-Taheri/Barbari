using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Customers
    {
        public static OperationResult<List<Customers_Tbl>> Select(string search = "")
        {
            var result = Barbari_DAL.Customers.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<Customers_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(string code)
        {
            var result = Barbari_DAL.Customers.Delete(code);
            if (result.Success == true)
            {
                return new OperationResult
                {
                    Success = true,
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
        public static OperationResult Delete_Back(string code)
        {
            var result = Barbari_DAL.Customers.Delete_Back(code);
            if (result.Success == true)
            {
                return new OperationResult
                {
                    Success = true,
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
        public static OperationResult Insert(Customers_Tbl customers)
        {
            var result1 = Validation.Customers_Validation(customers);
            var result2 = Barbari_DAL.Customers.Select_Code(customers.CustomersCode);
            if (result1.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result1.Message
                };
            }
            else if (result2.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
            else if (result2.Data.Any(p => p.CustomersIsDelete == true))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "این نام کاربری قبلا پاک شده میخوای برات برگردونم ؟"
                };

            }
            else if (result2.Data.Count != 0)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد مشتری تکراری است"
                };
            }
            else
            {
                var result = Barbari_DAL.Customers.Insert(customers);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true,
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
        public static OperationResult Update(Customers_Tbl customers)
        {
            var result1 = Validation.Customers_Validation(customers);
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
                var result = Barbari_DAL.Customers.Update(customers);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true,
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
