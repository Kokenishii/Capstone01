using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLookat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position+new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")));
    }
}
