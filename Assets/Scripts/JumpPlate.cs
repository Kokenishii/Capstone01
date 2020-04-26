using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    public float upForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.GetComponent<Rigidbody>().AddForce(new Vector3(0,upForce,0),ForceMode.Acceleration);
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, upForce, 0);
        }
    }
    
}
