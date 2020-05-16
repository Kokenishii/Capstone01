using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointControll : MonoBehaviour
{
    CharacterJoint joint;
    public string pNnumber;
    bool isBroken = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        joint = gameObject.GetComponent<CharacterJoint>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pNnumber = GetComponentInParent<PuppetParent>().pNumber;
        if (joint == null && !isBroken)
        {

            GetComponentInParent<PuppetParent>().health -= 1;
      
            gameObject.transform.parent = null;
            isBroken = true;

        }

        if (GetComponentInParent<PuppetParent>().isReady == false)
        {
            joint.breakForce = 0;
            rb.mass = 10;
            isBroken=true;
            gameObject.transform.parent = null;

        }
    }
}
