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
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<List<BarErsali_Tbl>> Select()
        {
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
        public static OperationResult<int> Select_Barname_Last()
        {
            try
            {
                var query = linq.BarErsali_Tbls.Select(p => p.BarErsaliBarname).LastOrDefault();
                return new OperationResult<int>
                {
                    Success = true,
                    Data = query
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
        public static OperationResult Delete(int search)
        {
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
        public static OperationResult Insert(BarErsali_Tbl barErsali, KalaDaryafti_Tbl kalaDaryafti)
        {
            using (var transaction = linq.Transaction)
            {
                try
                {
                    linq.BarErsali_Tbls.InsertOnSubmit(barErsali);
                    linq.SubmitChanges();

                    linq.KalaDaryafti_Tbls.InsertOnSubmit(kalaDaryafti);
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
        }
    }
}
