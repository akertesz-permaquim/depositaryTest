﻿using License;
using System.Management;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class LicenseController
    {
        private const string PRODUCTNAME = "PRODUCTNAME";
        private const string TYPE = "TYPE";
        private const string BASIC = "BASIC";
        private const string FULL = "FULL";
        #region License

        // Check if a valid license file is available
        public static bool IsValidLicenseAvailable()
        {
            return Status.Licensed;
        }

        public static double GetLicenseRemainingDays()
        {
            return (License.Status.Expiration_Date.Date - DateTime.Now.Date).TotalDays;
        }


        public static bool CheckLicenseAttributes()
        {
            if (!ReadAdditonalLicenseInformation(PRODUCTNAME).Equals(GetHardwareID()))
            {
                return false;
            }
            if (!ReadAdditonalLicenseInformation(TYPE).Equals(BASIC)
                ||
                !ReadAdditonalLicenseInformation(TYPE).Equals(FULL)

                )
            {
                return false;
            }
            return true;
        }
        private static string ReadAdditonalLicenseInformation(string key)
        {
            string returnValue = string.Empty;

            return returnValue;
        }

        // Read additonal license information from a license license
        public static string ReadAdditonalLicenseInformation()
        {
            string result = String.Empty;


            // Check first if a valid license file is found
            if (License.Status.Licensed)
            {
                if (License.Status.Expiration_Date.Date > DateTime.Now.Date)
                {
                    // Read additional license information
                    for (int i = 0; i < License.Status.KeyValueList.Count; i++)
                    {
                        string key = License.Status.KeyValueList.GetKey(i).ToString();
                        string value = License.Status.KeyValueList.GetByIndex(i).ToString();

                        result += key + "=" + value + ";" + Environment.NewLine;
                    }

                    result += " EXP = " + License.Status.Expiration_Date.ToLongDateString();
                    result += " HWID = " + License.Status.HardwareID;
                }
                else
                {
                    result = "Licensed expired at " + License.Status.Expiration_Date.ToShortDateString();
                }
            }
            else
            {
                result = "Not licensed";
            }

            return result;
        }
        // Check the license status of Evaluation Lock
        public static void CheckEvaluationLock()
        {
            bool lock_enabled = Status.Evaluation_Lock_Enabled;
            EvaluationType ev_type = License.Status.Evaluation_Type;
            int time = License.Status.Evaluation_Time;
            int time_current = License.Status.Evaluation_Time_Current;
        }

        // Check the license status of Expiration Date Lock
        public static void CheckExpirationDateLock()
        {
            bool lock_enabled = License.Status.Expiration_Date_Lock_Enable;
            System.DateTime expiration_date = License.Status.Expiration_Date;
        }
        // Check the license status of Number Of Uses Lock
        public static void CheckNumberOfUsesLock()
        {
            bool lock_enabled = License.Status.Number_Of_Uses_Lock_Enable;
            int max_uses = License.Status.Number_Of_Uses;
            int current_uses = License.Status.Number_Of_Uses_Current;
        }
        // Check the license status of Number Of Instances Lock
        public static void CheckNumberOfInstancesLock()
        {
            bool lock_enabled = License.Status.Number_Of_Instances_Lock_Enable;
            int max_instances = License.Status.Number_Of_Instances;
        }
        // Check the license status of Hardware Lock
        public static void CheckHardwareLock()
        {
            bool lock_enabled = License.Status.Hardware_Lock_Enabled;
            if (lock_enabled)
            {
                // Get Hardware ID which is stored inside the license file
                string lic_hardware_id = License.Status.License_HardwareID;
            }
        }
        // Get Hardware ID of the current machine
        public static string GetHardwareID()
        {
            return License.Status.HardwareID;
        }
        // Compare current Hardware ID with Hardware ID stored in License File
        public static bool CompareHardwareID()
        {
            if (License.Status.HardwareID == License.Status.License_HardwareID)
                return true;
            else
                return false;
        }
        // Invalidate the license. Please note, your protected software does not accept a license file anymore!
        public static void InvalidateLicense()
        {
            string confirmation_code = License.Status.InvalidateLicense();
        }
        // Check if a confirmation code is valid
        public static bool CheckConfirmationCode(string confirmation_code)
        {
            return License.Status.CheckConfirmationCode(License.Status.HardwareID,
            confirmation_code);
        }
        // Reactivate an invalidated license.
        public static bool ReactivateLicense(string reactivation_code)
        {
            return License.Status.ReactivateLicense(reactivation_code);
        }
        // Load the license.
        public static void LoadLicense(string filename)
        {
            License.Status.LoadLicense(filename);
        }
        // Load the license.
        public static void LoadLicense(byte[] license)
        {
            License.Status.LoadLicense(license);
        }
        // Get the license.
        public static byte[] GetLicense()
        {
            return License.Status.License;
        }
        #endregion

        #region Hardware Id
        public static string GetHardwareId()
        {
            string processorId = string.Empty;

            var processorManagementObjectSearcher = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection processorList = processorManagementObjectSearcher.Get();

            foreach (ManagementObject item in processorList)
            {
                processorId += item["ProcessorId"].ToString();
                break;
            }

            string motherBoardId = string.Empty;

            var motherBoardObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            ManagementObjectCollection motherBoardList = motherBoardObjectSearcher.Get();
   
            foreach (ManagementObject item in motherBoardList)
            {
                motherBoardId += item["SerialNumber"].ToString();
                break;
            }
            return processorId + "-" + motherBoardId;
        }
        #endregion
    }
}
