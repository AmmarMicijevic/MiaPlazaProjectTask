using System;

public class DateUtils
{
    public static string GetFutureDate(int daysToAdd)
    {
        DateTime futureDate = DateTime.Now.AddDays(daysToAdd);
        return futureDate.ToString("dd-MMM-yyyy");
    }
}
