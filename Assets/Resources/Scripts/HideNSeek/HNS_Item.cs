using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_Item : MonoBehaviour
{
    // Start is called before the first frame update

    int score;

    void Start()
    {
        this.score = Random.Range(0, 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ColStart: " + collision.gameObject.name);


        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HNS_Player>().SetScore(score);
            Destroy(this.gameObject);
            
        }
    }
}
