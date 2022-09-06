using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanSpawner : MonoBehaviour
{
    public GameObject ESpartan = null;
    public float delayTime = 1.0f;

    [SerializeField]
    private SpartanMain Manager;

    [SerializeField]
    private GameObject EspartanEffect = null;

    //IEnumerator로 코루틴화
    /*IEnumerator Start()
    {
        while(true)
        {
            GameObject obj = null;
            if( obstacleObj != null)
            {
                obj = Instantiate(obstacleObj, transform.position, transform.rotation);
            }

            Destroy(obj, 1.0f);
            // 1.5초 동안 "이 함수"를 정지해두고 1.5초 후에 시스템에서 이 함수를 다시 부름
            yield return new WaitForSeconds(1.5f);
        }        
    }*/

    IEnumerator Loading()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            float x = (Random.Range(-4.5f, 4.5f));
            Vector3 adjvec = new Vector3(x, 0, 0);
            Vector3 Eadjvec = adjvec + new Vector3(0, 0, 1);
            GameObject effect = null;
            effect = Instantiate(EspartanEffect, transform.position + Eadjvec, transform.rotation);
            yield return new WaitForSeconds(0.2f);
            MakeObj(adjvec);
        }
    }


    private void Start()
    {
        // 1초 지연 후 MakeObj를 발생시킴
        //Invoke("MakeObj", 1.0f);
        // 1초 지연 후 0.5초 단위로 반복 호출
        //InvokeRepeating("MakeObj", 1.0f, delayTime);
        StartCoroutine("Loading");
    }

    private void Update()
    {
        //Count();
    }

    void Count()
    {
        delayTime = 1.0f - (Manager.Score / 100000);
    }

    void MakeObj(Vector3 adjvec)
    {
        GameObject obj = null;

        if (ESpartan != null)
        {
            obj = Instantiate(ESpartan, transform.position + adjvec, transform.rotation);
            //Invoke("MakeObj", 1.0f);
        }
    }
}
