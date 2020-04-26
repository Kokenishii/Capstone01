using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordControl : MonoBehaviour
{
    public float swordSpeed=150;
    int dir = 0;
    public float initAngle = 90;
    float traveled = 0;
    public float maxAngle=120;

    // Start is called before the first frame update
    void Start()
    {
        int temp = Random.Range(0, 1);
        if (temp ==1)
        {
            transform.eulerAngles = new Vector3(0, initAngle, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -initAngle, 0);
        }
       
    }
    void OnEnable()
    {
        int temp = Random.Range(0, 2);
        if (temp == 1)
        {
            transform.eulerAngles = new Vector3(0, initAngle, 0);
            dir = -1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -initAngle, 0);

            dir = 1;
        }
        traveled = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
            transform.eulerAngles +=  dir* swordSpeed * Time.deltaTime * new Vector3(0, 1, 0);
        traveled += Time.deltaTime*swordSpeed;
        //print(transform.eulerAngles.y);
        if (traveled > maxAngle)
        {
            dir = 0;
            gameObject.SetActive(false);
        }

    }
}
