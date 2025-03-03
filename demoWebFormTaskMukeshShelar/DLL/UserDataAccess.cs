using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace demoWebFormTaskMukeshShelar.DLL
{

      /// <summary>
    /// Defines the <see cref="UserDataAccess" />
    /// </summary>
  
    public class UserDataAccess

    {
        /// <summary>
        /// The CheckUserValidity
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="password">The password<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
      
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

        /// <summary>
        /// The UserDataInsert
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="firstName">The firstName<see cref="string"/></param>
        /// <param name="lastName">The lastName<see cref="string"/></param>
        /// <param name="mobileNumber">The mobileNumber<see cref="string"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="gender">The gender<see cref="string"/></param>
        /// <param name="maritalStatus">The maritalStatus<see cref="string"/></param>
        /// <param name="remarks">The remarks<see cref="string"/></param>
        /// <param name="dob">The dob<see cref="DateTime"/></param>
        /// <param name="age">The age<see cref="int"/></param>
        /// <param name="state">The state<see cref="string"/></param>
        /// <param name="city">The city<see cref="string"/></param>
        /// <param name="password">The password<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
      
        public string UserDataInsert(string userId, string firstName, string lastName, string mobileNumber, string email, string gender, string maritalStatus, string remarks, DateTime dob, int age, string state, string city, string password)
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
                        new SqlParameter("@state", SqlDbType.Int) { Value = state},
                        new SqlParameter("@city", SqlDbType.Int) { Value = city},
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

        /// <summary>
        /// The FetchAllUsers
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
       
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

        /// <summary>
        /// The insertDocument
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="document">The document<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
       
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

        /// <summary>
        /// The insertTifDocument
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="tifdocumentname">The tifdocumentname<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
       
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

        /// <summary>
        /// The StoreUserLoginInfo
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="Guid">The Guid<see cref="string"/></param>
        /// <param name="SourcePage">The SourcePage<see cref="string"/></param>
        /// <param name="CreatedOn">The CreatedOn<see cref="DateTime"/></param>
        /// <param name="isActive">The isActive<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
       
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

        /// <summary>
        /// The fetchUserBasedOnUserId
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
       
        public DataSet fetchUserBasedOnUserId(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    string queryToFetchUserDetails = "select FirstName , LastName , DOB , Email  , MobileNumber, MaritalStatus ,Gender, Age ,state ,city, Remarks from registrationtable where userId = @userId";
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

        /// <summary>
        /// The updateUserData
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="newUserId">The newUserId<see cref="string"/></param>
        /// <param name="FirstName">The FirstName<see cref="string"/></param>
        /// <param name="LastName">The LastName<see cref="string"/></param>
        /// <param name="mobileNumber">The mobileNumber<see cref="string"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="gender">The gender<see cref="string"/></param>
        /// <param name="maritalStatus">The maritalStatus<see cref="string"/></param>
        /// <param name="remarks">The remarks<see cref="string"/></param>
        /// <param name="dob">The dob<see cref="DateTime"/></param>
        /// <param name="state">The state<see cref="string"/></param>
        /// <param name="city">The city<see cref="string"/></param>
        /// <param name="age">The age<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        
        public string updateUserData(string userId, string newUserId, string FirstName, string LastName, string mobileNumber, string email, string gender, string maritalStatus, string remarks, DateTime dob, string state, string city, int age)
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
                        new SqlParameter("@NewUserId", SqlDbType.NVarChar) { Value = newUserId },
                        new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = FirstName },
                        new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = LastName },
                        new SqlParameter("@MobileNumber", SqlDbType.NVarChar) { Value = mobileNumber },
                        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                        new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = gender},
                        new SqlParameter("@MaritalStatus", SqlDbType.NVarChar) { Value = maritalStatus},
                        new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = remarks},
                        new SqlParameter("@DOB", SqlDbType.Date) { Value = dob },
                        new SqlParameter("@state", SqlDbType.NVarChar) { Value = state },
                        new SqlParameter("@city", SqlDbType.NVarChar) { Value = city },
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

        /// <summary>
        /// The forgotPasswordCheckUserCriteria
        /// </summary>
        /// <param name="mobileNumber">The mobileNumber<see cref="string"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        
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

        /// <summary>
        /// The UpdatePassword
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="newPassword">The newPassword<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        
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

        /// <summary>
        /// The CheckIsActiveStatus
        /// </summary>
        /// <param name="guid">The guid<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
     
        public int CheckIsActiveStatus(string guid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    // Update query to include both GUID and TabGuid
                    string query = @"
                SELECT isActive 
                FROM LoginInfo 
                WHERE GUID = @GUID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters for both GUID and TabGuid
                        cmd.Parameters.AddWithValue("@GUID", guid);

                        // Execute the query
                        object result = cmd.ExecuteScalar();

                        // Check if a result was returned and parse it
                        if (result != DBNull.Value && result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            // If no matching record, return 0 (inactive)
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                throw new Exception("Error occurred in CheckIsActiveStatus: " + ex.Message);
            }
        }

        /// <summary>
        /// The fetchActiveUsers
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
      
        public DataTable fetchActiveUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "fetchActiveUsersDetails");
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

        /// <summary>
        /// The GetStates
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
       
        public DataTable GetStates()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreCityState"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "fetchState");
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching states: " + ex.Message);
            }
        }

        /// <summary>
        /// The GetCitiesByState
        /// </summary>
        /// <param name="stateId">The stateId<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
     
        public DataTable GetCitiesByState(int stateId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreCityState"].ConnectionString))
                {
                    conn.Open();
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@StateID", stateId)
                    };
                    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "fetchCity", parameters);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cities: " + ex.Message);
            }
        }

        /// <summary>
        /// The updateIsactiveStatus
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        
        public bool updateIsactiveStatus(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["webformregistrationtable"].ConnectionString))
                {
                    conn.Open();

                    string query = "UPDATE LoginInfo SET isActive = 0 WHERE userId = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

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
    }
}
