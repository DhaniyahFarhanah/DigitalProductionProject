using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float agroRange;
    [SerializeField] private float movespeed;

    [SerializeField] private bool triggerAgro;

    public GameObject[] Waypoints;
    int nextWayPoint = 0;
    float distToWaypoint; 

    public SpriteRenderer spriteRenderer;
    public Sprite wakeUp;
    public Rigidbody2D rb2d;
  

    // Start is called before the first frame update
    void Start()
    {
        triggerAgro = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist2player = Vector2.Distance(transform.position, player.position);
        Debug.Log("dist2player: " + dist2player);

        if (dist2player < agroRange)
        {
            //code to wake up
            WakeUp();
        }
        
        if(dist2player < 4)
        {
            //walkOnWall
            triggerAgro = true;

        }

        if(triggerAgro == true)
        {
            WalkOnWall();
        }

        else
        {
            //stop chasing player
        }
    }

    void WakeUp()
    {
        spriteRenderer.sprite = wakeUp;
    }

    void WalkOnWall()
    {
        CheckWall();
    }

    void CheckWall()
    {
        distToWaypoint = Vector2.Distance(transform.position, Waypoints[nextWayPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWayPoint].transform.position, movespeed * Time.deltaTime);

        if (distToWaypoint < 0.25)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += Waypoints[nextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;

        ChooseNextWayPoint();
    }

    void ChooseNextWayPoint()
    {
        nextWayPoint++;

        if(nextWayPoint == Waypoints.Length)
        {
            nextWayPoint = 0;
        }
    }


}
