using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class BarTahvili
    {
        public static OperationResult<List<BarTahvili_Tbl>> Select(string search)
        {
            var result = Barbari_DAL.BarTahvili.Select(search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult<List<KalaTahvili_Tbl>> Select_KalaTahvili(int codeBarname)
        {
            var result = Barbari_DAL.BarTahvili.Select_KalaTahvili(codeBarname);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<KalaTahvili_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا با پشتیبان تماس بگیرید"
                };
            }
        }
        public static OperationResult Delete(int code)
        {
            var result = Barbari_DAL.BarTahvili.Delete(code);
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
        public static OperationResult Delete_KalaTahvili(int CodeBarname, int codeKalaTahvili)
        {
            var result = Barbari_DAL.BarTahvili.Delete_KalaTahvili(CodeBarname, codeKalaTahvili);
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
        public static OperationResult Insert(BarTahvili_Tbl barTahvili ,List<KalaTahvili_Tbl> kalaTahvili)
        {
            var result1 = Validation.BarTahvili_Validation_EtelatFerestande(barTahvili);
            var result2 = Validation.BarTahvili_Validation_EtelatGerande(barTahvili);
            var result3 = Validation.barTahvili_Validation_EtelatBar(barTahvili);
            var result4 = Validation.BarTahvili_Validation_EtelatRanande(barTahvili);
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
            else if (result4.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result4.Message
                };
            }
            else
            {
                var result = Barbari_DAL.BarTahvili.Insert(barTahvili, kalaTahvili);
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
        public static OperationResult Insert_TahvilBeMoshtari(BarTahvili_Tbl barTahvili)
        {
            var result1 = Validation.BarErsali_Validation_TahvilMoshtari(barTahvili);
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
                var result = Barbari_DAL.BarTahvili.Insert_TavilBeMoshtari(barTahvili);
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
