using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class City
    {
        public static OperationResult<List<City_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr.Contains(search)).OrderBy(p => p.CityShahr).ToList();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.City_Tbls.Select(p => p.CityShahr).Distinct().ToList();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr == Shahr).OrderBy(p => p.CityAnbar).
                    Select(p => p.CityAnbar).ToList();
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
        public static OperationResult<int> Select_Shahr_Anbar(string shahr,string anbar)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var result = linq.City_Tbls.Count(p => p.CityShahr == shahr && p.CityAnbar == anbar);
                return new OperationResult<int>
                {
                    Data = result,
                    Success = true,
                };
            }
            catch 
            {
                return new OperationResult<int>
                {
                    Success = false,
                };
            }
           

        }
        public static OperationResult Delete(string shahr,string anbar)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        public static OperationResult Update(City_Tbl city)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr == city.CityShahr && p.CityAnbar == city.CityAnbar).Single();
                query.CityAdres = city.CityAdres;
                query.CityMobile= city.CityMobile;
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
    public class CityComparer : IEqualityComparer<City_Tbl>
    {
        public bool Equals(City_Tbl x, City_Tbl y)
        {
            if (x.CityShahr == y.CityShahr)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(City_Tbl obj)
        {
            return obj.CityShahr.GetHashCode();
        }
    }
}
