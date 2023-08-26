using System;
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
                var query = linq.Customers_Tbls.Where(p => p.CustomersLastName.Contains(search) && p.CustomersIsDelete == false).
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
        public static OperationResult<List<Customers_Tbl>> Select_Code(int search)
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
        public static OperationResult<Customers_Tbl> Select_Code_NotList(int search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq = new DataClassBarbariDataContext();
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == search).Single();
                return new OperationResult<Customers_Tbl>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<Customers_Tbl>
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
                var query = linq.Customers_Tbls.OrderByDescending(p => p.CustomersCode).FirstOrDefault();
                if (query != null)
                {
                    return new OperationResult<int>
                    {
                        Success = true,
                        Data = query.CustomersCode
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
        public static OperationResult<List<int>> Select_AllCustomersCode()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Customers_Tbls.Where(p => p.CustomersIsDelete == false).Select(p => p.CustomersCode).ToList();
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
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == code).Single();
                query.CustomersIsDelete = true;
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
                    Success = false,
                };
            }
        }
        //public static OperationResult Recovery(int code)
        //{
        //    DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        //    try
        //    {
        //        var query = linq.Customers_Tbls.Where(p => p.CustomersCode == code).Single();
        //        query.CustomersIsDelete = false;
        //        return new OperationResult
        //        {
        //            Success = true,
        //        };
        //    }
        //    catch
        //    {
        //        return new OperationResult
        //        {
        //            Success = false,
        //        };
        //    }
        //}
        public static OperationResult Insert(Customers_Tbl customer)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
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
                var query = linq.Customers_Tbls.Where(p => p.CustomersCode == customer.CustomersCode).Single();
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
