using UnityEngine;

public class AppleFarmStickerScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private bool canBePickedUp;
    [SerializeField] private GameObject pointsObject;
    private Collider2D wormsHole;
    private bool rightTarget;

    private void Start()
    {
        canBePickedUp = true;
        pointsObject = GameObject.FindGameObjectWithTag("PointsObject");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Enemy" && canBePickedUp)
        {
            sprite.color = Color.red;
        }
        else if (other.tag == "Enemy" && InsideColl(gameObject.GetComponent<Collider2D>(), other))
        {
            sprite.color= Color.green;
            if (ImputHandlerScript.Instance.GetLMB() != 0)
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<Collider2D>().enabled = false;
                canBePickedUp = false;
            }            
        }       
    }
    bool InsideColl(Collider2D mycoll, Collider2D other)
    {
        if (mycoll.bounds.Contains(other.bounds.min) && mycoll.bounds.Contains(other.bounds.max))
            return true;
        else
            return false;
    }
    private void Update()
    {
        if (pointsObject.active == false)
        {
            Destroy(gameObject);
        }
    }
}
