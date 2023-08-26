using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_BLL
{
    public class Report
    {
        public static OperationResult<List<BarErsali_Tbl>> Select_Ranande(string codeRanande, string azTarikh, string TaTarikh)
        {
            var result_Validation = Validation.Report_Ranande_Validation(codeRanande, azTarikh, TaTarikh);
            if (result_Validation.Success == true)
            {
                var result = Barbari_DAL.Report.Select_Ranande(int.Parse(codeRanande), azTarikh, TaTarikh);
                if (result.Success == true)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<List<BarErsali_Tbl>>
                    {
                        Success = false
                    };
                }
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                    , Message = result_Validation.Message
                };
            }

        }
        public static OperationResult<List<BarErsali_Tbl>> Select_MoshtariSabet(string codeMoshtari, string azTarikh, string TaTarikh)
        {
            var result_Validation = Validation.Report_Ranande_Validation(codeMoshtari, azTarikh, TaTarikh);
            if (result_Validation.Success == true)
            {
                var result = Barbari_DAL.Report.Select_MoshtariSabet(int.Parse(codeMoshtari), azTarikh, TaTarikh);
                if (result.Success == true)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<List<BarErsali_Tbl>>
                    {
                        Success = false
                    };
                }
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false,
                    Message = result_Validation.Message
                };
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_Maghsad(string namMaghsad, string azTarikh, string TaTarikh)
        {
            var result_Validation = Validation.Report_Maghsad_Validation(namMaghsad, azTarikh, TaTarikh);
            if (result_Validation.Success == true)
            {
                var result = Barbari_DAL.Report.Select_Maghsad(namMaghsad, azTarikh, TaTarikh);
                if (result.Success == true)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<List<BarErsali_Tbl>>
                    {
                        Success = false
                    };
                }
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false,
                    Message = result_Validation.Message
                };
            }

        }
        public static OperationResult<List<BarErsali_Tbl>> Select_VorodiBar(string azTarikh, string TaTarikh)
        {
            var result_Validation = Validation.Report_VorodiBar_Validation(azTarikh, TaTarikh);
            if (result_Validation.Success == true)
            {
                var result = Barbari_DAL.Report.Select_VorodiBar(azTarikh, TaTarikh);
                if (result.Success == true)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<List<BarErsali_Tbl>>
                    {
                        Success = false
                    };
                }
            }
            else
            {
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false,
                    Message = result_Validation.Message
                };
            }

        }
    }
}
