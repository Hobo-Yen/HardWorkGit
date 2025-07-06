using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{
    public int moneyScore;
    public int dayOfWeek;
    public int stressLevel;
    public int saveNamber;

    public DataSave (PlayerDataScript playerDataScript)
    {
        moneyScore = playerDataScript.currentMoneyScore;
        dayOfWeek = playerDataScript.currentDayOfweek;
        stressLevel = playerDataScript.currentStressLevel;
        saveNamber = playerDataScript.currentSaveNumber;
    }
}
