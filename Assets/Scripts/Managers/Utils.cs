using System;
using System.Globalization;
using UnityEngine;

public static class Utils
{
    public static void SetDateTime(string key, DateTime value)
    {
        string convertToStr = value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertToStr);
    }

    public static DateTime GetDateTime(string key, DateTime defaultValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return defaultValue;
        }
    }
}
