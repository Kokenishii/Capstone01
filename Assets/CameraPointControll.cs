﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointControll : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player1;
    GameObject player2;
    public float lerpNum = 0.2f;
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && player2 != null)
        {

           Vector3 lookAt = (player1.transform.position + player2.transform.position) / 2f;
            transform.position = Vector3.Lerp(transform.position, lookAt, lerpNum);
        }

    }
}