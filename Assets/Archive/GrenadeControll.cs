using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeControll : MonoBehaviour
{
    public float explosionForce = 5f;
    public float range = 5f;
    public float timer = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion(timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //StartCoroutine(Explosion(0.1f));
        }
    }

    IEnumerator Explosion(float count)
    {
        yield return new WaitForSeconds(count-0.1f);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.localScale += new Vector3(range, range, range) - transform.localScale;
        yield return new WaitForSeconds(0.1f);
        GameObject[] playersList= GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in playersList)
        {
            float d = Vector3.Distance(p.transform.position, transform.position);
            if (d<=range)
            {
                Vector3 explodeVector = explosionForce * (range - d) / range * (p.transform.position - transform.position).normalized;
                explodeVector = new Vector3(explodeVector.x, 0, explodeVector.z);
                    p.GetComponent<Rigidbody>().AddForce(explodeVector, ForceMode.Impulse);
            }
        }
        GameObject.Destroy(gameObject);
    }
}
