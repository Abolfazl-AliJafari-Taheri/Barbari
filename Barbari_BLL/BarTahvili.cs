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
        public static OperationResult<List<BarTahvili_Tbl>> Select(string search = "")
        {
            if (Validation.CheckNumberFormat(search))
            {
                var result = Barbari_DAL.BarTahvili.Select_Barname(search);
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
            else
            {
                var result = Barbari_DAL.BarTahvili.Select_NamAndFamily(search);
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
        }
        public static OperationResult<List<KalaTahvili_Tbl>> Select_KalaTahvili(int codeBar)
        {
            var result = Barbari_DAL.BarTahvili.Select_KalaTahvili(codeBar);
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
        public static OperationResult<int> Select_KalaTahvili_CodeLast()
        {
            var result = Barbari_DAL.BarTahvili.Select_KalaTahvili_CodeLast();
            if (result.Success == true && result.Data == 0)
            {
                return new OperationResult<int>
                {
                    Success = true,
                    // کد کالا از 1 شروع میشه
                    Data = 0
                };
            }
            else if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<int>
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
        public static OperationResult Delete_KalaTahvili(int codeBar, int codeKalaTahvili)
        {
            var result = Barbari_DAL.BarTahvili.Delete_KalaTahvili(codeBar, codeKalaTahvili);
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
        public static OperationResult Insert(BarTahvili_Tbl barTahvili, List<KalaTahvili_Tbl> kalaTahvili)
        {
            var result1 = Validation.BarTahvili_Validation_EtelatFerestande(barTahvili.BarTahviliShahrFerestande,
                barTahvili.BarTahviliNamFerestande , barTahvili.BarTahviliFamilyFerestande , barTahvili.BarTahviliMobileFerestande);

            var result2 = Validation.BarTahvili_Validation_EtelatGerande(barTahvili.BarTahviliShahrGerande ,
                barTahvili.BarTahviliNamGerande, barTahvili.BarTahviliFamilyGerande, barTahvili.BarTahviliMobileGerande);

            var result3 = Validation.barTahvili_Validation_EtelatBar(barTahvili.BarTahviliBarname , barTahvili.BarTahviliPishKeraye.ToString() , barTahvili.BarTahviliPasKeraye.ToString()
                , barTahvili.BarTahviliBime.ToString(), barTahvili.BarTahviliAnbardari.ToString(), barTahvili.BarTahviliShahri.ToString(), barTahvili.BarTahviliBastebandi.ToString(), barTahvili.BarTahviliTarikh);

            var result4 = Validation.BarTahvili_Validation_EtelatRanande(barTahvili.BarTahviliNamRanande , barTahvili.BarTahviliFamilyRanande,
                barTahvili.BarTahviliMobileRanande , barTahvili.BarErsaliCodeRanande.ToString());

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
        public static OperationResult Insert_KalaTahvili(KalaTahvili_Tbl kalaTahvili)
        {
            var result2 = Validation.BarTahvili_Validation_KalaTahvili(kalaTahvili.KalaTahviliNamKala , kalaTahvili.KalaTahviliTedadKala.ToString());
            if (result2.Success == false)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = result2.Message
                };
            }
            else
            {
                var result = Barbari_DAL.BarTahvili.Insert_KalaTahvili(kalaTahvili);
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
            var result1 = Validation.BarTahvili_Validation_TahvilMoshtari(barTahvili.BarTahviliRaveshEhrazHoviat , barTahvili.BarTahviliRaveshEhrazHoviatText);
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
        public static OperationResult Back_To_Anbar(int CodeBar)
        {
            var result = Barbari_DAL.BarTahvili.Back_To_Anbar(CodeBar);
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
        public static OperationResult Update_BarTahviliUserNameKarmand(int BarErsaliCodeBar, string BarErsaliUserNameKarmand)
        {
            var result = Barbari_DAL.BarTahvili.Update_BarTahviliUserNameKarmand(BarErsaliCodeBar, BarErsaliUserNameKarmand);
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
        public static OperationResult Update(BarTahvili_Tbl barTahvili , bool TahvilMoshtari)
        {
            var result1 = Validation.BarTahvili_Validation_EtelatFerestande(barTahvili.BarTahviliShahrFerestande,
                barTahvili.BarTahviliNamFerestande, barTahvili.BarTahviliFamilyFerestande, barTahvili.BarTahviliMobileFerestande);

            var result2 = Validation.BarTahvili_Validation_EtelatGerande(barTahvili.BarTahviliShahrGerande,
                barTahvili.BarTahviliNamGerande, barTahvili.BarTahviliFamilyGerande, barTahvili.BarTahviliMobileGerande);

            var result3 = Validation.barTahvili_Validation_EtelatBar(barTahvili.BarTahviliBarname , barTahvili.BarTahviliPishKeraye.ToString(), barTahvili.BarTahviliPasKeraye.ToString()
                , barTahvili.BarTahviliBime.ToString(), barTahvili.BarTahviliAnbardari.ToString(), barTahvili.BarTahviliShahri.ToString(), barTahvili.BarTahviliBastebandi.ToString(), barTahvili.BarTahviliTarikh);

            var result4 = Validation.BarTahvili_Validation_EtelatRanande(barTahvili.BarTahviliNamRanande, barTahvili.BarTahviliFamilyRanande,
                barTahvili.BarTahviliMobileRanande, barTahvili.BarErsaliCodeRanande.ToString());

            if (TahvilMoshtari == true)
            {
                var result5 = Validation.BarTahvili_Validation_TahvilMoshtari(barTahvili.BarTahviliRaveshEhrazHoviat, barTahvili.BarTahviliRaveshEhrazHoviatText);
                if (result5.Success == false)
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = result5.Message
                    };
                }
            }
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
                var result = Barbari_DAL.BarTahvili.Update(barTahvili);
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
