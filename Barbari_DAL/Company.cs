using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Company
    {
        public static OperationResult<Company_Tbl> Select()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Company_Tbls.LastOrDefault();
                return new OperationResult<Company_Tbl>
                {
                    Success = true,
                    Data = query
                };
            }
            catch 
            {
                return new OperationResult<Company_Tbl>
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert(Company_Tbl company)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq.Company_Tbls.InsertOnSubmit(company);
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
