using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugHelper
{
    public static string successColor = "#80ff00";
    public static string logColor = "#ffffff";
    public static string errorColor = "#ff2600";
    public static string warningColor = "#ffb60a";

    public static void Log(object text, string color = "white")
    {
        Debug.Log(string.Format("<b><color={0}><i>{1}</i></color></b>\n", color, text.ToString()));
    }
}
