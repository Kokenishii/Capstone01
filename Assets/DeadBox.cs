using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadBox : MonoBehaviour
{
    public Text mytext1;
    public Text mytext2;
    // Start is called before the first frame update
    void Start()
    {
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
        mytext1.text = PlayerPrefs.GetInt("Score1").ToString();
        mytext2.text = PlayerPrefs.GetInt("Score2").ToString();

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
                PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2") + 1);
            }
            if (hit.GetComponent<ragDollControl>().pNumber == "2")
            {
                PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1") + 1);
            }
          
                SceneManager.LoadScene(0);
            
        }
    }
}
