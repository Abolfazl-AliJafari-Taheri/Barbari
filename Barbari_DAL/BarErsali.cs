﻿using System;
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
        public static OperationResult<int> Select_Barname_Last()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        public static OperationResult Insert(BarErsali_Tbl barErsali, List<KalaDaryafti_Tbl> kalaDaryafti)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            var transaction = linq.Transaction;
            try
            {
                linq = new DataClassBarbariDataContext();
                linq.BarErsali_Tbls.InsertOnSubmit(barErsali);
                linq.SubmitChanges();

                for (int i = 0; i < kalaDaryafti.Count; i++)
                {
                    kalaDaryafti[i].KalaDaryaftiBarname = barErsali.BarErsaliBarname;
                }

                linq.KalaDaryafti_Tbls.InsertAllOnSubmit(kalaDaryafti);
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
        public static OperationResult Insert_TavilBeRanande(BarErsali_Tbl barErsali)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq = new DataClassBarbariDataContext();
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
    }
}
