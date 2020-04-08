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

    bool isGrounded = true;
    public bool contact = false;
    public GameObject bullet;
    bool canShoot = true;
    public float shootCD = 1f;
    float shootCount = 0.1f;
    


// Start is called before the first frame update
void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sword = GameObject.Find("sword" + pNumber);
    }

    // Update is called once per frame
    void Update()
    {
       float hor = Input.GetAxis("Horizontal" + pNumber)*Time.deltaTime;
        float ver = Input.GetAxis("Vertical" + pNumber) * Time.deltaTime;
        Vector3 myVel = new Vector3(hor, 0f, ver);

        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity += myVel * speed;
        }
        Transform parentTransform = transform.parent.parent.transform;
        Vector3 lookAt = new Vector3(parentTransform.position.x + hor, parentTransform.position.y, parentTransform.position.z + ver);
        parentTransform.LookAt(lookAt);

        if (myVel.magnitude > 0.01)
        {
            isWalking = true;

           
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
            GameObject newBullet = Instantiate(bullet, transform.position + transform.parent.parent.transform.forward * 1f+new Vector3(0,0.1f,0),Quaternion.identity) ;
            newBullet.GetComponent<BulletControl>().dir = transform.parent.parent.transform.forward;
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

   

    private void OnTriggerEnter2(Collider collision)
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

    private void OnTriggerExit2(Collider collision)
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



