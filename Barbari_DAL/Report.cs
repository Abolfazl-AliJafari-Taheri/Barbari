using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Report
    {
        public static OperationResult<List<BarErsali_Tbl>> Select_Ranande(int codeRanande, string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliCodeRanande == codeRanande &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_MoshtariSabet(int codeMoshtari, string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliCodeFerestande == codeMoshtari &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_Maghsad(string namShahr, string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliShahreMaghsad1 == namShahr &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0 
                        ||
                        p.BarErsaliShahreMaghsad2== namShahr &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_VorodiBar(string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliNamRanande == null &&
                        p.BarErsaliTarikh.CompareTo(azTarikh) >= 0 && p.BarErsaliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
