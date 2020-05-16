using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spiderControl : MonoBehaviour
{
    public string pNumber="1";

    public float maxSpeed = 20;
    public float accel = 10;
    public int mode = 0;
    GameObject puppet;
    bool canLeave = false;
    public GameObject bullet;
    bool canShoot = true;
    float count = 0.5f;
    public GameObject deadSpider;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (mode == 2)
        {
            GameObject deadBody = Instantiate(deadSpider, transform.position+ new Vector3(0, 0.5f, 0), Quaternion.identity);
            winText.text = "Player" + pNumber + " Wins";
            StartCoroutine(ReStart());
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            mode = 3;

        }
        if(mode==0)
        {
            float hor = Input.GetAxis("Horizontal" + pNumber) * Time.deltaTime;
            float ver = Input.GetAxis("Vertical" + pNumber) * Time.deltaTime;
            Vector3 myVel = new Vector3(hor, 0f, ver);
            transform.LookAt(transform.position + myVel);
            if (rb.velocity.magnitude <= maxSpeed)
            {
                rb.velocity += myVel * accel;

            }

            if (Input.GetAxis("Fire" + pNumber) >= 0.5f && canShoot)
            {
                GameObject newBullet = Instantiate(bullet, transform.position + transform.forward * 0.5f + new Vector3(0, 0.5f, 0), Quaternion.identity);
                newBullet.GetComponent<tinyBulletControl>().dir = transform.forward;
                newBullet.GetComponent<tinyBulletControl>().pNumber = pNumber;
                canShoot = false;
            }

            if (!canShoot)
            {
                count -= Time.deltaTime;
                if (count <= 0)
                {
                    canShoot = true;
                    count = 0.5f;
                }
            }


            
        }


       

        if (mode == 1 && puppet != null)
        {
            rb.isKinematic = true;
            transform.position = puppet.transform.position;

            if ((Input.GetButtonDown("Hit" + pNumber)&&canLeave)||puppet.GetComponentInParent<PuppetParent>().health<=0)
            {

           
                puppet.tag = "Stuff";
                rb.isKinematic = false;
                puppet.GetComponent<Controll_Shoot>().pNumber = "0";
                puppet.GetComponent<Controll_Shoot>().isReady = false;
                //puppet.gameObject.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = true;
                mode = 0;
                canLeave = false;
            }
        }

       



        if (Input.GetButton("Fire" + pNumber))
        {
            print("Fire" + pNumber);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Body")
        {
            print("contact Player");
            if (other.gameObject.GetComponent<Controll_Shoot>().pNumber != null && other.gameObject.GetComponent<Controll_Shoot>().pNumber=="0")
                //if(Input.GetButton("Fire"+pNumber))
                //{
                //    other.gameObject.GetComponent<Controll_Shoot>().pNumber = pNumber;
                //}
                if (Input.GetButtonDown("Hit"+pNumber) && mode == 0)
                {
                    
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    mode = 1;
                    puppet = other.gameObject;
                    other.gameObject.GetComponent<Controll_Shoot>().canShoot = false;
                    other.gameObject.GetComponent<Controll_Shoot>().pNumber = pNumber;
                    StartCoroutine(changeMode());
                }

           



        }
    }

    IEnumerator changeMode()
    {
        yield return new WaitForSeconds(2f);
        canLeave = true;

    }


    IEnumerator ReStart()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }




}
