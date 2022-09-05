using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private List<Transform> targetList;
    private int currentTarget = 0;

    private Transform target;

    [SerializeField]
    private float speed = 1;

    private void Start()
    {
        target = targetList[currentTarget];
    }

    private void FixedUpdate()
    {
        if (targetList.Count > 0) Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SendMessage("DmgTaken", damage);
        }
    }

    private void Movement()
    {
        var step = speed / 10 * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

        if (transform.position == target.position) ChangeTarget();
    }

    private void ChangeTarget()
    {
        currentTarget++;

        if (currentTarget == targetList.Count) currentTarget = 0;

        target = targetList[currentTarget];
    }
}
