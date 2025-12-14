using Unity.VisualScripting;
using UnityEngine;

public class ExtractPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PointsObject")
        {
            Destroy(collision.gameObject);
        }
    }
}
