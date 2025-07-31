using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WindowWasherSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] windowWasherEnemies;
    [SerializeField] GameObject cleanPoint;
    Vector2[] cleanPointPlaces;
    Queue<Vector2> activeCleanPlaces = new Queue<Vector2>();
    bool pointIsActive;
    float enemyBuildingSide;
    int cleanPointPlace;
    [SerializeField] float [] vertical;
    [SerializeField] float [] horizontal;
    Vector2 place;
    [SerializeField] float maxPlacesCount;
    Vector2 playerVector;

    [SerializeField] GameObject player;
    void Start()
    {
       

        cleanPointPlaces = new Vector2[vertical.Length*horizontal.Length];

        for (int t = 0; t < horizontal.Length; t++)
        {
            for (int j = 0; j < vertical.Length; j++)
            {
                place = new Vector2(horizontal[t], vertical[j]);
                cleanPointPlaces[j+(t* vertical.Length)] = place;
                    
            }
        }
        ÑleanPointSpawn();
        StartCoroutine(EnemySpawn());        
    }

    private void ÑleanPointSpawn()
    {

        for (int i = 0; i < maxPlacesCount; i++)
        {
            cleanPointPlace = Random.Range(0, cleanPointPlaces.Length);
            if (activeCleanPlaces.Contains(cleanPointPlaces[cleanPointPlace]))
            {
                i--;                
            }
            else
            {
                activeCleanPlaces.Enqueue(cleanPointPlaces[cleanPointPlace]);
            }
        }
        foreach (var item in activeCleanPlaces)
        {
            Instantiate(cleanPoint, item, transform.rotation);
        }

    }

    private IEnumerator EnemySpawn()
    {

        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 0.9f));
            enemyBuildingSide = Random.value < 0.5f ? 19 : -19;
            playerVector.y = player.transform.position.y+Random.Range(6, -6);

            if (enemyBuildingSide > 0)
            {
                Instantiate(windowWasherEnemies[Random.Range(0, windowWasherEnemies.Length)], new Vector2(enemyBuildingSide, playerVector.y), transform.rotation);
            }
            else
            {
                Instantiate(windowWasherEnemies[Random.Range(0, windowWasherEnemies.Length)], new Vector2(enemyBuildingSide, playerVector.y), transform.rotation);
            }

        }
    }

}
