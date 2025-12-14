using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AppleFarmPlayerScript : MonoBehaviour
{
    private ImputHandlerScript imputHandler;
    private Vector2 mousePos;
    private float wormHolesCount;
    private Collider2D usefulObject;
    private Collider2D expendableObject;
    private bool paintInHand;
    private bool stickerInHand;
    private bool handIsFree;
    private GameObject apple;
    private float paintingProgress;
    private SpriteRenderer appleMask;
    private AppleFarmStickerScript appleFarmStickerScript; 


    [SerializeField] private UnityEvent spawnWormHoles;
    [SerializeField] private UnityEvent applePainting;
    [SerializeField] private UnityEvent applyingSticker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imputHandler = ImputHandlerScript.Instance;
        apple = GameObject.FindGameObjectWithTag("PointsObject");
        apple.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePos;
        wormHolesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }
    private void FixedUpdate()
    {
        if (paintInHand && imputHandler.GetRMB()!=0) 
        {
            usefulObject.transform.position = gameObject.transform.position;
        }
        if (stickerInHand && imputHandler.GetRMB() != 0)
        {
            expendableObject.transform.position = gameObject.transform.position;
        }        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Spawner" && imputHandler.GetLMB() != 0 && !paintInHand && wormHolesCount <= 0 && apple.activeInHierarchy == false)
        {
            apple.SetActive(true);
            spawnWormHoles.Invoke();
        }
        if (other.tag == "PointsObject" && InsideColl(gameObject.GetComponent<Collider2D>(),other)) 
        {
            appleMask = other.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            paintingProgress = appleMask.color.a;
        }
        if (other.tag == "PointsObject" && imputHandler.GetLMB() != 0 && paintInHand)
        {
            applePainting.Invoke();
        }
        else if (other.tag == "PointsObject" && imputHandler.GetLMB() != 0 && !paintInHand && wormHolesCount <= 0 && paintingProgress >= 1)
        {
            apple.SetActive(false);
        }

        if (other.tag == "UsefulObject" && handIsFree)
        {
            usefulObject = other;
            paintInHand = true;
            handIsFree = false;
        }
        else if (other.tag == "ExpendableObject" && handIsFree)
        {
            expendableObject = other;
            stickerInHand = true;
            handIsFree = false;
            if (stickerInHand && imputHandler.GetLMB() != 0)
            {
                Debug.Log(1);
                applyingSticker.Invoke();
            }
        }

    }
    bool InsideColl (Collider2D mycoll, Collider2D other)
    {
        if (other.bounds.Contains(mycoll.bounds.min) && other.bounds.Contains(mycoll.bounds.max))
        return true;
        else
        return false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "UsefulObject")
        {
            paintInHand = false;
            handIsFree = true;
        }
        if (other.tag == "ExpendableObject")
        {
            stickerInHand = false;
            handIsFree = true;
        }
    }


}
