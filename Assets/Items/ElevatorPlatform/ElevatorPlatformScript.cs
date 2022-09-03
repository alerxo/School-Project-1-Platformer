using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatformScript : MonoBehaviour
{
    private Transform elevator;

    private Transform endObj;
    private Transform startObj;

    private Transform target;

    [SerializeField]
    private float speed = 1;

    private void Start()
    {
        elevator = transform.GetChild(0);
        startObj = transform.GetChild(1);
        endObj = transform.GetChild(2);

        target = endObj;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var step = speed / 10 * Time.deltaTime;

        elevator.position = Vector2.MoveTowards(elevator.position, target.position, step);

        if (elevator.position == target.position) ChangeTarget();
    }

    private void ChangeTarget()
    {
        if (target == startObj) target = endObj;
        else if (target == endObj) target = startObj;
    }
}