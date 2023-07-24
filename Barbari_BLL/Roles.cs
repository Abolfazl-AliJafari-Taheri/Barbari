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



        public static OperationResult Delete(string nam_Roles)
        {
            var result = Barbari_DAL.Roles.Delete(nam_Roles);
            if (result.Success == true)
            {
                return result;
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
