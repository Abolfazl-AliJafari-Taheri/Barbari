using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Roles
    {
        public static OperationResult<List<Roles_Tbl>> Select(string search)
        {
            var result = Barbari_DAL.Roles.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<Roles_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult<Roles_Tbl> Login_Roles(string search)
        {
            var result = Barbari_DAL.Roles.Login_Roles(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<Roles_Tbl>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(string nam_Roles)
        {
            var result = Barbari_DAL.Roles.Delete(nam_Roles);
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
        public static OperationResult Insert(Roles_Tbl roles)
        {
            var result1 = Validation.Roles_Validation(roles);
            var result2 = Barbari_DAL.Roles.Select_NamRoles(roles.RolesNamRole);
            if (result1.Success == false)
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                    Message = result1.Message
                };
            }
            else if (result2.Success == false)
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
            else if (result2.Data.Count != 0)
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                    Message = "نام نقش تکراری است"
                };
            }
            else
            {
                var result = Barbari_DAL.Roles.Insert(roles);
                if (result.Success == true)
                {
                    return new OperationResult<List<Users_Tbl>>
                    {
                        Success = true,
                    };
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
        }
        public static OperationResult Update(Roles_Tbl roles)
        {
            var result1 = Validation.Roles_Validation(roles);
            if (result1.Success == false)
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                    Message = result1.Message
                };
            }
            else
            {
                var result = Barbari_DAL.Roles.Update(roles);
                if (result.Success == true)
                {
                    return new OperationResult<List<Users_Tbl>>
                    {
                        Success = true,
                    };
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
        }
    }
}
