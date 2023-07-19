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
        public static OperationResult<List<BarTahvili_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.BarTahvili_Tbls.Where(p => p.BarTahviliBarname.ToString().Contains(search)).ToList();
                return new OperationResult<List<BarTahvili_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<BarTahvili_Tbl>>
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
        public static OperationResult Insert(BarTahvili_Tbl barTahvili ,List<KalaTahvili_Tbl> kalaTahvili)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            var transaction = linq.Transaction;
            try
            {
                linq.BarTahvili_Tbls.InsertOnSubmit(barTahvili);
                linq.SubmitChanges();

                for (int i = 0; i < kalaTahvili.Count; i++)
                {
                    kalaTahvili[i].KalaTahviliBarname = barTahvili.BarTahviliBarname;
                }

                linq.KalaTahvili_Tbls.InsertAllOnSubmit(kalaTahvili);
                linq.SubmitChanges();

                transaction.Commit();

                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                transaction.Rollback();
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

    }
}
