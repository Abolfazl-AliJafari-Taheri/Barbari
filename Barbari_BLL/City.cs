using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class City
    {
        public static OperationResult<List<City_Tbl>> Select(string search = "")
        {
            var result = Barbari_DAL.City.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<City_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult<List<string>> Select_Shahr()
        {
            var result = Barbari_DAL.City.Select_Shahr();
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<string>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult<List<string>> Select_Anbar(string Shahr)
        {
            var result = Barbari_DAL.City.Select_Anbar(Shahr);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<string>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(string shahr , string anbar)
        {
            var result = Barbari_DAL.City.Delete(shahr, anbar);
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
        public static OperationResult Insert(City_Tbl city)
        {
            var result1 = Validation.City_Validation(city);
            var result2 = Barbari_DAL.City.Select_Shahr_Anbar(city.CityShahr,city.CityAnbar);
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
            else if (result2.Data.Count != 0)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "این شهر و انبار قبلا وارد شده"
                };
            }
            else
            {
                var result = Barbari_DAL.City.Insert(city);
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
