using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Users
    {
        public static DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
        public static OperationResult<List<Users_Tbl>> Select(string search)
        {
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName.Contains(search) && p.UsersDelete == false).
                    OrderBy(p => p.UsersLastName).ThenBy(p => p.UsersFirstName).ToList();
                return new OperationResult<List<Users_Tbl>>
                {
                    Data = query,
                    Success = true
                };
            }
            catch 
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<Users_Tbl>> Select_UserName(string search)
        {
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == search).ToList();
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch 
            {
                return new OperationResult<List<Users_Tbl>>
                {
                    Success = false,
                };
            }
            
        }
        public static OperationResult Delete(string code)
        {
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == code).Single();
                query.UsersDelete = true;
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
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == code).Single();
                query.UsersDelete = false;
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
        public static OperationResult Insert(Users_Tbl user)
        {
            try
            {
                linq.Users_Tbls.InsertOnSubmit(user);
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
        public static OperationResult Update(Users_Tbl user)
        {
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == user.UsersUserName).Single();
                query.UsersFirstName = user.UsersFirstName;
                query.UsersLastName = user.UsersLastName;
                query.UsersPassWord = user.UsersPassWord;
                query.UsersMobile = user.UsersMobile;
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
        public static OperationResult<Users_Tbl> SearchUserAndPassWord(string userName , string passWord)
        {
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == userName &&
                p.UsersPassWord == passWord).Single();
                return new OperationResult<Users_Tbl>
                {
                    Data = query,
                    Success = true
                };
            }
            catch 
            {
                return new OperationResult<Users_Tbl>
                {
                    Success = false
                };
            }
            
        }
    }
}
