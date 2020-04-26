using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KneeScript : MonoBehaviour
{
    public string pNumber = "1";
    Rigidbody rb;
    public float speed = 20;
    public float offset = 0;

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
            Vector3 vel = new Vector3(0, speed * Mathf.Sin(Time.time * 20 + offset), 0);
            rb.velocity += vel * speed;
    }
}
}
