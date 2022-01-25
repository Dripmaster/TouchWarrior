using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    public static void saveData(string dataName, int v)
    {
        PlayerPrefs.SetInt(dataName,v);
        
    }

    public static int getData(string dataName)
    {
        return PlayerPrefs.GetInt(dataName,0);
    }
}
