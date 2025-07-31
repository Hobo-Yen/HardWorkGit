using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWasherEnemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float enemySpeedModifier;
    [SerializeField] float liveTime;
    Rigidbody2D enemyRb;
    Vector2 enemyScale;

    void Start()
    {
        if (transform.position.x >= 0)
        {
            enemyScale = transform.localScale;
            enemyScale.x *= -1;
            transform.localScale = enemyScale;
        }

        enemyRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        Vector2 moveX = new Vector2(enemySpeed, 0);
        if (enemyScale.x >= 0)
        {
            enemyRb.MovePosition(enemyRb.position + moveX * enemySpeedModifier * Time.fixedDeltaTime);
        }
        else if (enemyScale.x <= 0)
        {
            enemyRb.MovePosition(enemyRb.position - moveX * enemySpeedModifier * Time.fixedDeltaTime);
        }
        liveTime -= 1 * Time.fixedDeltaTime;
        if (liveTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
