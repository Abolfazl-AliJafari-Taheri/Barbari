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
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<IEnumerable<IGrouping<string, City_Tbl>>> Select(string search)
        {
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr.Contains(search)).OrderBy(p => p.CityShahr)
                    .GroupBy(p => p.CityShahr).ToList();
                return new OperationResult<IEnumerable<IGrouping<string, City_Tbl>>>
                {
                    Data = query,
                    Success = true,
                };
            }
            catch 
            {
                return new OperationResult<IEnumerable<IGrouping<string, City_Tbl>>>
                {
                    Success = false
                };
            }
            
        }
        public static OperationResult<List<string>> Select_Shahr()
        {
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
            try
            {
                var query = linq.City_Tbls.Where(p => p.CityShahr == Shahr).OrderBy(p =>p.CityAnbar).
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
