using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBarkerSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] ArowsArray;
    [SerializeField] float[] arowLines;
    [SerializeField] string[] arowsCombos;
    float arowLine;
    int randomArgument;
    private List<int> carrentCombo;
    string comboBeforeConv;
    string comboStrArg;
    int comboIntArg;
    void Start()
    {
        StartCoroutine(ArowSpawn());        
    }
    private IEnumerator ArowSpawn()
    {

        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(4.4f);
            carrentCombo = new List<int>();
            randomArgument = UnityEngine.Random.Range(0, arowsCombos.Length);
            comboBeforeConv = arowsCombos[randomArgument];
            for (int i = 0; i < comboBeforeConv.Length; i++)
            {
                comboStrArg = Convert.ToString(comboBeforeConv[i]);
                comboIntArg = Convert.ToInt32(comboStrArg);
                carrentCombo.Add(comboIntArg);
            }
            StartCoroutine(ComboStart());
            
        }
    }
    private IEnumerator ComboStart()
    {
       
        foreach (var line in carrentCombo)
        {
            arowLine = arowLines[line];
            Instantiate(ArowsArray[line], new Vector2(arowLine, 7.0f), transform.rotation);
            yield return new WaitForSeconds(0.6f);
        }
    }
}
