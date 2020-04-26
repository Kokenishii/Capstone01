using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator myAnimator;
    Rigidbody rb;
    public float speed = 1;
    public float maxSpeed = 10;
    public float dashForce = 5;
    public string pNumber = "1";
    public int chasemode = 0;
    bool canDash = true;
    public bool contact = false;
    public float pushForce = 20f;
   public float dashCD = 2f;
    public GameObject banana;
    public GameObject grenade;
    public int bananaNum;
    public int grenadeNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 myVel = new Vector3(Input.GetAxis("Horizontal"+pNumber) * Time.deltaTime, 0f, Input.GetAxis("Vertical"+pNumber) * Time.deltaTime);
        myVel = myVel.normalized * speed;

        if (myVel.magnitude > 0.01)
        {
            myAnimator.SetBool("isWalking", true);
            transform.forward = myVel;
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
        //rb.velocity = myVel;
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(myVel, ForceMode.VelocityChange);
        }
          
        if (Input.GetButtonDown("Fire"+pNumber)&&canDash&&!contact)
        {
            rb.AddForce(transform.forward*dashForce, ForceMode.Impulse);
            canDash = false;

            myAnimator.SetBool("isDashing", true);
            StartCoroutine(DashCD());
        }

        if (Input.GetButtonDown("Banana" + pNumber)&& bananaNum>=1)
        {
            GameObject newBanana = Instantiate(banana, transform.position+new Vector3(0,2f,2f), banana.transform.rotation);
            newBanana.GetComponent<Rigidbody>().AddForce(transform.up * 4f, ForceMode.Impulse);
            StartCoroutine(MakeBanana());
            bananaNum -= 1;
        }

        if (Input.GetButtonDown("Grenade" + pNumber) && grenadeNum >= 1)
        {
            GameObject newGrenade = Instantiate(grenade, transform.position +1f * transform.forward + new Vector3(0, 2f, 0), grenade.transform.rotation);
            newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * 5f + transform.up * 2f, ForceMode.Impulse);
            StartCoroutine(MakeGrenade());
            grenadeNum -= 1;
        }



    }

   IEnumerator MakeBanana()
    {
        yield return new WaitForSeconds(5f);
        bananaNum += 1;
    }

    IEnumerator MakeGrenade()
    {
        yield return new WaitForSeconds(5f);
        grenadeNum += 1;
    }

    IEnumerator DashCD()
    {
        yield return new WaitForSeconds(0.5f);
        myAnimator.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashCD);
        canDash = true;

    }

    private void OnCollisionEntry(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
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

    private void OnCollisionExit(Collision collision)
    {
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
