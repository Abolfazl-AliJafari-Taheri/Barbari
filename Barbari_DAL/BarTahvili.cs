using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname.ToString().Contains(search)).OrderByDescending(p => p.BarTahviliCodeBar).Take(20).ToList();
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
                || (p.BarTahviliNamGerande + " " + p.BarTahviliFamilyGerande).Contains(search)).OrderByDescending(p => p.BarTahviliCodeBar).Take(20).ToList();
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
        public static OperationResult<List<KalaTahvili_Tbl>> Select_KalaTahvili(int codeBar)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaTahvili_Tbls.Where(p => p.KalaTahviliCodeBar == codeBar).ToList();
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
        public static OperationResult<int> Select_Barname_Last()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.Barbari_DbConnectionString);
                string query = "SELECT IDENT_CURRENT ('BarTahvili_Tbl');";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int lastValue = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                return new OperationResult<int>
                {
                    Success = true,
                    Data = lastValue
                };
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
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliCodeBar == code).Single();
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
        public static OperationResult Delete_KalaTahvili(int codeBar, int codeKalaTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaTahvili_Tbls.Where(p => p.KalaTahviliCodeBar == codeBar &&
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

                var result = Select_Barname_Last();

                for (int i = 0; i < kalaTahvili.Count; i++)
                {
                    kalaTahvili[i].KalaTahviliCodeBar = result.Data;
                }

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
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliCodeBar == barTahvili.BarTahviliCodeBar).Single();
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
        public static OperationResult Back_To_Anbar(int CodeBar)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliCodeBar == CodeBar).Single();
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
        public static OperationResult Update_BarTahviliUserNameKarmand(int BarTahviliCodeBar, string BarTahviliUserNameKarmand)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliCodeBar == BarTahviliCodeBar).Single();
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
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliCodeBar == barTahvili.BarTahviliCodeBar).Single();
                query.BarTahviliBarname = barTahvili.BarTahviliBarname;
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
                query.BarTahviliSendSms = barTahvili.BarTahviliSendSms;
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
