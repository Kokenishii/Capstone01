using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public float countdown = 5;
    bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            Transform target;
            float pickOne = Random.Range(0, 1);
            if (pickOne > 0.5)
            {
                target = GameObject.Find("Player1").transform;
                
            }
            else
            {

            }
        }
    }

    IEnumerator switchTarget()
    {
        yield return new WaitForSeconds(countdown);
        
    }
}
