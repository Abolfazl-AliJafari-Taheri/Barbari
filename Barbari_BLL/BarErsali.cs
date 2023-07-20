using Barbari_BLL;
using Barbari_DAL;
using System.Collections.Generic;

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
    public static OperationResult<List<KalaDaryafti_Tbl>> Select_KalaDaryafti(int codeBarname)
    {
        var result = Barbari_DAL.BarErsali.Select_KalaDaryafti(codeBarname);
        if (result.Success == true)
        {
            return result;
        }
        else
        {
            return new OperationResult<List<KalaDaryafti_Tbl>>
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
    public static OperationResult Delete_KalaDaryafti(int CodeBarname , int codeKalaDaryafti)
    {
        var result = Barbari_DAL.BarErsali.Delete_KalaDaryafti(CodeBarname, codeKalaDaryafti);
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
    public static OperationResult Insert(BarErsali_Tbl barErsali, List<KalaDaryafti_Tbl> kalaDaryafti, bool moshtariSabet, bool maghsadNahayi)
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
    public static OperationResult Update(BarErsali_Tbl barErsali , bool moshtariSabet , bool maghsadNahayi)
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
            var result = Barbari_DAL.BarErsali.Update(barErsali);
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