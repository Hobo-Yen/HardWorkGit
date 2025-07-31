using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPlaceScript : MonoBehaviour
{
    [SerializeField] float placeSpeed;
    [SerializeField] float liveTime;
    Rigidbody2D deliveryPlaceRb;

    void Start()
    {
        deliveryPlaceRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveY = new Vector2(0, placeSpeed);
        deliveryPlaceRb.MovePosition(deliveryPlaceRb.position - moveY * Time.fixedDeltaTime);
        liveTime -= 1* Time.fixedDeltaTime;
        if (liveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
