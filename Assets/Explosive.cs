using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject bullet;
    bool canExplode = true;
    float counter = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canExplode)
        {
            counter -= Time.deltaTime;
        }
        if (counter <= 0)
        {
            canExplode = true;
            counter = 5;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GameObject[] bulletList = new GameObject[4];
            if (canExplode)
            {
                for (int i = 0; i <= 3; i++)
                {

                    bulletList[i] = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullet.GetComponent<BulletControl>().dir = new Vector3(Mathf.Sin(i * Mathf.PI / 2), 0, Mathf.Cos(i * Mathf.PI / 2));
                }
                canExplode = false;
            }
            
            
        }
    }
}
