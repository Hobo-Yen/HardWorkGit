using UnityEngine;

public class SpawnerAppleFarmScript : MonoBehaviour
{
    [SerializeField] private GameObject[] wormsHoles;
    [SerializeField] private GameObject sticker;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private Vector2 stickerSpawnPosition;
    [SerializeField] private float spawnCircle;
    [SerializeField] private float [] wormsHolesCounts;
    [SerializeField] private float wormsHolesCount;
    // Start is called before the first frame update


    public void Spawn()
    {
        wormsHolesCount = wormsHolesCounts[Random.Range(0, wormsHolesCounts.Length)];
        for (int i = 0; i < wormsHolesCount; i++)
            Instantiate(wormsHoles[Random.Range(0, wormsHoles.Length)], spawnPosition + Random.insideUnitCircle * spawnCircle, Quaternion.identity);
        for (int i = 0; i < wormsHolesCount; i++)
            Instantiate(sticker, stickerSpawnPosition, Quaternion.identity);

    }
}
