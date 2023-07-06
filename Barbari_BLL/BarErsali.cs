using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class BarErsali
    {
        public OperationResult<List<BarErsali_Tbl>> Select()
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
        public OperationResult Delete(int Code)
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
        public OperationResult Insert(BarErsali_Tbl barErsali)
        {

        }

    }
}
