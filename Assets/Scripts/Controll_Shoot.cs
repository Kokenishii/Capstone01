using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Controll_Shoot : MonoBehaviour
{
  
    public GameObject sword;
    public GameObject grenade;
    public int bananaNum;
    public int grenadeNum = 1;

    public string pNumber = "1";
    Rigidbody rb;
    public float speed = 50;
    public float jumpForce = 500f;
    public bool isWalking = false;
    public float maxSpeed = 8f;

    public bool isGrounded = true;
    public bool contact = false;
    public GameObject bullet;
    public bool canShoot = true;
    public float shootCD = 1f;
    float shootCount = 0.1f;
    public GameObject particle1;
    public GameObject particle2;
    public bool isReady = true;
    


// Start is called before the first frame update
void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sword = GameObject.Find("sword" + pNumber);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<PuppetParent>().pNumber = pNumber;
        GetComponentInParent<PuppetParent>().isReady = isReady;


        float hor = Input.GetAxis("Horizontal" + pNumber)*Time.deltaTime;
        float ver = Input.GetAxis("Vertical" + pNumber) * Time.deltaTime;
        Vector3 myVel = new Vector3(hor, 0f, ver);

        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity += myVel * speed;
        }
         




        if (myVel.magnitude > 0.01)
        {
            //isWalking = true;
            //Transform parentTransform = transform.parent.transform;
            
            //if (isGrounded)
            //{
            //    Vector3 lookAt = parentTransform.position + myVel;
               

            //    Quaternion rotTarget = Quaternion.LookRotation(myVel);
            //    parentTransform.rotation = Quaternion.RotateTowards(parentTransform.rotation, rotTarget, 1000f * Time.deltaTime);
            //}
           


        }
        else
        {
            isWalking = false;
        }
        if (Input.GetButtonDown("Hit"+pNumber))
        {

            // print("Sword" + pNumber);
            sword.SetActive(true);
        }
     
        
//        print("myvel"+" "+myVel);
        //if (Input.GetButtonDown("Fire" + pNumber)&&isGrounded)
        //{
        ////   print("jumped");
        //   rb.AddForce(new Vector3(0, 0.6f, 0) * jumpForce,ForceMode.Impulse);

        //}
//        print(isGrounded);
        //shooting
        if (Input.GetAxis("Fire" + pNumber) >= 0.5f&&canShoot)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.parent.transform.forward *1f+ new Vector3(0,0.5f,0),Quaternion.identity) ;
            newBullet.GetComponent<BulletControl>().dir = transform.parent.transform.forward;
            canShoot = false;
        }
        if (!canShoot)
        {
            shootCount -= Time.deltaTime;
            if (shootCount <= 0) {
                canShoot = true;
                shootCount = shootCD;
            }
        }

       
    }

   

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Floor")
            {
           isGrounded = true;
            //particle1.SetActive(true);
            //particle2.SetActive(true);
        }

        if (collision.gameObject.tag == "Player")
        {


            if (pNumber!="0" &&collision.gameObject.GetComponent<spiderControl>().pNumber != pNumber)
            {
                if (collision.gameObject.GetComponent<spiderControl>().mode == 0)
                {
                    collision.gameObject.GetComponent<spiderControl>().mode = 2;
                }
                
            }


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
            //particle1.SetActive(false);
            //particle2.SetActive(false);
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



