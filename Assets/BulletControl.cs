using System.Collections;
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
        rb.velocity = dir * bulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0){
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Body")
        {

            GameObject dead = GameObject.Find("Deadbox");
            dead.GetComponent<DeadBox>().score2 += 1;
            GameObject.Destroy(this.gameObject);
            print("hit2");
        }
        if (collision.gameObject.tag == "Body1")
        {

            GameObject dead = GameObject.Find("Deadbox");
            dead.GetComponent<DeadBox>().score1 += 1;
            GameObject.Destroy(this.gameObject);
            print("hit1");
        }
    }

}
