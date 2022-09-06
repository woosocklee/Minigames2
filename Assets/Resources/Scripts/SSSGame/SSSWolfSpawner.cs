using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSWolfSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject Wolf;

    [SerializeField]
    private float spawnspeed;

    private float maxspawnspeed = 0.5f;

    void Start()
    {
        StartCoroutine("summonWolf");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    IEnumerator summonWolf()
    {
        while(true)
        {
            makeobj();
            yield return new WaitForSeconds(spawnspeed);
        }

       
    }

    void makeobj()
    {
        GameObject obj = null;

        if (Wolf != null)
        {
            obj = Instantiate(Wolf, transform.position + new Vector3(0, Random.Range(-200f,200f), 0), transform.rotation);
            //Invoke("MakeObj", 1.0f);
        }
    }
}
