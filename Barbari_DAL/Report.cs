using System;
using System.Collections;
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

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarTahvili_Tbl>> Select_BarTahvili_Ranande(int codeRanande, string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where
                    (p =>
                        p.BarErsaliCodeRanande == codeRanande &&
                        p.BarTahviliTarikh.CompareTo(azTarikh) >= 0 && p.BarTahviliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false
                };
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

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
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

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
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

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_KhorojBar(string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliNamRanande != null &&
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
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_MojodiFeliErsali(string darTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
                        p.BarErsaliNamRanande == null &&
                        p.BarErsaliTarikh == darTarikh

                ).ToList();
                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarTahvili_Tbl>> Select_MojodiFeliTahvili(string darTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where
                    (p =>
                        p.BarTahviliRaveshEhrazHoviat == null &&
                        p.BarTahviliTarikh == darTarikh
                ).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarErsali_Tbl>> Select_MablaghShahri(string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where
                    (p =>
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

                return new OperationResult<List<BarErsali_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarTahvili_Tbl>> Select_BarTahvili_ListBar(string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where
                    (p =>
                        p.BarTahviliTarikh.CompareTo(azTarikh) >= 0 && p.BarTahviliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<BarTahvili_Tbl>> Select_BarTahviliMojodDarAnbar(string azTarikh, string TaTarikh)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where
                    (p =>
                        p.BarTahviliRaveshEhrazHoviat == null &&
                        p.BarTahviliTarikh.CompareTo(azTarikh) >= 0 && p.BarTahviliTarikh.CompareTo(TaTarikh) <= 0
                ).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {

                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = false
                };
            }
        }
    }
}
