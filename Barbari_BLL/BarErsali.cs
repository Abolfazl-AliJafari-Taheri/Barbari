﻿using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class BarErsali
    {
        public static OperationResult<List<BarErsali_Tbl>> Select()
        {
            var result = Barbari_DAL.BarErsali.Select();
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(int Code)
        {
            var result = Barbari_DAL.BarErsali.Delete(Code);
            if (result.Success == true)
            {
                return new OperationResult
                {
                    Success = false,
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
<<<<<<< HEAD

=======
        public static OperationResult  Insert(BarErsali_Tbl barErsali,List<KalaDaryafti_Tbl> kalaDaryafti,bool moshtariSabet , bool maghsadNahayi)
        {
            var result1 = Validation.BarErsali_Validation_EtelatFerestande(barErsali, moshtariSabet);
            var result2 = Validation.BarErsali_Validation_EtelatGerande(barErsali, maghsadNahayi);
            var result3 = Validation.BarErsali_Validation_EtelatBar(barErsali);
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
                    Message = result2.Message
                };
            }
            else if (result3.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result3.Message
                };
            }
            else
            {
                var result = Barbari_DAL.BarErsali.Insert(barErsali, kalaDaryafti);
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
        public static OperationResult Insert_TahvilBeRanande(BarErsali_Tbl barErsali)
        {
            var result1 = Validation.BarErsali_Validation_TahvilRanande(barErsali);
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
                var result = Barbari_DAL.BarErsali.Insert_TavilBeRanande(barErsali);
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
>>>>>>> 89c09f8648a42646ec160aaef2fab7e2fc9bb983

    }
}
