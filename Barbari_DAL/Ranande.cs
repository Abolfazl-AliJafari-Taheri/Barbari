using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Ranande
    {
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<List<Ranande_Tbl>> Select(string search)
        {
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande.Contains(search) && p.RanandeIsDelete == false).ToList();
                return new OperationResult<List<Ranande_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Ranande_Tbl>>
                {
                    Success = false
                };
            }
            
        }
        public static OperationResult<List<Ranande_Tbl>> Select_Code(string search)
        {
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == search).ToList();
                return new OperationResult<List<Ranande_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Ranande_Tbl>>
                {
                    Success = false,
                };
            }

        }
        public static OperationResult Delete(string code)
        {
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == code).Single();
                query.RanandeIsDelete = true;
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
        public static OperationResult Delete_Back(string code)
        {
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == code).Single();
                query.RanandeIsDelete = false;
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
        public static OperationResult Insert(Ranande_Tbl rananade)
        {
            try
            {
                linq.Ranande_Tbls.InsertOnSubmit(rananade);
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
        public static OperationResult Update(Ranande_Tbl rananade)
        {
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == rananade.RanandeCodeRanande).Single();
                query.RanandeFirstName = rananade.RanandeFirstName;
                query.RanandeLastName = rananade.RanandeLastName;
                query.RanandeMobile = rananade.RanandeMobile;
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
