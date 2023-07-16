﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Customers
    {
        public static OperationResult<List<Customers_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode.Contains(search) && p.CustomersIsDelete == false).
                    OrderBy(p => p.CustomersLastName).ThenBy(p => p.CustomersFirstName).ToList();
                return new OperationResult<List<Customers_Tbl>>
                {
                    Data = query,
                    Success = true
                };
            }
            catch 
            {
                return new OperationResult<List<Customers_Tbl>>
                {
                    Success= false
                };
            }
        }
        public static OperationResult<List<Customers_Tbl>> Select_Code(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == search).ToList();
                return new OperationResult<List<Customers_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Customers_Tbl>>
                {
                    Success = false,
                };
            }
        }
        public static OperationResult Delete(string code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == code).Single();
                query.CustomersIsDelete = true;
                return new OperationResult
                {
                    Success = true,
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false,
                };
            }
        }
        public static OperationResult Recovery(string code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == code).Single();
                query.CustomersIsDelete = false;
                return new OperationResult
                {
                    Success = true,
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false,
                };
            }
        }
        public static OperationResult Insert(Customers_Tbl customer)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                linq = new DataClassBarbariDataContext();
                linq.Customers_Tbls.InsertOnSubmit(customer);
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
        public static OperationResult Update(Customers_Tbl customer)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();

            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode== customer.CustomersCode).Single();
                query.CustomersFirstName= customer.CustomersFirstName;
                query.CustomersLastName = customer.CustomersLastName;
                query.CustomersMobile = customer.CustomersMobile;
                query.CustomersCity= customer.CustomersCity;
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
