/*
 * ProjectEuler.net
 * Question 19: Counting Sundays
 * Description: Compute the number of Sundays that fell on the first of the month in the twentieth century
 * Author:      Otto Lau
 * Date:        December 22, 2015
 */

using System;

namespace PE019_Counting_Sundays
{
    class PE019_Counting_Sundays
    {
        const int DAYS_IN_WEEK = 7;

        static void Main(string[] args)
        {
            // Initial date
            Month currentMonth = Month.January;
            int currentDay = 1;
            int currentYear = 1900;
            DayOfWeek currentDayOfWeek = DayOfWeek.Monday;

            // Year to start counting Sundays
            int startYear = 1901;

            // End date
            Month endMonth = Month.December;
            int endYear = 2000;

            int countSundays = 0;

            while (currentMonth <= endMonth && currentYear <= endYear)
            {
                Console.WriteLine("{0} {1} {2}, {3}", currentDayOfWeek, currentMonth, currentDay, currentYear);

                // Calculate the remaining days to the 1st of the next month after the last full week
                //  counting from the 1st of the current month
                int remainderDays = GetDaysInMonth(currentMonth, currentYear) % DAYS_IN_WEEK;

                // Calculate the day of the week for the first day of the next month
                int dayOfWeekNextMonth = ((int)currentDayOfWeek + remainderDays) % 7;
                currentDayOfWeek = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), dayOfWeekNextMonth);

                // Count the 1sts of the months that fall on a Sunday
                // Count the Sundays within January 1, 1901 to December 31, 2000
                if (currentYear >= startYear && currentDayOfWeek == DayOfWeek.Sunday)
                {
                    countSundays++;
                }

                // Increment month (increment year if necessary)
                currentMonth++;
                if ((int)currentMonth > 12)
                {
                    currentMonth = Month.January;
                    currentYear++;
                }
            }

            Console.WriteLine("Number of Sundays: {0}", countSundays);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Get the number of days of the month in the specified year.
        /// </summary>
        /// <param name="currentMonth">Month to get the number of days of.</param>
        /// <param name="currentYear">Year the month is in.</param>
        /// <returns>The number of days in that month of the year.</returns>
        /// 
        public static int GetDaysInMonth(Month currentMonth, int currentYear)
        {
            switch (currentMonth)
            {
                case Month.January:
                    return 31;
                case Month.February:
                    if (currentYear % 4 == 0)
                    {
                        if (currentYear % 100 == 0 && currentYear % 400 != 0)
                        {
                            return 28;
                        }
                        else
                        {
                            return 29;
                        }
                    }
                    else
                    {
                        return 28;
                    }
                case Month.March:
                    return 31;
                case Month.April:
                    return 30;
                case Month.May:
                    return 31;
                case Month.June:
                    return 30;
                case Month.July:
                    return 31;
                case Month.August:
                    return 31;
                case Month.September:
                    return 30;
                case Month.October:
                    return 31;
                case Month.November:
                    return 30;
                case Month.December:
                    return 31;
                default:
                    return 0;
            }
        }
    }


    /// <summary>
    /// Months of the year.
    /// </summary>
    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
        None
    }


    /// <summary>
    /// Days of the week.
    /// </summary>
    enum DayOfWeek
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}
