﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_DAL
{
    public class Users
    {
        public static OperationResult<List<Users_Tbl>> Select(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersLastName.Contains(search) && p.UsersDelete == false).
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
        public static OperationResult<Users_Tbl> Select_DataFirst()
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Users_Tbls.FirstOrDefault();
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
        public static OperationResult<List<Users_Tbl>> Select_UserName(string search)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        public static OperationResult<Users_Tbl> Select_Asli(string userName)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == userName).Single();
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
        public static OperationResult Delete(string code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
        public static OperationResult Recovery(string code)
        {
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == user.UsersUserName).Single();
                query.UsersFirstName = user.UsersFirstName;
                query.UsersLastName = user.UsersLastName;
                query.UsersPassWord = user.UsersPassWord;
                query.UsersMobile = user.UsersMobile;
                query.UsersRoles = user.UsersRoles;
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
            DataClassBarbariDataContext linq = new DataClassBarbariDataContext();
            try
            {
                
                var query = linq.Users_Tbls.Where(p => p.UsersUserName == userName &&
                p.UsersPassWord == passWord && p.UsersDelete == false).FirstOrDefault();
                if(query!=null)
                {
                    return new OperationResult<Users_Tbl>
                    {
                        Data = query,
                        Success = true
                    };
                }
                else
                {
                    return new OperationResult<Users_Tbl>
                    {
                        Data = null,
                        Success = false
                    };
                }
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
