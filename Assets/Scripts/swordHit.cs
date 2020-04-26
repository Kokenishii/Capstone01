using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour
{
    public string pNumber = "1";
    bool canHit = true;
    public int damage = 50;
    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // print("swordalive");
    }
    void OnEnable()
    {
        canHit = true;
    }

   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "bullet")
        {
            GameObject.Destroy(collision.gameObject);
        }
        if (!canHit)
        {
            return;
        }
        if (pNumber == "1")
        {
            if (collision.gameObject.tag == "Body2")
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
                GameObject dead = GameObject.Find("Deadbox");
                dead.GetComponent<DeadBox>().hp2 -= damage;
                // GameObject.Destroy(this.gameObject);

            }
        }

        if (pNumber == "2")
        {
            if (collision.gameObject.tag == "Body1")
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*force,ForceMode.Impulse);
                GameObject dead = GameObject.Find("Deadbox");

                dead.GetComponent<DeadBox>().hp1 -= damage;
                //GameObject.Destroy(this.gameObject);

            }
        }
    }

 
}
