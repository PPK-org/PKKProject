﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    
    private float speed = 0;
    public float nextWaypointDistance = 0.5f;

    public Transform enemyGFX;
    
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    bool range = false;

    public float  getSpeed(){
        return this.speed;
    }

    public void setSpeed(float speedset){
        this.speed = speedset;
    }
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone()){
            
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null){
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * getSpeed() * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }

        if(force.x >= 0.01f){
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        } else if(force.x <= -0.01f){
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    
}
