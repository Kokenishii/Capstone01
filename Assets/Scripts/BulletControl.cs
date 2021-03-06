﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Vector3 dir;
    public float bulletSpeed = 20f;
    public float bulletLife = 10f;
    public GameObject blood;
    public float bloodDistance = 0.2f;
    public int bloodCount = 15;
    public float bloodForce = 10f;

  
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = dir * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0){
            StartCoroutine(killSelf());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Body1")
        {

            GameObject dead = GameObject.Find("Deadbox");
            dead.GetComponent<DeadBox>().hp1 -= 5;
            //GameObject.Destroy(this.gameObject);
            //print("hit1");
        }
        
        if (collision.gameObject.tag == "Body2")
        {

            GameObject dead = GameObject.Find("Deadbox");
            dead.GetComponent<DeadBox>().hp2 -= 5;
           // GameObject.Destroy(this.gameObject);
           // print("hit2");
        }
       

    }

    IEnumerator killSelf()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(5);
        GameObject.Destroy(this.gameObject);
    }
}
