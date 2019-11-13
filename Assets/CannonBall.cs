using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public bool inControll = false;
    bool onCD = false;
    public GameObject grenade;
    float counter = 0;
    public float cannonCD = 0.7f;
    Transform user;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inControll&&!onCD)
        {
            GameObject newCannon = Instantiate(grenade, transform.position+new Vector3(0,1,0), Quaternion.identity);
            newCannon.GetComponent<Rigidbody>().AddForce(transform.forward * 5f + transform.up * 2f, ForceMode.Impulse);
            onCD = true;
            StartCoroutine(CDcounter());
        }





    }

    IEnumerator CDcounter()
    {
        yield return  new WaitForSeconds(cannonCD);
        onCD = false;
    }

    private void OnTriggerStay(Collider other)
    {
      
        if (other.gameObject.tag == "Player")
        {
            user = other.transform;
     
            transform.LookAt(2 * transform.position - user.position);

            inControll = true;
             
              

        }
     
               

            



       
        //if (other.gameObject.tag == "Player")
        //{
        //    user = other.transform;

        //    if (Input.GetButtonDown("Grenade1") || Input.GetButtonDown("Grenade2"))
        //    {
        //        if (!inControll)
        //        {
        //            inControll = true;
        //        }
        //        else
        //        {
        //            inControll = false;
        //        }


        //    }

        //    if (inControll)
        //    {

        //        user.position = 2 * transform.position - user.position;
        //        transform.LookAt(user);

        //        if (onCD)
        //        {
        //            GameObject newCannon = Instantiate(grenade, transform.position, Quaternion.identity);
        //            newCannon.GetComponent<Rigidbody>().AddForce(transform.forward * 5f + transform.up * 2f, ForceMode.Impulse);
        //            onCD = false;
        //            StartCoroutine(CDcounter());

        //        }

        //    }



        //}


    }
}
