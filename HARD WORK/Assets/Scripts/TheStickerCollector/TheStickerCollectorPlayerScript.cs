using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class TheStickerCollectorPlayerScript : MonoBehaviour
{
    private ImputHandlerScript imputHandler;
    private Vector2 mousePos;
    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private UnityEvent spawn;
    bool canClick;

    void Start()
    {
        imputHandler = ImputHandlerScript.Instance;
    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePos;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Spawner" && imputHandler.GetLMBButton() == 1 && GameObject.FindGameObjectsWithTag("PointsObject").Length == 0)
        {
            spawn.Invoke();
        }
        if (collision.tag == "UsefulObject" && imputHandler.GetLMBButton() == 1 && GameObject.FindGameObjectsWithTag("PointsObject").Length == 0)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
