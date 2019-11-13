using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public float waterForce = 25f;

    bool steppedOn = false;
    GameObject stepper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (steppedOn)
        {
            transform.position = stepper.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag=="Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(waterForce * other.transform.forward, ForceMode.Impulse);
            steppedOn = true;
            stepper = other.gameObject;
            print(stepper);
           GameObject.Destroy(this.gameObject);
        }

    }
}
