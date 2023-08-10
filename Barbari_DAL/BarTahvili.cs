using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class BarTahvili
    {
        public static OperationResult<List<BarTahvili_Tbl>> Select_Barname(string search = "")
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname.ToString().Contains(search)).OrderByDescending(p => p.BarTahviliBarname).Take(30).ToList();
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
        public static OperationResult<List<BarTahvili_Tbl>> Select_NamAndFamily(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => (p.BarTahviliNamFerestande + " " + p.BarTahviliFamilyFerestande).Contains(search)
                || (p.BarTahviliNamGerande + " " + p.BarTahviliFamilyGerande).Contains(search)).OrderByDescending(p => p.BarTahviliBarname).Take(30).ToList();
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
        public static OperationResult<List<KalaTahvili_Tbl>> Select_KalaTahvili(int codeBarname)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaTahvili_Tbls.Where(p => p.KalaTahviliBarname == codeBarname).ToList();
                return new OperationResult<List<KalaTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<KalaTahvili_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<int> Select_KalaTahvili_CodeLast()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaTahvili_Tbls.OrderByDescending(p => p.KalaTahviliCodeKala).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = query.KalaTahviliCodeKala
                    };
                }
                else
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = 0
                    };
                }
            }
            catch (Exception)
            {
                return new OperationResult<int>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<int> Select_Barname_Last(DataClassBarbariDataContext linq = null)
        {
            linq = linq ?? new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.OrderByDescending(p => p.BarTahviliBarname).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = query.BarTahviliBarname
                    };
                }
                else
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = 0
                    };
                }
            }
            catch
            {
                return new OperationResult<int>
                {
                    Success = false
                };

            }
        }
        public static OperationResult Delete(int code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname == code).Single();
                linq.BarTahvili_Tbls.DeleteOnSubmit(query);
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true,
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }

        }
        public static OperationResult Delete_KalaTahvili(int codeBarname, int codeKalaTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaTahvili_Tbls.Where(p => p.KalaTahviliBarname == codeBarname &&
                p.KalaTahviliCodeKala == codeKalaTahvili).Single();
                linq.KalaTahvili_Tbls.DeleteOnSubmit(query);
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert(BarTahvili_Tbl barTahvili ,List<KalaTahvili_Tbl> kalaTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            linq.Connection.Open();
            linq.Transaction = linq.Connection.BeginTransaction();
            try
            {
                linq.BarTahvili_Tbls.InsertOnSubmit(barTahvili);
                linq.SubmitChanges();

                linq.KalaTahvili_Tbls.InsertAllOnSubmit(kalaTahvili);
                linq.SubmitChanges();

                linq.Transaction.Commit();
                linq.Connection.Close();

                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                linq.Transaction.Rollback();
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert_KalaTahvili(KalaTahvili_Tbl kalaTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq.KalaTahvili_Tbls.InsertOnSubmit(kalaTahvili);
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert_TavilBeMoshtari(BarTahvili_Tbl barTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname == barTahvili.BarTahviliBarname).Single();
                query.BarTahviliRaveshEhrazHoviat = barTahvili.BarTahviliRaveshEhrazHoviat;
                query.BarTahviliRaveshEhrazHoviatText = barTahvili.BarTahviliRaveshEhrazHoviatText;
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Back_To_Anbar(int CodeBarname)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname == CodeBarname).Single();
                query.BarTahviliRaveshEhrazHoviat = null;
                query.BarTahviliRaveshEhrazHoviatText = null;
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Update_BarTahviliUserNameKarmand(int BarTahviliBarname, string BarTahviliUserNameKarmand)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname == BarTahviliBarname).Single();
                query.BarTahviliUserNameKarmand = BarTahviliUserNameKarmand;
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };

            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Update(BarTahvili_Tbl barTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname == barTahvili.BarTahviliBarname).Single();
                query.BarTahviliShahrFerestande = barTahvili.BarTahviliShahrFerestande;
                query.BarTahviliNamFerestande = barTahvili.BarTahviliNamFerestande;
                query.BarTahviliFamilyFerestande = barTahvili.BarTahviliFamilyFerestande;
                query.BarTahviliMobileFerestande = barTahvili.BarTahviliMobileFerestande;
                query.BarTahviliShahrGerande = barTahvili.BarTahviliShahrGerande;
                query.BarTahviliNamGerande = barTahvili.BarTahviliNamGerande;
                query.BarTahviliFamilyGerande = barTahvili.BarTahviliFamilyGerande;
                query.BarTahviliMobileGerande = barTahvili.BarTahviliMobileGerande;
                query.BarTahviliNamRanande = barTahvili.BarTahviliNamRanande;
                query.BarTahviliFamilyRanande = barTahvili.BarTahviliFamilyRanande;
                query.BarTahviliMobileRanande = barTahvili.BarTahviliMobileRanande;
                query.BarTahviliTarikh = barTahvili.BarTahviliTarikh;
                query.BarTahviliiSaat = barTahvili.BarTahviliiSaat;
                query.BarTahviliPishKeraye = barTahvili.BarTahviliPishKeraye;
                query.BarTahviliPasKeraye = barTahvili.BarTahviliPasKeraye;
                query.BarTahviliBime = barTahvili.BarTahviliBime;
                query.BarTahviliAnbardari = barTahvili.BarTahviliAnbardari;
                query.BarTahviliShahri = barTahvili.BarTahviliShahri;
                query.BarTahviliBastebandi = barTahvili.BarTahviliBastebandi;
                query.BarTahviliRaveshEhrazHoviat = barTahvili.BarTahviliRaveshEhrazHoviat;
                query.BarTahviliRaveshEhrazHoviatText = barTahvili.BarTahviliRaveshEhrazHoviatText;
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };

            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }

    }
}
