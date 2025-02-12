using demoWebFormTaskMukeshShelar.DLL;
using System;
using System.Data;
using static demoWebFormTaskMukeshShelar.DLL.UserDataAccess;

namespace demoWebFormTaskMukeshShelar.BLL
{
    public class UserBusinessLogic
    {
        private UserDataAccess _dataAccess = new UserDataAccess();

        public bool UserLogin(string userId, string password)
        {
            try
            {
                int userExists = _dataAccess.CheckUserValidity(userId, password);
                return userExists == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured: " + ex.Message);
            }
        }

        public string RegisterUserData(string userId, string firstName, string lastName, string mobileNumber, string email, string gender,
                                   string maritalStatus, string remarks, DateTime dob, int age, string password)
        {
            try
            {
                string result = _dataAccess.UserDataInsert(userId, firstName, lastName, mobileNumber, email, gender, maritalStatus, remarks, dob, age, password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }
       
        public DataTable GetUsers()
        {
            try
            {
                return _dataAccess.FetchAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        public int insertDocument(string userId, string document)
        {
            try
            {
                return _dataAccess.insertDocument(userId, document);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }


        public int insertTifDocument(string userId, string tifdocumentname)
        {
            try
            {
                return _dataAccess.insertTifDocument(userId, tifdocumentname);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        public int StoreLoginInfo(string userId, string Guid, string SourcePage, DateTime CreatedOn, int isActive)
        {
            try
            {
                return _dataAccess.StoreUserLoginInfo(userId, Guid, SourcePage, CreatedOn, isActive);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        public DataSet fetchUserBasedOnUserId(string userId)
        {
            try
            {
                return _dataAccess.fetchUserBasedOnUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        public string updateUserData(string userId, string FirstName, string LastName, string mobileNumber, string email, string gender,
                                    string maritalStatus, string remarks, DateTime dob, int age)
        {
            try
            {
                return _dataAccess.updateUserData(userId, FirstName, LastName, mobileNumber, email, gender, maritalStatus, remarks, dob, age);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        public string ValidateUserAndUpdatePassword(string mobileNumber, string email, string newPassword)
        {
            UserDataAccess userDataAccess = new UserDataAccess();

            // Check if user exists
            string validationResponse = userDataAccess.forgotPasswordCheckUserCriteria(mobileNumber, email);

            if (validationResponse == "User exists")
            {
                // Update password if the user exists
                bool isPasswordUpdated = userDataAccess.UpdatePassword(email, newPassword);

                if (isPasswordUpdated)
                {
                    return "Password updated successfully"; 
                }
                else
                {
                    throw new Exception("Failed to update the password.");
                }
            }
            else
            {
                return "User not found";
            }
        }

        public int IsSessionValid(string guid)
        {
            try
            {
                return _dataAccess.checkisActiveStatus(guid);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BLL Occured : " + ex.Message);
            }
        }

    }
}