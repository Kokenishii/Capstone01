using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KneeScript : MonoBehaviour
{
    public string pNumber = "1";
    Rigidbody rb;
    public float speed = 20;
    public float offset = 0;
    public float freq = 10;
    public GameObject body;
    //public GameObject footParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        //body = GameObject.Find("Body" + pNumber);
    }

    // Update is called once per frame
    void Update()
    {


        pNumber = body.GetComponent<Controll_Shoot>().pNumber;
        if (gameObject.transform.parent = null)
        {
            pNumber = "0";
        }
        bool myPlayerWalking = Mathf.Abs(Input.GetAxis("Horizontal" + pNumber)) > 0 || Mathf.Abs(Input.GetAxis("Vertical" + pNumber)) > 0;
        bool isGrounded = body.GetComponent<Controll_Shoot>().isGrounded;
        if (myPlayerWalking)
        {
            Vector3 vel = new Vector3(0, Mathf.Sin((Time.time + offset * Time.deltaTime) * freq), 0);
            //rb.velocity += vel * speed *Time.deltaTime;
            rb.AddForce(vel * speed, ForceMode.Acceleration);


        }



      
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag=="floor")
    //    {
    //        footParticle.SetActive(true);
    //    }
     
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "floor")
    //    {
    //        footParticle.SetActive(false);
    //    }
    //}
}
