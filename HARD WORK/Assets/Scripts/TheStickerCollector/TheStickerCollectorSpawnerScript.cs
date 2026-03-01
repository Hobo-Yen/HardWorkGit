using UnityEngine;
using UnityEngine.UIElements;

public class TheStickerCollectorSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject [] stickerPrefabs;
    [SerializeField] private GameObject apple;
    [SerializeField] private float stickersCount;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float spawnCircle;
    [SerializeField] private float[] stickersCounts;
    private Quaternion spawnRotation;

    public void Spawn()
    {
        if (!apple.activeSelf)
        {
            apple.SetActive(true);
            stickersCount = stickersCounts[Random.Range(0, stickersCounts.Length)];
            for (int i = 0; i < stickersCount; i++)
            {
                spawnRotation = Quaternion.Euler(1, 1, Random.Range(0.0f, 360.0f));
                Instantiate(stickerPrefabs[Random.Range(0, stickerPrefabs.Length)], spawnPosition + Random.insideUnitCircle * spawnCircle, spawnRotation);
            }
        }
    }



}
