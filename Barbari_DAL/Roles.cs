using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Roles
    {
        public static OperationResult<List<Roles_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Roles_Tbls.Where(p => p.RolesNamRole.Contains(search)).ToList();
                return new OperationResult<List<Roles_Tbl>>
                {
                    Data = query,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Roles_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<Roles_Tbl> Select_Nam(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Roles_Tbls.Where(p => p.RolesNamRole == search).Single();
                return new OperationResult<Roles_Tbl>
                {
                    Data = query,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult<Roles_Tbl>
                {
                    Success = false
                };
            }
        }
        public static OperationResult Delete(string nam_Roles)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Roles_Tbls.Where(p => p.RolesNamRole == nam_Roles).Single();
                linq.Roles_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(Roles_Tbl roles)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                linq.Roles_Tbls.DeleteOnSubmit(roles);
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Update(Roles_Tbl roles)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Roles_Tbls.Where(p => p.RolesNamRole == roles.RolesNamRole).Single();
                //تنظیمات
                query.RolesTanzimat = roles.RolesTanzimat;
                query.TanzimatlogoAndName = roles.TanzimatlogoAndName;
                query.TanzimatRoles = roles.TanzimatRoles;
                //کارمند ها
                query.RolesUsers = roles.RolesUsers;
                query.UsersInsert = roles.UsersInsert;
                query.UsersUpdate = roles.UsersUpdate;
                query.UsersDelete = roles.UsersDelete;
                //راننده
                query.RolesRanande = roles.RolesRanande;
                query.RanandeInsert = roles.RanandeInsert;
                query.RanandeUpdate = roles.RanandeUpdate;
                query.RanandeDelete = roles.RanandeDelete;
                //مشتری
                query.RolesCustomers = roles.RolesCustomers;
                query.CustomersInsert = roles.CustomersInsert;
                query.CustomersUpdate = roles.CustomersUpdate;
                query.CustomersDelete = roles.CustomersDelete;
                //شهر و انبار
                query.RolesCity = roles.RolesCity;
                query.CityInsert = roles.CityInsert;
                query.CityUpdate = roles.CityUpdate;
                query.CityDelete = roles.CityDelete;
                //بار ارسالی
                query.RolesBarErsali = roles.RolesBarErsali;
                query.BarErsaliInsert = roles.BarErsaliInsert;
                query.BarErsaliUpdate = roles.BarErsaliUpdate;
                query.BarErsaliDelete = roles.BarErsaliDelete;
                //بار تحویلی
                query.RolesBarTahvili = roles.RolesBarTahvili;
                query.BarTahviliInsert = roles.BarTahviliInsert;
                query.BarTahviliUpdate = roles.BarTahviliUpdate;
                query.BarTahviliDelete = roles.BarTahviliDelete;
                // گزارش ها
                query.RolesGozaresh = roles.RolesGozaresh;
                linq.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
    }

}
