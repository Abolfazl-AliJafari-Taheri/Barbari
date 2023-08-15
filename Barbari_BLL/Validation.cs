using Barbari_DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Validation
    {
        public static bool CheckMobileFormat(string Str)
        {
            if (Str.Length != 11 || !Str.StartsWith("09") || !CheckNumberFormat(Str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckTelephonSabetFormat(string Str)
        {
            if (Str.Length != 11 || !CheckNumberFormat(Str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckRangeDataType(string Str, byte Range)
        {
            if (Str.Length >= Range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckNumberFormat(string Str)
        {
            bool result = long.TryParse(Str, out long a);
            return result;
        }
        public static bool CheckStringFormat(string input)
        {
            foreach (char c in input)
            {
                if (!IsEnglishLetter(c))
                    return true;
            }
            return false;
        }

        private static bool IsEnglishLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }
        public static OperationResult Users_Validation(Users_Tbl user)
        {
            if (string.IsNullOrEmpty(user.UsersFirstName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(user.UsersLastName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(user.UsersUserName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کاربری را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(user.UsersPassWord))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "رمز عبور را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(user.UsersMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن را وارد کنید"
                };
            }
            else if (CheckRangeDataType(user.UsersFirstName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(user.UsersLastName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(user.UsersUserName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کاربری نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(user.UsersPassWord, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "رمز عبور نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckStringFormat(user.UsersUserName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل نام کاربری فقط باید حروف انگلیسی و عدد باشد"
                };
            }
            else if (CheckStringFormat(user.UsersPassWord))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل رمز عبور فقط باید حروف انگلیسی و عدد باشد"
                };
            }
            else if (CheckMobileFormat(user.UsersMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (!string.IsNullOrEmpty(user.UsersRoles))
            {
                var result = Barbari_DAL.Roles.Select_NamRoles(user.UsersRoles);
                if (result.Success == true)
                {
                    if (result.Data.Count == 0)
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "این نقش در جدول نقش ها ثبت نشده"
                        };
                    }
                    else
                    {
                        return new OperationResult
                        {
                            Success = true,
                        };
                    }
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
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult Customers_Validation(Customers_Tbl customer)
        {
            if (string.IsNullOrEmpty(customer.CustomersFirstName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(customer.CustomersLastName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی را وارد کنید"
                };
            }
            //else if (string.IsNullOrEmpty(customer.CustomersCode))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "کد مشتری را وارد کنید"
            //    };
            //}
            else if (string.IsNullOrEmpty(customer.CustomersCity))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(customer.CustomersMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن را وارد کنید"
                };
            }
            else if (CheckRangeDataType(customer.CustomersFirstName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(customer.CustomersLastName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            //else if (CheckRangeDataType(customer.CustomersCode, 10))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "کد مشتری نباید بیشتر از 10 رقم باشه"
            //    };
            //}
            else if (CheckRangeDataType(customer.CustomersCity, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام شهر نباید بیشتر از 50 حرف باشد"
                };
            }
            //else if (!CheckNumberFormat(customer.CustomersCode))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "داخل کد مشتری فقط باید عدد وارد کرد"
            //    };
            //}
            else if (CheckMobileFormat(customer.CustomersMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult Ranande_Validation(Ranande_Tbl Ranande)
        {
            if (string.IsNullOrEmpty(Ranande.RanandeFirstName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(Ranande.RanandeLastName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی را وارد کنید"
                };
            }
            //else if (string.IsNullOrEmpty(Ranande.RanandeCodeRanande))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "کد راننده را وارد کنید"
            //    };
            //}
            else if (string.IsNullOrEmpty(Ranande.RanandeMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن را وارد کنید"
                };
            }
            else if (CheckRangeDataType(Ranande.RanandeFirstName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(Ranande.RanandeLastName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            //else if (CheckRangeDataType(Ranande.RanandeCodeRanande, 10))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "کد راننده نباید بیشتر از 10 رقم باشه"
            //    };
            //}
            //else if (!CheckNumberFormat(Ranande.RanandeCodeRanande))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "داخل کد راننده فقط باید عدد وارد کرد"
            //    };
            //}
            else if (CheckMobileFormat(Ranande.RanandeMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult City_Validation(City_Tbl city)
        {
            if (string.IsNullOrEmpty(city.CityShahr))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(city.CityAnbar))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(city.CityMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "موبایل را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(city.CityAdres))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "ادرس را وارد کنید"
                };
            }
            else if (CheckRangeDataType(city.CityShahr, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(city.CityAnbar, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckTelephonSabetFormat(city.CityMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_EtelatFerestande(string BarErsaliShahreMabda, string BarErsaliAnbarMabda,
           string BarErsaliNamFerestande, string BarErsaliFamilyFerestande, string BarErsaliMobileFerestande, string BarErsaliCodeFerestande, bool moshtariSabet)
        {
            if (string.IsNullOrEmpty(BarErsaliShahreMabda))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliAnbarMabda))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مبدا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliNamFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliFamilyFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarErsaliShahreMabda, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliAnbarMabda, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliNamFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliFamilyFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(BarErsaliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (moshtariSabet == true)
            {
                if (!string.IsNullOrEmpty(BarErsaliCodeFerestande))
                {
                    if (!CheckNumberFormat(BarErsaliCodeFerestande))
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "داخل کد مشتری فقط میشه عدد وارد کرد"
                        };
                    }
                    var result = Barbari_DAL.Customers.Select_Code(int.Parse(BarErsaliCodeFerestande));
                    if (result.Success == true)
                    {
                        if (result.Data.Any(p => p.CustomersIsDelete == true))
                        {
                            return new OperationResult
                            {
                                Success = false,
                                Message = "این مشتری در جدول مشتری پاک شدند"
                            };
                        }
                        else if (result.Data.Count == 0)
                        {
                            return new OperationResult
                            {
                                Success = false,
                                Message = "این کد مشتری در جدول مشتری ثبت نشده"
                            };
                        }
                        else
                        {
                            return new OperationResult
                            {
                                Success = true,
                            };
                        }
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
                else
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "کد مشتری ثابت را وارد کنید"
                    };
                }
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_EtelatGerande(string BarErsaliShahreMaghsad1, string BarErsaliAnbarMaghsad1,
           string BarErsaliNamGerande,string BarErsaliFamilyGerande,string BarErsaliMobileGerande,string BarErsaliShahreMaghsad2,
           string BarErsaliAnbarMaghsad2, bool maghsadNahayi)
        {
            if (string.IsNullOrEmpty(BarErsaliShahreMaghsad1))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliAnbarMaghsad1))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliNamGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliFamilyGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarErsaliShahreMaghsad1, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliAnbarMaghsad1, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliNamGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliFamilyGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(BarErsaliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (maghsadNahayi == true)
            {
                if (string.IsNullOrEmpty(BarErsaliShahreMaghsad2))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "شهر مقصد نهایی را وارد کنید"
                    };
                }
                else if (string.IsNullOrEmpty(BarErsaliAnbarMaghsad2))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "انبار مقصد نهایی را وارد کنید"
                    };
                }
                else if (CheckRangeDataType(BarErsaliShahreMaghsad2, 50))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "شهر مقصد نهایی نباید بیشتر از 50 حرف باشد"
                    };
                }
                else if (CheckRangeDataType(BarErsaliAnbarMaghsad2, 50))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "انبار مقصد نهایی نباید بیشتر از 50 حرف باشد"
                    };
                }
                else
                {
                    return new OperationResult
                    {
                        Success = true,
                    };
                }
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_EtelatBar(string BarErsaliPishKeraye, string BarErsaliPasKeraye, string BarErsaliBime,
            string BarErsaliAnbardari , string BarErsaliShahri , string BarErsaliBastebandi)
        {
            if (string.IsNullOrEmpty(BarErsaliPishKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliPasKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه را وارد کنید"
                };
            }
            else if (BarErsaliPishKeraye == "0" && BarErsaliPasKeraye == "0")
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه یا پس کرایه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(BarErsaliPishKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پیش کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliPasKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پس کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliBime))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بیمه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliAnbardari))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل انبارداری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliShahri))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل شهری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliBastebandi))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بسته بندی فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(BarErsaliPishKeraye, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliPasKeraye, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliBime, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بیمه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliAnbardari, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار داری نباید بیشتر از 12 عدد باشه"
                };
            }
            else if (CheckRangeDataType(BarErsaliShahri, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهری نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliBastebandi, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بسته بندی نباید بیشتر از 12 عدد باشه"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_TahvilRanande(string BarErsaliNamRanande, string BarErsaliFamilyRanande,
            string BarErsaliMobileRanande , string BarErsaliKerayeRanande , string BarErsaliCodeRanande)
        {
            if (string.IsNullOrEmpty(BarErsaliNamRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliFamilyRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "موبایل راننده راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliKerayeRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کرایه راننده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarErsaliNamRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تام راننده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliFamilyRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckMobileFormat(BarErsaliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (!CheckNumberFormat(BarErsaliKerayeRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کرایه راننده فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(BarErsaliKerayeRanande, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کرایه راننده نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (!string.IsNullOrEmpty(BarErsaliCodeRanande))
            {
                if (!CheckNumberFormat(BarErsaliCodeRanande))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "داخل کد راننده فقط میشه عدد وارد کرد"
                    };
                }
                var result = Barbari_DAL.Ranande.Select_Code(int.Parse(BarErsaliCodeRanande));
                if (result.Success == true)
                {
                    if (result.Data.Any(p => p.RanandeIsDelete == true))
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "این راننده در جدول راننده پاک شدند"
                        };
                    }
                    else if (result.Data.Count == 0)
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "این کد راننده در جدول راننده ثبت نشده"
                        };
                    }
                    else
                    {
                        return new OperationResult
                        {
                            Success = true,
                        };
                    }
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
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_KalaDaryafti(string KalaDaryaftiNamKala, string KalaDaryaftiTedadKala,
            string KalaDaryaftiArzeshKala)
        {
            if (string.IsNullOrEmpty(KalaDaryaftiNamKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(KalaDaryaftiTedadKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا را وارد کنید"
                };
            }
            else if (CheckRangeDataType(KalaDaryaftiNamKala, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(KalaDaryaftiTedadKala, 9))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا نباید بیشتر از 9 عدد باشد"
                };
            }
            else if (CheckRangeDataType(KalaDaryaftiArzeshKala, 15))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "ارزش کالا نباید بیشتر از 15 عدد باشد"
                };
            }
            else if (!CheckNumberFormat(KalaDaryaftiTedadKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "درون تعداد کالا فقط باید عدد وارد شود"
                };
            }
            else if (!CheckNumberFormat(KalaDaryaftiArzeshKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "درون ارزش کالا فقط باید عدد وارد شود"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarTahvili_Validation_EtelatFerestande(string BarTahviliShahrFerestande,
            string BarTahviliNamFerestande, string BarTahviliFamilyFerestande, string BarTahviliMobileFerestande)
        {
            if (string.IsNullOrEmpty(BarTahviliShahrFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliNamFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliFamilyFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarTahviliShahrFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliNamFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliFamilyFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(BarTahviliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarTahvili_Validation_EtelatGerande(string BarTahviliShahrGerande ,
            string BarTahviliNamGerande, string BarTahviliFamilyGerande, string BarTahviliMobileGerande)
        {
            if (string.IsNullOrEmpty(BarTahviliShahrGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliNamGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliFamilyGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن گیرنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarTahviliShahrGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliNamGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliFamilyGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(BarTahviliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult barTahvili_Validation_EtelatBar(string CodeBarname, string BarTahviliPishKeraye, string BarTahviliPasKeraye
            , string BarTahviliBime, string BarTahviliAnbardari, string BarTahviliShahri, string BarTahviliBastebandi)
        {
            if (string.IsNullOrEmpty(CodeBarname))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد بارنامه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(CodeBarname))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کد بارنامه فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(CodeBarname , 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد بارنامه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (BarTahviliPishKeraye == "0" && BarTahviliPasKeraye == "0")
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه یا پس کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliPishKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliPasKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(BarTahviliPishKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پیش کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarTahviliPasKeraye))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پس کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarTahviliBime))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بیمه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarTahviliAnbardari))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل انبارداری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarTahviliShahri))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل شهری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarTahviliBastebandi))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بسته بندی فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(BarTahviliPishKeraye, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliPasKeraye, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliBime, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بیمه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliAnbardari, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار داری نباید بیشتر از 12 عدد باشه"
                };
            }
            else if (CheckRangeDataType(BarTahviliShahri, 12))
            {   
                return new OperationResult
                {
                    Success = false,
                    Message = "شهری نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliBastebandi, 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بسته بندی نباید بیشتر از 12 عدد باشه"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarTahvili_Validation_EtelatRanande(string BarTahviliNamRanande ,
            string BarTahviliFamilyRanande, string BarTahviliMobileRanande)
        {
            if (string.IsNullOrEmpty(BarTahviliNamRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliFamilyRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "موبایل راننده راننده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarTahviliNamRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تام راننده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliFamilyRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckMobileFormat(BarTahviliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarTahvili_Validation_KalaTahvili(string KalaTahviliNamKala, string KalaTahviliTedadKala)
        {
            if (string.IsNullOrEmpty(KalaTahviliNamKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(KalaTahviliTedadKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا را وارد کنید"
                };
            }
            else if (CheckRangeDataType(KalaTahviliNamKala, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(KalaTahviliTedadKala, 9))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا نباید بیشتر از 9 عدد باشد"
                };
            }
            else if (!CheckNumberFormat(KalaTahviliTedadKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "درون تعداد کالا فقط باید عدد وارد شود"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarTahvili_Validation_TahvilMoshtari(string BarTahviliRaveshEhrazHoviat, string BarTahviliRaveshEhrazHoviatText)
        {
            if (string.IsNullOrEmpty(BarTahviliRaveshEhrazHoviat))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarTahviliRaveshEhrazHoviatText))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت متن را وارد کنید"
                };
            }
            else if (CheckRangeDataType(BarTahviliRaveshEhrazHoviat, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarTahviliRaveshEhrazHoviatText, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت متن نباید بیشتر از 50 حرف باشد"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true
                };
            }
        }
        public static OperationResult Company_Validation(Company_Tbl company)
        {
            if (string.IsNullOrEmpty(company.CompanyName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام شرکت را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(company.CompanyCity))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام شهر را وارد کنید"
                };
            }
            else if (CheckRangeDataType(company.CompanyName, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام شرکت نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(company.CompanyCity, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر نباید بیشتر از 50 حرف باشد"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true
                };
            }
        }
        public static OperationResult Roles_Validation(Roles_Tbl roles)
        {
            if (string.IsNullOrEmpty(roles.RolesNamRole))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام نقش را وارد کنید"
                };
            }
            else if (CheckRangeDataType(roles.RolesNamRole, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام نقش نباید بیشتر از 50 حرف باشد"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = true
                };
            }
        }
    }
    
}
