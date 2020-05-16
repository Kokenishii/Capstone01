using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraControll : MonoBehaviour
{
    public GameObject point;
    public GameObject p1;
    public GameObject p2;
    Camera cam;
    float maxDis;
    float fov;
    float zPos;
    public float minZ;
    float yPos;
    public float minY = 10;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        fov = cam.fieldOfView;
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        maxDis = Vector3.Distance(p1.transform.position, p2.transform.position);
        zPos = transform.localPosition.z;
        yPos = transform.localPosition.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(point.transform.position);
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
        float distance = Vector3.Distance(p1.transform.position, p2.transform.position);
        float newZ = minZ + (zPos - minZ) * distance / maxDis;
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
        float newY = minY + (yPos - minY) * distance / maxDis;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, newZ);
        //cam.fieldOfView = fov *  distance / maxDis;
    }
    
}
