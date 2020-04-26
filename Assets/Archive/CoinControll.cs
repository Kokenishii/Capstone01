using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinControll : MonoBehaviour
{

    public Text mytext1;
    public Text mytext2;
    int score1 = 0;
    int score2 = 0;
    GameObject p1;
    GameObject p2;
    void Start()
    {
        //score1 = 0;
        //score2 = 0;
        //mytext1 = GameObject.Find("Text1").GetComponent<Text>();
        //mytext2 = GameObject.Find("Text2").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()

    {
        mytext1.text = score1.ToString();
        mytext2.text = score2.ToString();
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        if (p1.GetComponent<ragDollControl>().contact == true)
        {
            score1 += 1;
        }


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject hit = collision.gameObject;
            if (hit.GetComponent<ragDollControl>().pNumber == "1")
            {
                //score1 += 1;
            }
            if (hit.GetComponent<ragDollControl>().pNumber == "2")
            {
                //score2 += 1;
            }

            //GameObject.Destroy(this.gameObject);

        }
    }
}


