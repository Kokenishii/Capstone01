using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlatform : MonoBehaviour
{
    public Vector3 rSpeed;
    public float direction = 1;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button != null)
        {
            if (button.GetComponent<ButtonControl>().isPressed == true)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
        
        transform.Rotate(rSpeed*direction);
    }


}
