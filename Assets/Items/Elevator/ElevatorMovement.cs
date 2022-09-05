using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private Transform elevator;

    [SerializeField]
    private List<Transform> targetList;
    private int currentTarget = 0;

    private Transform target;

    [SerializeField]
    private float speed = 1;

    private bool isMove = false;

    private void Start()
    {
        elevator = transform.GetChild(0);

        target = targetList[currentTarget];

    }

    private void FixedUpdate()
    {
        if (targetList.Count > 0 && isMove) Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) isMove = true;
    }

    private void Movement()
    {
        var step = speed / 10 * Time.deltaTime;

        elevator.position = Vector2.MoveTowards(elevator.position, target.position, step);

        if (elevator.position == target.position) ChangeTarget();
    }

    private void ChangeTarget()
    {
        currentTarget++;

        if (currentTarget == targetList.Count) currentTarget = 0;

        target = targetList[currentTarget];
    }
}