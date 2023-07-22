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
        public static bool CheckRangeDataType(string Str, byte Range)
        {
            if (Str.Length > Range)
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
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_EtelatFerestande(string BarErsaliShahreMabda, string BarErsaliAnbarMabda,
           string BarErsaliNamFerestande, string BarErsaliFamilyFerestande, string BarErsaliMobileFerestande, int? BarErsaliCodeFerestande, bool moshtariSabet)
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
                if (!string.IsNullOrEmpty(BarErsaliCodeFerestande.ToString()))
                {
                    var result = Barbari_DAL.Customers.Select_Code((int)BarErsaliCodeFerestande);
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
        public static OperationResult BarErsali_Validation_EtelatBar(decimal BarErsaliPishKeraye, decimal BarErsaliPasKeraye, decimal? BarErsaliBime,
            decimal? BarErsaliAnbardari , decimal? BarErsaliShahri , decimal? BarErsaliBastebandi)
        {
            if (string.IsNullOrEmpty(BarErsaliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(BarErsaliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(BarErsaliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پیش کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پس کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliBime.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بیمه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliAnbardari.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل انبارداری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliShahri.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل شهری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(BarErsaliBastebandi.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بسته بندی فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(BarErsaliPishKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliPasKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliBime.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بیمه نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliAnbardari.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار داری نباید بیشتر از 12 حرف باشه"
                };
            }
            else if (CheckRangeDataType(BarErsaliShahri.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهری نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(BarErsaliBastebandi.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بسته بندی نباید بیشتر از 12 حرف باشه"
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
            string BarErsaliMobileRanande , decimal? BarErsaliKerayeRanande , int? BarErsaliCodeRanande)
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
            else if (string.IsNullOrEmpty(BarErsaliKerayeRanande.ToString()))
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
            else if (!CheckNumberFormat(BarErsaliKerayeRanande.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کرایه راننده فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(BarErsaliKerayeRanande.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کرایه راننده نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (!string.IsNullOrEmpty(BarErsaliCodeRanande.ToString()))
            {
                var result = Barbari_DAL.Ranande.Select_Code((int)BarErsaliCodeRanande);
                if (result.Success == true)
                {
                    if (result.Data.Any(p => p.RanandeIsDelete == true))
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "این راننده در جدول مشتری پاک شدند"
                        };
                    }
                    else if (result.Data.Count == 0)
                    {
                        return new OperationResult
                        {
                            Success = false,
                            Message = "این کد راننده در جدول مشتری ثبت نشده"
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
        public static OperationResult BarErsali_Validation_KalaDaryafti(string KalaDaryaftiNamKala, int KalaDaryaftiTedadKala,
            decimal KalaDaryaftiArzeshKala)
        {
            if (string.IsNullOrEmpty(KalaDaryaftiNamKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(KalaDaryaftiTedadKala.ToString()))
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
            else if (CheckRangeDataType(KalaDaryaftiTedadKala.ToString(), 9))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا نباید بیشتر از 9 عدد باشد"
                };
            }
            else if (CheckRangeDataType(KalaDaryaftiArzeshKala.ToString(), 15))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "ارزش کالا نباید بیشتر از 15 عدد باشد"
                };
            }
            else if (!CheckNumberFormat(KalaDaryaftiTedadKala.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "درون تعداد کالا فقط باید عدد وارد شود"
                };
            }
            else if (!CheckNumberFormat(KalaDaryaftiArzeshKala.ToString()))
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
        public static OperationResult BarTahvili_Validation_EtelatFerestande(BarTahvili_Tbl barTahvili)
        {
            if (string.IsNullOrEmpty(barTahvili.BarTahviliShahrFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliNamFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliFamilyFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliShahrFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliNamFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliFamilyFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(barTahvili.BarTahviliMobileFerestande))
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
        public static OperationResult BarTahvili_Validation_EtelatGerande(BarTahvili_Tbl barTahvili)
        {
            if (string.IsNullOrEmpty(barTahvili.BarTahviliShahrGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliNamGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliFamilyGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن گیرنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliShahrGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliNamGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliFamilyGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(barTahvili.BarTahviliMobileGerande))
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
        public static OperationResult barTahvili_Validation_EtelatBar(BarTahvili_Tbl barTahvili)
        {
            if (string.IsNullOrEmpty(barTahvili.BarTahviliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پیش کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پس کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliBime.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بیمه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliAnbardari.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل انبارداری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliShahri.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل شهری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barTahvili.BarTahviliBastebandi.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بسته بندی فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliPishKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliPasKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliBime.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بیمه نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliAnbardari.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار داری نباید بیشتر از 12 حرف باشه"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliShahri.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهری نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliBastebandi.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بسته بندی نباید بیشتر از 12 حرف باشه"
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
        public static OperationResult BarTahvili_Validation_EtelatRanande(BarTahvili_Tbl barTahvili)
        {
            if (string.IsNullOrEmpty(barTahvili.BarTahviliNamRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliFamilyRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "موبایل راننده راننده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliNamRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تام راننده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliFamilyRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckMobileFormat(barTahvili.BarTahviliMobileRanande))
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
        public static OperationResult BarTahvili_Validation_KalaTahvili(KalaTahvili_Tbl kalaTahvili)
        {
            if (string.IsNullOrEmpty(kalaTahvili.KalaTahviliNamKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(kalaTahvili.KalaTahviliTedadKala.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا را وارد کنید"
                };
            }
            else if (CheckRangeDataType(kalaTahvili.KalaTahviliNamKala, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(kalaTahvili.KalaTahviliTedadKala.ToString(), 9))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا نباید بیشتر از 9 عدد باشد"
                };
            }
            else if (!CheckNumberFormat(kalaTahvili.KalaTahviliTedadKala.ToString()))
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
        public static OperationResult BarErsali_Validation_TahvilMoshtari(BarTahvili_Tbl barTahvili)
        {
            if (string.IsNullOrEmpty(barTahvili.BarTahviliRaveshEhrazHoviat))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barTahvili.BarTahviliRaveshEhrazHoviatText))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت متن را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliRaveshEhrazHoviat, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "روش احراز هویت نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barTahvili.BarTahviliRaveshEhrazHoviatText, 50))
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
    }
    
}
