using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataScript : MonoBehaviour
{
    public int currentMoneyScore;
    public int currentStressLevel;
    public int currentDayOfweek;
    public int currentSaveNumber;

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this, currentSaveNumber); 
    }
    public void LoadPlayerData()
    {
        DataSave dataSave = SaveSystem.LoadPlayer(currentSaveNumber);
        
        currentMoneyScore = dataSave.moneyScore;
        currentDayOfweek = dataSave.dayOfWeek;
        currentStressLevel = dataSave.stressLevel;
        currentSaveNumber = dataSave.saveNamber;
    }
}
