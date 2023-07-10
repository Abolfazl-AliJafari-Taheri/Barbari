using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Users
    {
        public static OperationResult<List<Users_Tbl>> Select(string search = "")
        {
            var result = Barbari_DAL.Users.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(string code)
        {
            var result = Barbari_DAL.Users.Delete(code);
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
            var result = Barbari_DAL.Users.Delete_Back(code);
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
        public static OperationResult Insert(Users_Tbl user)
        {
            var result1 = Validation.Users_Validation(user);
            var result2 = Barbari_DAL.Users.Select_UserName(user.UsersUserName);
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
            else if (result2.Data.Any(p => p.UsersDelete == true))
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
                    Message = "نام کاربری تکراری است"
                };
            }
            else
            {
                var result = Barbari_DAL.Users.Insert(user);
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
        public static OperationResult Update(Users_Tbl user)
        {
            var result1 = Validation.Users_Validation(user);
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
                var result = Barbari_DAL.Users.Update(user);
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
        public static OperationResult<Users_Tbl> SearchUserAndPassWord(string userName , string passWord)
        {
            if (string.IsNullOrEmpty(userName) || userName == "نام کاربری")
            {
                return new OperationResult<Users_Tbl>
                {
                    Success = false,
                    Message = "لطفا نام کاربری را وارد کنید"
                };
            }
            else if (string.IsNullOrEmpty(passWord) || passWord == "رمز عبور")
            {
                return new OperationResult<Users_Tbl>
                {
                    Success = false,
                    Message = "لطفا رمز عبور را وارد کنید"
                };
            }
            else
            {
                var result = Barbari_DAL.Users.SearchUserAndPassWord(userName, passWord);
                if (result.Data != null)
                {
                    if (result.Success == true)
                    {

                        return new OperationResult<Users_Tbl>
                        {
                            Success = true,
                            Data = result.Data
                        };
                    }
                    else
                    {
                        return new OperationResult<Users_Tbl>
                        {
                            Success = false,
                            Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                        };
                    }
                }
                else
                {
                    return new OperationResult<Users_Tbl>
                    {
                        Success = false,
                        Message = "نام کاربری یا رمز عبور اشتباه است"
                    };
                }
                
            }
        }
    }
}
