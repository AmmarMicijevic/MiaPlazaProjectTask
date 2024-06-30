using System;
using System.Text;

public class RandomStringGenerator
{
    private static Random random = new Random();

    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder stringBuilder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }

    public static string GenerateRandomNumericString(int length)
    {
        const string digits = "0123456789";
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = digits[random.Next(digits.Length)];
        }

        return new string(result);
    }
}
