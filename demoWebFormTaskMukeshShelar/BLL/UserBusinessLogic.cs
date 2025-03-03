using demoWebFormTaskMukeshShelar.DLL;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace demoWebFormTaskMukeshShelar.BLL
{

    /// <summary>
    /// Defines the <see cref="UserBusinessLogic" />
    /// </summary>
   
    public class UserBusinessLogic
    {
        /// <summary>
        /// Defines the _dataAccess
        /// </summary>
        
        private UserDataAccess _dataAccess = new UserDataAccess();

        /// <summary>
        /// The UserLogin
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="password">The password<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        
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

        /// <summary>
        /// The RegisterUserData
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
        
        public string RegisterUserData(string userId, string firstName, string lastName, string mobileNumber, string email, string gender,string maritalStatus, string remarks, DateTime dob, int age, string state, string city, string password)
        {
            try
            {
                string result = _dataAccess.UserDataInsert(userId, firstName, lastName, mobileNumber, email, gender, maritalStatus, remarks, dob, age, state, city, password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        /// <summary>
        /// The GetUsers
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        
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
                return _dataAccess.insertDocument(userId, document);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
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
                return _dataAccess.insertTifDocument(userId, tifdocumentname);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        /// <summary>
        /// The StoreLoginInfo
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="Guid">The Guid<see cref="string"/></param>
        /// <param name="SourcePage">The SourcePage<see cref="string"/></param>
        /// <param name="CreatedOn">The CreatedOn<see cref="DateTime"/></param>
        /// <param name="isActive">The isActive<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        
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

        /// <summary>
        /// The fetchUserBasedOnUserId
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        
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

        /// <summary>
        /// The updateUserData
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="newUserId">The newUserId<see cref="string"/></param>
        /// <param name="firstName">The firstName<see cref="string"/></param>
        /// <param name="lastName">The lastName<see cref="string"/></param>
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
        
        public string updateUserData(string userId, string newUserId, string firstName,
                                     string lastName, string mobileNumber, string email, string gender,
                                     string maritalStatus, string remarks, DateTime dob, string state, string city, int age)
        {
            try
            {
                return _dataAccess.updateUserData(userId, newUserId, firstName, lastName, mobileNumber, email, gender, maritalStatus, remarks, dob, state, city, age);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BLL occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// The ValidateUserAndUpdatePassword
        /// </summary>
        /// <param name="mobileNumber">The mobileNumber<see cref="string"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="newPassword">The newPassword<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        
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

        /// <summary>
        /// The IsSessionValid
        /// </summary>
        /// <param name="guid">The guid<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        
        public int IsSessionValid(string guid)
        {
            try
            {
                return _dataAccess.CheckIsActiveStatus(guid);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BLL Occured : " + ex.Message);
            }
        }

        /// <summary>
        /// The GetActiveUsersList
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        
        public DataTable GetActiveUsersList()
        {
            try
            {
                return _dataAccess.fetchActiveUsers();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        /// <summary>
        /// The Encrypt
        /// </summary>
        /// <param name="clearText">The clearText<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        
        public string Encrypt(string clearText)
        {
            string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];

            clearText = clearText ?? throw new ArgumentNullException("clear text is null");

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// The Decrypt
        /// </summary>
        /// <param name="cipherText">The cipherText<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];

            cipherText = cipherText ?? throw new ArgumentNullException("cipherText is null");

            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        /// <summary>
        /// The GetStates
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        
        public DataTable GetStates()
        {
            try
            {
                return _dataAccess.GetStates();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
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
                return _dataAccess.GetCitiesByState(stateId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Bll occured : " + ex.Message);
            }
        }

        /// <summary>
        /// The updateIsActiveStatus
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        
        public bool updateIsActiveStatus(string userId)
        {
            try
            {
                return _dataAccess.updateIsactiveStatus(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BLL occurred : " + ex.Message);
            }
        }
    }
}
