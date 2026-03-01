using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TheStickerCollectorStickerScript : MonoBehaviour
{
    [SerializeField] private GameObject stickerBarr;
    [SerializeField] private Slider stickerSlider;
    private float slidderNewValue;
    float velocity;
    [SerializeField] private float maxVelosity;
    private void Start()
    {
        stickerSlider.value = 1;
        slidderNewValue = stickerSlider.value;
    }
    private void Update()
    {
        velocity = (stickerSlider.value - slidderNewValue) / Time.deltaTime;
        slidderNewValue = stickerSlider.value;
        if (velocity != 0)
        {
            Debug.Log(velocity);
        }
        if (math.abs(velocity) > maxVelosity && stickerBarr.activeSelf)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            stickerBarr.SetActive(true);
        }
        if (stickerSlider.value <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stickerBarr.SetActive(false);
            stickerSlider.value = 1;
        }
    }
}
