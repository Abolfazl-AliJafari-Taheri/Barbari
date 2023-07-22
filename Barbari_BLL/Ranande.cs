using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Ranande
    {
        public static OperationResult<List<Ranande_Tbl>> Select(string search = "")
        {
            var result = Barbari_DAL.Ranande.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<Ranande_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };

            }
        }
        public static OperationResult Delete(int code)
        {
            var result = Barbari_DAL.Ranande.Delete(code);
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
        //public static OperationResult Recovery(string code)
        //{
        //    var result = Barbari_DAL.Ranande.Recovery(code);
        //    if (result.Success == true)
        //    {
        //        return new OperationResult
        //        {
        //            Success = true
        //        };
        //    }
        //    else
        //    {
        //        return new OperationResult
        //        {
        //            Success = false,
        //            Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
        //        };

        //    }
        //}
        public static OperationResult Insert(Ranande_Tbl ranande)
        {
            var result1 = Validation.Ranande_Validation(ranande);
            //var result2 = Barbari_DAL.Ranande.Select_Code(ranande.RanandeCodeRanande);
            if (result1.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result1.Message
                };
            }
            //else if (result2.Success == false)
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
            //    };
            //}
            //else if (result2.Data.Any(p => p.RanandeIsDelete == true))
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "این کد راننده قبلا پاک شده میخوای برات برگردونم ؟"
            //    };
            //}
            //else if (result2.Data.Count != 0)
            //{
            //    return new OperationResult
            //    {
            //        Success = false,
            //        Message = "کد راننده تکراری است"
            //    };
            //}
            else
            {
                var result = Barbari_DAL.Ranande.Insert(ranande);
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
        public static OperationResult Update(Ranande_Tbl ranande)
        {
            var result1 = Validation.Ranande_Validation(ranande);
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
                var result = Barbari_DAL.Ranande.Update(ranande);
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
