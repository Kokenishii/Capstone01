using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadBox : MonoBehaviour
{
    public Text mytext1;
    public Text mytext2;
     public GameObject player1;
    public GameObject player2;
    GameObject p1n;
    GameObject p2n;
    int score1 = 0;
    int score2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        //score2 = 0;
        mytext1 = GameObject.Find("Text1").GetComponent<Text>();
        mytext2 = GameObject.Find("Text2").GetComponent<Text>();
        if (!PlayerPrefs.HasKey("Score1"))
        {
            PlayerPrefs.SetInt("Score1", 0);
        }

        if (!PlayerPrefs.HasKey("Score2"))
        {
            PlayerPrefs.SetInt("Score2", 0);
        }
    }

    // Update is called once per frame
    void Update()

    {
        mytext1.text = score1.ToString();
        mytext2.text = score2.ToString();
        p1n = GameObject.Find("Player1");
        p2n = GameObject.Find("Player2");
        if (p1n.GetComponent<ragDollControl>().contact == true)
        {
            p1n.GetComponent<ragDollControl>().contact = false; 
            
            score1 += 1;
            GameObject p2 = GameObject.Find("Player2no");
            GameObject.Destroy(p2);
            GameObject newp2 = Instantiate(player2, new Vector3(0, 5, -20), Quaternion.identity);
            newp2.name = "Player2no";


        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("Score1", 0);
        

    
        
            PlayerPrefs.SetInt("Score2", 0);
        }
    }
    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject hit = collision.gameObject;
            if (hit.GetComponent<ragDollControl>().pNumber == "1")
            {
                // PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2") + 1);
                // hit.gameObject.GetComponentInParent<Transform>().position = new Vector3(0, 5, -20);
                GameObject p1= GameObject.Find("Player1no");
                //GameObject.Destroy(hit.transform.parent.gameObject);
                GameObject.Destroy(p1);
                GameObject newp1 = Instantiate(player1, new Vector3(0, 2, -15), Quaternion.identity);
                newp1.name = "Player1no";
                //GameObject.Find("Player1no").transform.position = GameObject.Find("Player2no").transform.position + new Vector3(0, 4f, 0);
            }
            if (hit.GetComponent<ragDollControl>().pNumber == "2")
            {
                // PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1") + 1);
                //hit.gameObject.GetComponentInParent<Transform>().position = new Vector3(0, 5, -20);
                GameObject p2= GameObject.Find("Player2no");
                GameObject.Destroy(p2);
                GameObject newp2 = Instantiate(player2, new Vector3(0, 2, -25), Quaternion.identity);
                newp2.name = "Player2no";
                //GameObject.Find("Player2no").transform.position = GameObject.Find("Player1no").transform.position + new Vector3(0, 4f, 0);
            }
          
               // SceneManager.LoadScene(0);
            
        }
    }
}
