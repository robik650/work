﻿using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject player; 
    private Vector3 offset;  

    void Start () 
    {        
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate () 
    {        
        transform.position = player.transform.position + offset;
    }
}
