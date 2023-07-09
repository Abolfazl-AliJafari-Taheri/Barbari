using Barbari_DAL;
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
                if (!(char.IsLetter(c) || char.IsDigit(c)))
                    return true;
            }
            return false;
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
            else if (string.IsNullOrEmpty(customer.CustomersCode))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد مشتری را وارد کنید"
                };
            }
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
            else if (CheckRangeDataType(customer.CustomersCode, 10))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد مشتری نباید بیشتر از 10 رقم باشه"
                };
            }
            else if (CheckRangeDataType(customer.CustomersCity, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام شهر نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (!CheckNumberFormat(customer.CustomersCode))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کد مشتری فقط باید عدد وارد کرد"
                };
            }
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
            else if (string.IsNullOrEmpty(Ranande.RanandeCodeRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد راننده را وارد کنید"
                };
            }
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
            else if (CheckRangeDataType(Ranande.RanandeCodeRanande, 10))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد راننده نباید بیشتر از 10 رقم باشه"
                };
            }
            else if (!CheckNumberFormat(Ranande.RanandeCodeRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کد راننده فقط باید عدد وارد کرد"
                };
            }
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
        public static OperationResult BarErsali_Validation_EtelatFerestande(BarErsali_Tbl barErsali , bool moshtariSabet)
        {
            if (string.IsNullOrEmpty(barErsali.BarErsaliShahreMabda))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliAnbarMabda))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مبدا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliNamFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliFamilyFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliShahreMabda, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliAnbarMabda, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مبدا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliNamFerestande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام فرستنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliFamilyFerestande , 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی فرستنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(barErsali.BarErsaliMobileFerestande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (moshtariSabet == true)
            {
                if (!string.IsNullOrEmpty(barErsali.BarErsaliCodeFerestande))
                {
                    var result = Barbari_DAL.Customers.Select_Code(barErsali.BarErsaliCodeFerestande);
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
        public static OperationResult BarErsali_Validation_EtelatGerande(BarErsali_Tbl barErsali , bool maghsadNahayi)
        {
            if (string.IsNullOrEmpty(barErsali.BarErsaliShahreMaghsad1))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliAnbarMaghsad1))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مقصد را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliNamGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliFamilyGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن فرستنده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliShahreMaghsad1, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهر مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliAnbarMaghsad1, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار مقصد نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliNamGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام گیرنده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliFamilyGerande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی گیرنده نباید بیشتر از 50 حرف باشه"
                };
            }
            else if (CheckMobileFormat(barErsali.BarErsaliMobileGerande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (maghsadNahayi == true)
            {
                if (string.IsNullOrEmpty(barErsali.BarErsaliShahreMaghsad2))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "شهر مقصد نهایی را وارد کنید"
                    };
                }
                else if (string.IsNullOrEmpty(barErsali.BarErsaliAnbarMaghsad2))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "انبار مقصد نهایی را وارد کنید"
                    };
                }
                else if (CheckRangeDataType(barErsali.BarErsaliShahreMaghsad2, 50))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "شهر مقصد نهایی نباید بیشتر از 50 حرف باشد"
                    };
                }
                else if (CheckRangeDataType(barErsali.BarErsaliAnbarMaghsad2, 50))
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
        public static OperationResult BarErsali_Validation_EtelatBar(BarErsali_Tbl barErsali)
        {
            if (string.IsNullOrEmpty(barErsali.BarErsaliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه را وارد کنید"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliPishKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پیش کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliPasKeraye.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل پس کرایه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliBime.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بیمه فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliAnbardari.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل انبارداری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliShahri.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل شهری فقط میشه عدد وارد کرد"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliBastebandi.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل بسته بندی فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliPishKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پیش کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliPasKeraye.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "پس کرایه نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliBime.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "بیمه نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliAnbardari.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "انبار داری نباید بیشتر از 12 حرف باشه"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliShahri.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شهری نباید بیشتر از 12 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliBastebandi.ToString(), 12))
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
        public static OperationResult BarErsali_Validation_TahvilRanande(BarErsali_Tbl barErsali)
        {
            if (string.IsNullOrEmpty(barErsali.BarErsaliNamRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliFamilyRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "موبایل راننده راننده را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(barErsali.BarErsaliKerayeRanande.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کرایه راننده را وارد کنید"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliNamRanande,50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تام راننده نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliFamilyRanande, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckMobileFormat(barErsali.BarErsaliMobileRanande))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل را درست وارد کنید"
                };
            }
            else if (!CheckNumberFormat(barErsali.BarErsaliKerayeRanande.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "داخل کرایه راننده فقط میشه عدد وارد کرد"
                };
            }
            else if (CheckRangeDataType(barErsali.BarErsaliKerayeRanande.ToString(), 12))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کرایه راننده نباید بیشتر از 12 عدد باشد"
                };
            }
            else if (!string.IsNullOrEmpty(barErsali.BarErsaliCodeRanande))
            {
                if (CheckRangeDataType(barErsali.BarErsaliCodeRanande,10))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "کد راننده نباید بیشتر از 12 عدد باشد"
                    };
                }
                else if (!CheckNumberFormat(barErsali.BarErsaliCodeRanande))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "داخل کد راننده فقط میشه عدد وارد کرد"
                    };
                }
                else
                {
                    var result = Barbari_DAL.Ranande.Select_Code(barErsali.BarErsaliCodeRanande);
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
            }
            else
            {
                return new OperationResult
                {
                    Success = true,
                };
            }
        }
        public static OperationResult BarErsali_Validation_KalaDaryafti(KalaDaryafti_Tbl kalaDaryafti)
        {
            if (string.IsNullOrEmpty(kalaDaryafti.KalaDaryaftiNamKala))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(kalaDaryafti.KalaDaryaftiTedadKala.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا را وارد کنید"
                };
            }
            else if (CheckRangeDataType(kalaDaryafti.KalaDaryaftiNamKala, 50))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نام کالا نباید بیشتر از 50 حرف باشد"
                };
            }
            else if (CheckRangeDataType(kalaDaryafti.KalaDaryaftiTedadKala.ToString(), 9))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "تعداد کالا نباید بیشتر از 9 عدد باشد"
                };
            }
            else if (CheckRangeDataType(kalaDaryafti.KalaDaryaftiArzeshKala.ToString(), 15))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "ارزش کالا نباید بیشتر از 15 عدد باشد"
                };
            }
            else if (!CheckNumberFormat(kalaDaryafti.KalaDaryaftiTedadKala.ToString()))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "درون تعداد کالا فقط باید عدد وارد شود"
                };
            }
            else if (!CheckNumberFormat(kalaDaryafti.KalaDaryaftiArzeshKala.ToString()))
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
    }
}
