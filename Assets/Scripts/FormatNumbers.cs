using UnityEngine;

public static class FormatNumbers
{
    public static string[] formatName = new[]
    {
        "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "UDc", "DDc", "TDc", "QaDc"
    };

    public static string FormatNumber(float num)
    {
        if (num == 0)
        {
            return "0";
        }

        int i = 0;
        while (i + 1 < formatName.Length && num >= 1000f)
        {
            num /= 1000f;
            i++;
        }

        return num.ToString("#.##") + formatName[i];
    }
}
