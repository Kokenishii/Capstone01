using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMove : MonoBehaviour
{
    public string pNumber = "1";
    Rigidbody rb;
    public float speed = 20;
    public float offset = 0;
    public float freq = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool myPlayerWalking = Mathf.Abs(Input.GetAxis("Horizontal" + pNumber)) > 0 || Mathf.Abs(Input.GetAxis("Vertical" + pNumber)) > 0;
        if (myPlayerWalking)
        {
            Vector3 vel = new Vector3(0, 0, Mathf.Sin(((Time.time + offset) * Time.deltaTime) * freq));
            //rb.velocity += vel * speed *Time.deltaTime;
            //rb.AddForce(vel * speed, ForceMode.Acceleration);
            rb.AddRelativeForce(speed * vel, ForceMode.Acceleration);


        }
      
    }
}
