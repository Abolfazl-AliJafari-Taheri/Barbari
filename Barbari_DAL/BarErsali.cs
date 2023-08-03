using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class BarErsali
    {
        public static OperationResult<List<BarErsali_Tbl>> Select()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarErsali_Tbls.ToList();
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
        public static OperationResult<int> Select_Barname_Last(DataClassBarbariDataContext linq=null)
        {
            linq = linq ?? new DataClassBarbariDataContext();
            try
            {
                var num = linq.ExecuteQuery<int>(("Select IDENT_CURRENT ('BarErsali_Tbl')"));
                int intnum = int.Parse(num.ToString());
                if (intnum != 0)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = intnum
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

                var query = Select_Barname_Last(linq);

                for (int i = 0; i < kalaDaryafti.Count; i++)
                {
                    kalaDaryafti[i].KalaDaryaftiBarname = query.Data;
                }

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
