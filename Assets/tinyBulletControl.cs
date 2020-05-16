using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinyBulletControl : MonoBehaviour
{
    public Vector3 dir;
    public float bulletSpeed = 200f;
    public float bulletLife = 2f;
    public string pNumber;

  


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
        if (bulletLife <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        //if (collision.gameObject.tag == "Body1")
        //{

        //    GameObject dead = GameObject.Find("Deadbox");
        //    dead.GetComponent<DeadBox>().hp1 -= 5;
        //    //GameObject.Destroy(this.gameObject);
        //    //print("hit1");
        //}

        //if (collision.gameObject.tag == "Body2")
        //{

        //    GameObject dead = GameObject.Find("Deadbox");
        //    dead.GetComponent<DeadBox>().hp2 -= 5;
        //    // GameObject.Destroy(this.gameObject);
        //    // print("hit2");
        //}

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.GetComponent<SphereCollider>().enabled = false;
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            if (other.gameObject.GetComponent<spiderControl>().pNumber != pNumber)
            {

                other.gameObject.GetComponent<spiderControl>().mode = 2;
            }

        }
    }

    IEnumerator killSelf()
    {
        yield return new WaitForSeconds(5);
        GameObject.Destroy(this.gameObject);
    }
}
