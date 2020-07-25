using System;

namespace SafeAutoCodeKata
{
    public static class Transactions
    {
        /// <summary>
        /// Check name string
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool CheckNames(string Name)
        {
            bool isvalidName = false;
            try
            {
                isvalidName = !String.IsNullOrEmpty(Name);
            }
            catch
            {
                new InvalidCastException("Name is invalid");
            }
            return isvalidName;
        }

        /// <summary>
        /// Validate hour data
        /// </summary>
        /// <param name="Hour"></param>
        /// <returns></returns>
        public static bool CheckHour(string Hour)
        {
            bool isvaliddate = false;
            try
            {
                isvaliddate = DateTime.TryParse(Hour, out DateTime dt);
            }
            catch
            {
                new InvalidCastException("Hour is invalid");
            }
            return isvaliddate;
        }

        /// <summary>
        /// Validate that the initial time is less than the final time
        /// </summary>
        /// <param name="StartHour"></param>
        /// <param name="EndHour"></param>
        /// <returns></returns>
        public static bool ValidateHoursRange(string StartHour, string EndHour)
        {

            if (!TimeSpan.TryParse(StartHour, out TimeSpan startHour)) new InvalidCastException("Start hour is invalid");

            if (!TimeSpan.TryParse(EndHour, out TimeSpan endHour)) new InvalidCastException("End hour is invalid");

            if (startHour < TimeSpan.MinValue || startHour > TimeSpan.MaxValue) return false;

            if (endHour < TimeSpan.MinValue || endHour > TimeSpan.MaxValue) return false;

            if (endHour < startHour) return false;

            return true;
        }

        /// <summary>
        /// Validate milles data
        /// </summary>
        /// <param name="Milles"></param>
        /// <returns></returns>
        public static bool ValidateMilles(string Milles)
        {
            bool isValidNumber = false;
            try
            {
                isValidNumber = Double.TryParse(Milles, out double number);
            }
            catch
            {
                new InvalidCastException("Milles not valid");
            }
            return isValidNumber;
        }

        /// <summary>
        /// Calculates speed given start time, end time and miles traveled
        /// </summary>
        /// <param name="StarTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="Milles"></param>
        /// <returns></returns>
        public static double CalculateVelocity(string StarTime, string EndTime, string Milles)
        {
            double AverageVelocity = 0;
            try
            {
                Double TotalHoursTrip = DateTime.Parse(EndTime).Subtract(DateTime.Parse(StarTime)).TotalHours;
                AverageVelocity = (Double.Parse(Milles) / TotalHoursTrip);
            }
            catch
            {
                new ArgumentException("The speed could not be calculated");
            }

            return AverageVelocity;
        }

        /// <summary>
        /// Change the first letter of the string to uppercase
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToUpper(string str)
        {
            try
            {
                if (str == null)
                    return null;

                if (str.Length > 1)
                    return char.ToUpper(str[0]) + str.Substring(1);
            }
            catch
            {
                new ArgumentException("The speed could not be calculated");
            }

            return str.ToUpper();
        }
    }
}
