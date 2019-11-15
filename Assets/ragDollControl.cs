using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ragDollControl : MonoBehaviour
{
    public GameObject banana;
    public GameObject grenade;
    public int bananaNum;
    public int grenadeNum = 1;

    public string pNumber = "1";
    Rigidbody rb;
    public float speed = 50;
    public float jumpForce = 500f;
    public bool isWalking = false;
    public float maxSpeed = 8f;

    


// Start is called before the first frame update
void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVel = new Vector3(Input.GetAxis("Horizontal" + pNumber) * Time.deltaTime, 0f, Input.GetAxis("Vertical" + pNumber) * Time.deltaTime);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity += myVel * speed;
        }
        

        if (myVel.magnitude > 0.01)
        {
            isWalking = true;

           
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetButtonDown("Banana" + pNumber) && bananaNum >= 1)
        {
            GameObject newBanana = Instantiate(banana, transform.position - 1f * transform.forward + new Vector3(0, 2f, 0), banana.transform.rotation);
            newBanana.GetComponent<Rigidbody>().AddForce(-transform.forward * 4f + transform.up * 2f, ForceMode.Impulse);
            StartCoroutine(MakeBanana());
            bananaNum -= 1;
        }
        print("myvel"+" "+myVel);
        if (Input.GetButtonDown("Fire" + pNumber))
        {
           // print("jumped");
           // rb.AddForce(new Vector3(0, 1, 0) * jumpForce,ForceMode.Impulse);
        }

       
    }

    IEnumerator MakeBanana()
    {
        yield return new WaitForSeconds(5f);
        bananaNum += 1;
    }
}
