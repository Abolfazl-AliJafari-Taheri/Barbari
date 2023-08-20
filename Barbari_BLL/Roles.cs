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
        public static OperationResult<List<string>> Select_AllNamRoles()
        {
            var result = Barbari_DAL.Roles.Select_AllNamRoles();
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
        public static OperationResult<List<Users_Tbl>> Select_Count(string search)
        {
            var result = Barbari_DAL.Roles.Select_Count(search);
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
        public static OperationResult<Roles_Tbl> Select_First()
        {
            var result = Barbari_DAL.Roles.Select_First();
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
        public static OperationResult<Roles_Tbl> Roles_Login(string search)
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
            var result1 = Select_First();
            if (result1.Data.RolesNamRole == nam_Roles)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نقش اصلی را نمی توان پاک کرد"
                };
            }
            else if (result.Success == true)
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
            var result2 = Select_First();
            if (result2.Data.RolesNamRole == roles.RolesNamRole)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "نقش اصلی را نمی توان ویرایش کرد"
                };
            }
            else if (result1.Success == false)
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
