﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; 
    private Transform target; 
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);

    }
}
