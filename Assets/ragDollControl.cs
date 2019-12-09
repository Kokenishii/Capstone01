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

    bool isGrounded = true;
    public bool contact = false;

    


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
            GameObject newBanana = Instantiate(banana, transform.position + 2f * transform.forward , banana.transform.rotation);
            newBanana.GetComponent<Rigidbody>().AddForce(transform.forward * 2f, ForceMode.Impulse);
            StartCoroutine(MakeBanana());
            bananaNum -= 1;
        }
        print("myvel"+" "+myVel);
        if (Input.GetButtonDown("Fire" + pNumber)&&isGrounded)
        {
           print("jumped");
           rb.AddForce(new Vector3(0, 0.6f, 0) * jumpForce,ForceMode.Impulse);

        }
        print(isGrounded);
       

       
    }

    IEnumerator MakeBanana()
    {
        yield return new WaitForSeconds(5f);
        bananaNum += 1;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Floor")
            {
           isGrounded = true;
            }

        if (collision.gameObject.tag == "Player")
        {

            contact = true;


            //if (Input.GetButtonDown("Fire" + pNumber)&&canDash)
            //{
            //    print("push");
            //    collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
            //    canDash = false;
            //    myAnimator.SetBool("isDashing", true);
            //    StartCoroutine(DashCD());
            //}
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "Player")
        {

            contact = false;


            //if (Input.GetButtonDown("Fire" + pNumber)&&canDash)
            //{
            //    print("push");
            //    collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
            //    canDash = false;
            //    myAnimator.SetBool("isDashing", true);
            //    StartCoroutine(DashCD());
            //}
        }


    }

   

  
}



