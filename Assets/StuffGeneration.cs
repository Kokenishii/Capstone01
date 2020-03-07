using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffGeneration : MonoBehaviour
{
    public float GeneratingInterval = 1;
    public float temp = 1;
    public GameObject stuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeneratingInterval -= Time.deltaTime;
        if (GeneratingInterval <= 0)
        {
          
            Instantiate(stuff, transform.position - new Vector3(0,0.5f,0), Quaternion.identity);
            GeneratingInterval = temp;
        }
        
    }
}
