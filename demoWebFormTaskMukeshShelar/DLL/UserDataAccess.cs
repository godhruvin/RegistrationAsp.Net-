using Aspose.Pdf.Operators;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace demoWebFormTaskMukeshShelar.DLL
{
    public class UserDataAccess
    {
        public int CheckUserValidity(string userId, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    var cmd = SqlHelper.CreateCommand(conn, "checkUserValidity");
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                        new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password}
                    };
                    SqlHelper.AttachParameters(cmd, parameters);
                    int userexists = (int)cmd.ExecuteScalar();
                    return userexists;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }
       
        public string UserDataInsert(string userId, string firstName, string lastName, string mobileNumber, string email, string gender,
                                     string maritalStatus, string remarks, DateTime dob, int age, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    var command = SqlHelper.CreateCommand(conn, "insertUserData");
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                        new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = firstName },
                        new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = lastName },
                        new SqlParameter("@MobileNumber", SqlDbType.NVarChar) { Value = mobileNumber },
                        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                        new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = gender},
                        new SqlParameter("@MaritalStatus", SqlDbType.NVarChar) { Value = maritalStatus},
                        new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = remarks},
                        new SqlParameter("@DOB", SqlDbType.Date) { Value = dob },
                        new SqlParameter("@Age", SqlDbType.Int) { Value = age},
                        new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password}
                    };
                    SqlHelper.AttachParameters(command, parameters);
                    string result = (string)command.ExecuteScalar();
                    return result;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }
       
        public DataTable FetchAllUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "fetchUsersDetails");
                    return ds.Tables[0];
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }
        
        public int insertDocument(string userId, string document)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    var command = SqlHelper.CreateCommand(conn, "insertDocument");
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                        new SqlParameter("@uploaded_document", SqlDbType.NVarChar) { Value = document },

                    };
                    SqlHelper.AttachParameters(command, parameters);
                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }

        }
       
        public int insertTifDocument(string userId, string tifdocumentname)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    var command = SqlHelper.CreateCommand(conn, "insertTifDocument");
                    var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                    new SqlParameter("@tifdocumentname", SqlDbType.NVarChar) { Value = tifdocumentname },

                };
                    SqlHelper.AttachParameters(command, parameters);
                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }
        
        public int StoreUserLoginInfo(string userId, string Guid, string SourcePage, DateTime CreatedOn, int isActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = SqlHelper.CreateCommand(conn, "storeLoginUserInfo");
                    var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                    new SqlParameter("@Guid", SqlDbType.NVarChar) { Value = Guid },
                    new SqlParameter("@SourcePage", SqlDbType.NVarChar) { Value = SourcePage },
                    new SqlParameter("@CreatedOn", SqlDbType.DateTime) { Value = CreatedOn },
                    new SqlParameter("@isActive", SqlDbType.Int) { Value = isActive }
                };
                    SqlHelper.AttachParameters(cmd, parameters);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }
        
        public DataSet fetchUserBasedOnUserId(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    string queryToFetchUserDetails = "select FirstName , LastName , DOB , Email  , MobileNumber, MaritalStatus ,Gender, Age , Remarks from registrationtable where userId = @userId";
                    var cmd = SqlHelper.CreateCommand(conn, queryToFetchUserDetails);
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                    };
                    return SqlHelper.ExecuteDataset(conn, CommandType.Text, queryToFetchUserDetails, parameters.ToArray());
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }
        }

        public string updateUserData(string userId, string FirstName, string LastName, string mobileNumber, string email, string gender,
                                    string maritalStatus, string remarks, DateTime dob, int age)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    var command = SqlHelper.CreateCommand(conn, "updateUserData");
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@userId", SqlDbType.NVarChar) { Value = userId },
                        new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = FirstName },
                        new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = LastName },
                        new SqlParameter("@MobileNumber", SqlDbType.NVarChar) { Value = mobileNumber },
                        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                        new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = gender},
                        new SqlParameter("@MaritalStatus", SqlDbType.NVarChar) { Value = maritalStatus},
                        new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = remarks},
                        new SqlParameter("@DOB", SqlDbType.Date) { Value = dob },
                        new SqlParameter("@Age", SqlDbType.Int) { Value = age}
                    };
                    SqlHelper.AttachParameters(command, parameters);
                    string result = (string)command.ExecuteScalar();
                    return result;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql Error Occured : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error In data layer Occured : " + ex.Message);
            }

        }

        public string forgotPasswordCheckUserCriteria(string mobileNumber, string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM registrationTable WHERE MobileNumber = @MobileNumber AND Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int userExists = (int)cmd.ExecuteScalar();

                        return userExists > 0 ? "User exists" : "User not found";
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("SQL Error occurred: " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in data layer occurred: " + ex.Message);
            }
        }
        
        public bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    string query = "UPDATE registrationTable SET Password = @Password WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("SQL Error occurred: " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in data layer occurred: " + ex.Message);
            }
        }

        public int checkisActiveStatus(string guid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    string query =
                        @"SELECT isActive FROM LoginInfo WHERE GUID = @GUID;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Guid", guid);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred in Dll Occured : " + ex.Message);
            }
        }

    }
}