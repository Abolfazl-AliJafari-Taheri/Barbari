﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Ranande
    {
        public static OperationResult<List<Ranande_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeLastName.Contains(search) && p.RanandeIsDelete == false).
                    OrderByDescending(p => p.RanandeCodeRanande).Take(20).ToList();
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
        public static OperationResult<List<Ranande_Tbl>> Select_Code(int search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        public static OperationResult<Ranande_Tbl> Select_Code_NoList(int search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == search).Single();
                return new OperationResult<Ranande_Tbl>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<Ranande_Tbl>
                {
                    Success = false,
                };
            }

        }
        public static OperationResult<int> Select_CodeLast()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Ranande_Tbls.OrderByDescending(p => p.RanandeCodeRanande).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = query.RanandeCodeRanande
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
                    Success = false,
                };
            }
        }
        public static OperationResult<List<int>> Select_AllRanandeCode()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Ranande_Tbls.Where(p => p.RanandeIsDelete == false).Select(p => p.RanandeCodeRanande).ToList();
                return new OperationResult<List<int>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<int>>
                {
                    Success = false,
                };
            }
        }
        public static OperationResult Delete(int code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        //public static OperationResult Recovery(string code)
        //{
        //    DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        //    try
        //    {
        //        var query = linq.Ranande_Tbls.Where(p => p.RanandeCodeRanande == code).Single();
        //        query.RanandeIsDelete = false;
        //        linq.SubmitChanges();
        //        return new OperationResult
        //        {
        //            Success = true
        //        };
        //    }
        //    catch
        //    {
        //        return new OperationResult
        //        {
        //            Success = false
        //        };
        //    }
        //}
        public static OperationResult Insert(Ranande_Tbl rananade)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
