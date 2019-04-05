﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAvatar : MonoBehaviour
{
    float dirX;
    public float moveSpeed = 10f;



    
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + dirX * moveSpeed * Time.deltaTime, transform.position.y);
        
    }


}
