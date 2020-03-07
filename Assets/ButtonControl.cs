using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public bool isPressed = false;
    float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
         cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && cooldown <= 0)
        {
            isPressed = !isPressed;
            cooldown = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
        }
    }
}
