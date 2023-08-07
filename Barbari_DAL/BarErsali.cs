using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class BarErsali
    {
        public static OperationResult<List<BarErsali_Tbl>> Select_Barname(string search = "")
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => p.BarErsaliBarname.ToString().Contains(search)).ToList();
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
        public static OperationResult<List<BarErsali_Tbl>> Select_NamAndFamily(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => (p.BarErsaliNamFerestande+" "+p.BarErsaliFamilyFerestande).Contains(search)
                || (p.BarErsaliNamGerande+" "+p.BarErsaliFamilyGerande).Contains(search)).ToList();
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
        public static OperationResult<BarErsali_Tbl> Select_FirstBarname()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.FirstOrDefault();
                return new OperationResult<BarErsali_Tbl>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult<BarErsali_Tbl>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<KalaDaryafti_Tbl>> Select_KalaDaryafti(int codeBarname)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaDaryafti_Tbls.Where(p => p.KalaDaryaftiBarname == codeBarname).ToList();
                return new OperationResult<List<KalaDaryafti_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<KalaDaryafti_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<int> Select_KalaDaryafti_CodeLast()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaDaryafti_Tbls.OrderByDescending(p => p.KalaDaryaftiCodeKala).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = query.KalaDaryaftiCodeKala
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
                string query = "SELECT IDENT_CURRENT ('BarErsali_Tbl');";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int lastValue = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                var query_Select_First = Select_FirstBarname();

                if (lastValue != 1000)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = lastValue
                    };
                }
                else if(query_Select_First.Data == null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = 999
                    };
                }
                else
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = 1000
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
        public static OperationResult Delete(int search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => p.BarErsaliBarname == search).Single();
                linq.BarErsali_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Delete_KalaDaryafti(int codeBarname,int codeKalaDaryafti)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.KalaDaryafti_Tbls.Where(p => p.KalaDaryaftiBarname == codeBarname &&
                p.KalaDaryaftiCodeKala == codeKalaDaryafti).Single();
                linq.KalaDaryafti_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(BarErsali_Tbl barErsali, List<KalaDaryafti_Tbl> kalaDaryafti)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            linq.Connection.Open();
            linq.Transaction = linq.Connection.BeginTransaction();
            try
            {
                linq.BarErsali_Tbls.InsertOnSubmit(barErsali);
                linq.SubmitChanges();

                linq.KalaDaryafti_Tbls.InsertAllOnSubmit(kalaDaryafti);
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
        public static OperationResult Insert_KalaDaryafti(KalaDaryafti_Tbl kalaDaryafti)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq.KalaDaryafti_Tbls.InsertOnSubmit(kalaDaryafti);
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
        public static OperationResult Insert_TavilBeRanande(BarErsali_Tbl barErsali)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => p.BarErsaliBarname == barErsali.BarErsaliBarname).Single();
                query.BarErsaliCodeRanande = barErsali.BarErsaliCodeRanande;
                query.BarErsaliNamRanande = barErsali.BarErsaliNamRanande;
                query.BarErsaliFamilyRanande = barErsali.BarErsaliFamilyRanande;
                query.BarErsaliMobileRanande = barErsali.BarErsaliMobileRanande;
                query.BarErsaliKerayeRanande = barErsali.BarErsaliKerayeRanande;
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
        public static OperationResult Update_BarErsaliUserNameKarmand(int BarErsaliBarname, string BarErsaliUserNameKarmand)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => p.BarErsaliBarname == BarErsaliBarname).Single();
                query.BarErsaliUserNameKarmand = BarErsaliUserNameKarmand;
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
        public static OperationResult Update(BarErsali_Tbl barErsali)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.Where(p => p.BarErsaliBarname == barErsali.BarErsaliBarname).Single();
                query.BarErsaliCodeFerestande = barErsali.BarErsaliCodeFerestande;
                query.BarErsaliNamFerestande = barErsali.BarErsaliNamFerestande;
                query.BarErsaliFamilyFerestande = barErsali.BarErsaliFamilyFerestande;
                query.BarErsaliMobileFerestande = barErsali.BarErsaliMobileFerestande;
                query.BarErsaliNamGerande = barErsali.BarErsaliNamGerande;
                query.BarErsaliFamilyGerande = barErsali.BarErsaliFamilyGerande;
                query.BarErsaliMobileGerande = barErsali.BarErsaliMobileGerande;
                query.BarErsaliShahreMabda = barErsali.BarErsaliShahreMabda;
                query.BarErsaliAnbarMabda = barErsali.BarErsaliAnbarMabda;
                query.BarErsaliShahreMaghsad1 = barErsali.BarErsaliShahreMaghsad1;
                query.BarErsaliAnbarMaghsad1 = barErsali.BarErsaliAnbarMaghsad1;
                query.BarErsaliShahreMaghsad2 = barErsali.BarErsaliShahreMaghsad2;
                query.BarErsaliAnbarMaghsad2 = barErsali.BarErsaliAnbarMaghsad2;
                query.BarErsaliTarikh = barErsali.BarErsaliTarikh;
                query.BarErsaliSaat = barErsali.BarErsaliSaat;
                query.BarErsaliCodeRanande = barErsali.BarErsaliCodeRanande;
                query.BarErsaliNamRanande = barErsali.BarErsaliNamRanande;
                query.BarErsaliFamilyRanande = barErsali.BarErsaliFamilyRanande;
                query.BarErsaliMobileRanande = barErsali.BarErsaliMobileRanande;
                query.BarErsaliKerayeRanande = barErsali.BarErsaliKerayeRanande;
                query.BarErsaliPishKeraye = barErsali.BarErsaliPishKeraye;
                query.BarErsaliPasKeraye = barErsali.BarErsaliPasKeraye;
                query.BarErsaliBime = barErsali.BarErsaliBime;
                query.BarErsaliAnbardari = barErsali.BarErsaliAnbardari;
                query.BarErsaliShahri = barErsali.BarErsaliShahri;
                query.BarErsaliBastebandi = barErsali.BarErsaliBastebandi;
                query.BarErsaliUserNameKarmand = barErsali.BarErsaliUserNameKarmand;
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
