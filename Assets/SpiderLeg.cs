using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    public float freq = 5;
    public float range = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = gameObject.GetComponentInParent<Transform>();
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin( ((transform.position.z+transform.position.x)*5) * freq) * range+15f);
    }
}
