using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadBox : MonoBehaviour
{
    public Text mytext1;
    public Text mytext2;
    public Text mytext3;
    public GameObject player1no;
    public GameObject player2no;
    public GameObject player1;
    public GameObject player2;
    GameObject p1n;
    GameObject p2n;
    public int hp1 = 100;
    public int hp2 = 100;
    GameObject hp1bar;
    GameObject hp2bar;
    float hpbarmax;
    Vector3 p1origin;
    Vector3 p2origin;

   
    // Start is called before the first frame update
    void Start()
    {
        p1origin = player1.transform.position;
        p2origin = player2.transform.position;
        hp1bar = GameObject.Find("HP1");
        hp2bar = GameObject.Find("HP2");
        hpbarmax = hp1bar.GetComponent<RectTransform>().transform.localScale.x;


        //score2 = 0;
        //mytext1 = GameObject.Find("Text1").GetComponent<Text>();
        //mytext2 = GameObject.Find("Text2").GetComponent<Text>();
        //if (!PlayerPrefs.HasKey("Score1"))
        //{
        //    PlayerPrefs.SetInt("Score1", 0);
        //}

        //if (!PlayerPrefs.HasKey("Score2"))
        //{
        //    PlayerPrefs.SetInt("Score2", 0);
        //}
    }

    // Update is called once per frame
    void Update()

    {
        mytext1.text = hp1.ToString();
        mytext2.text = hp2.ToString();
        p1n = GameObject.Find("Player1");
        p2n = GameObject.Find("Player2");
        hp1bar.GetComponent<RectTransform>().transform.localScale = new Vector3(hpbarmax * hp1 / 100,1, 1);
        hp2bar.GetComponent<RectTransform>().transform.localScale = new Vector3(hpbarmax * hp2 / 100,1, 1);
        //if (p1n.GetComponent<ragDollControl>().contact == true)
        //{
        //    p1n.GetComponent<ragDollControl>().contact = false; 

        //    score1 += 1;
        //    GameObject p2 = GameObject.Find("Player2no");
        //    GameObject.Destroy(p2);
        //    GameObject newp2 = Instantiate(player2, new Vector3(0, 5, -20), Quaternion.identity);
        //    newp2.name = "Player2no";


        //}

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    PlayerPrefs.SetInt("Score1", 0);




        //    PlayerPrefs.SetInt("Score2", 0);
        //}

        if (hp1 <= 0 && hp2>0)
        {
            mytext3.text = "Player 2 Wins";
        }

        if (hp2 <= 0&&hp1>0)
        {
            mytext3.text = "Player 1 Wins";
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
                GameObject newp1 = Instantiate(player1no, p1origin, Quaternion.identity);
                newp1.name = "Player1no";
                //GameObject.Find("Player1no").transform.position = GameObject.Find("Player2no").transform.position + new Vector3(0, 4f, 0);
            }
            if (hit.GetComponent<ragDollControl>().pNumber == "2")
            {
                // PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1") + 1);
                //hit.gameObject.GetComponentInParent<Transform>().position = new Vector3(0, 5, -20);
                GameObject p2= GameObject.Find("Player2no");
                GameObject.Destroy(p2);
                GameObject newp2 = Instantiate(player2no, p2origin, Quaternion.identity);
                newp2.name = "Player2no";
                //GameObject.Find("Player2no").transform.position = GameObject.Find("Player1no").transform.position + new Vector3(0, 4f, 0);
            }
          
               // SceneManager.LoadScene(0);
            
        }
    }
}
