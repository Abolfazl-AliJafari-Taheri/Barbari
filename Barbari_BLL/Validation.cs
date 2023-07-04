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
    }
}
