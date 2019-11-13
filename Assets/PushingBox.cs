using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{
    public Vector3 moveTo = new Vector3();
    public float moveSpeed = 5f;
    Vector3 moveFrom = new Vector3();
    public bool isMoving = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveFrom = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 moveVel = (moveTo - moveFrom) * Time.deltaTime*moveSpeed;
            rb.velocity = moveVel;
            if ((transform.position - moveTo).magnitude <= 0.5f)
            {
                isMoving = false;
                Vector3 temp = moveTo;
                moveTo = moveFrom;
                moveFrom = temp;
            }
        }

      
    }

    private void OnTriggerStay(Collider other)
    {
//        print(other.gameObject.tag);


        if ((Input.GetButtonDown("Fire1") && other.gameObject.name =="Player1")
        ||( Input.GetButtonDown("Fire2") && other.gameObject.name == "Player2"))
        {
          // print(other.gameObject.tag);
            isMoving = true;
        }
    }
}
