using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    float timer;
    bool dealDamage = false;
    GameObject p1;
    GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.1f;
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            dealDamage = true;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (dealDamage)
        {
            if (collision.gameObject.tag == "Body1")
            {


                GameObject dead = GameObject.Find("Deadbox");
                dead.GetComponent<DeadBox>().hp1 -= 5;
                //GameObject.Destroy(this.gameObject);
                //print("hit1");
                p1.GetComponent<Rigidbody>().AddForce((p1.transform.position - transform.position).normalized * 500f, ForceMode.Impulse);
                dealDamage = false;
                timer = 0.1f;
            }

            if (collision.gameObject.tag == "Body2")
            {

                GameObject dead = GameObject.Find("Deadbox");
                p2.GetComponent<Rigidbody>().AddForce((p2.transform.position - transform.position).normalized * 500f, ForceMode.Impulse);
                dead.GetComponent<DeadBox>().hp2 -= 5;
                //GameObject.Destroy(this.gameObject);
                // print("hit2");
                dealDamage = false;
                timer = 0.1f;

            }

        }

        
    }
}
