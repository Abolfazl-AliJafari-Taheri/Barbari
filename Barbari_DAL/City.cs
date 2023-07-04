using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class City
    {
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<List<City_Tbl>> Select(string search)
        {
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr.Contains(search)).ToList();
                return new OperationResult<List<City_Tbl>>
                {
                    Data = query,
                    Success = true,
                };
            }
            catch 
            {
                return new OperationResult<List<City_Tbl>>
                {
                    Success = false
                };
            }
            
        }
        public static OperationResult<List<string>> Select_Shahr() 
        {
            try
            {
                var query = linq.City_Tbls.Select(p => p.CityShahr).ToList();
                return new OperationResult<List<string>>
                {
                    Data = query,
                    Success = true,
                };
            }
            catch
            {
                return new OperationResult<List<string>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<string>> Select_Anbar(string Shahr)
        {
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr == Shahr).Select(p => p.CityAnbar).ToList();
                return new OperationResult<List<string>>
                {
                    Data = query,
                    Success = true,
                };
            }
            catch
            {
                return new OperationResult<List<string>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<City_Tbl>> Select_Shahr_Anbar(string shahr,string anbar)
        {
            try
            {
                var result = linq.City_Tbls.Where(p => p.CityShahr == shahr && p.CityAnbar == anbar).ToList();
                return new OperationResult<List<City_Tbl>>
                {
                    Data = result,
                    Success = true,
                };
            }
            catch 
            {
                return new OperationResult<List<City_Tbl>>
                {
                    Success = false,
                };
            }
           

        }
        public static OperationResult Delete(string shahr,string anbar)
        {
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr == shahr && p.CityAnbar == anbar).Single();
                linq.City_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(City_Tbl city)
        {
            try
            {
                linq.City_Tbls.InsertOnSubmit(city);
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
