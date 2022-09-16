using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wolf"))
        {
            Debug.Log("Trig Enemy Hit");

            other.GetComponent<HNS_Enemy>().Ouch();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wolf"))
        {
            Debug.Log("Col Enemy Hit");
        }
    }
}
