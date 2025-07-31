using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public enum Arrows
    {
        ArrowUp, ArrowDown, ArrowLeft, ArrowRight

    }
    [SerializeField] Arrows arrow;
    Rigidbody2D arrowRb;
    [SerializeField] float arrowSpeed;

    public Arrows ArowDirection { get { return arrow; } }

    private void Start()
    {
        arrowRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 moveY = new Vector2(0, arrowSpeed);
        arrowRb.MovePosition(arrowRb.position - moveY * Time.fixedDeltaTime);
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}
