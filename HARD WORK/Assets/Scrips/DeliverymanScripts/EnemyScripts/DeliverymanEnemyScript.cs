using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverymanEnemyScript : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float enemySpeedModifier;
    [SerializeField] float liveTime;
    Rigidbody2D enemyRb;
    Vector2 enemyScale;

    void Start()
    {
        if (transform.position.x <= 0)
        {
            enemyScale = transform.localScale;
            enemyScale.y *= -1;
            transform.localScale = enemyScale;
        }

        enemyRb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
        Vector2 moveY = new Vector2(0, enemySpeed);
        if (transform.position.x >= 0)
        {
            enemyRb.MovePosition(enemyRb.position + moveY * Time.fixedDeltaTime);
        }
        else if (transform.position.x <= 0)
        {
            enemyRb.MovePosition(enemyRb.position - moveY * enemySpeedModifier * Time.fixedDeltaTime);
        }
        liveTime -= 1 * Time.fixedDeltaTime;
        if (liveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
