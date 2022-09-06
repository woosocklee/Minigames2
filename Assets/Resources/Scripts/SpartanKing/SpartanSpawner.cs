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

    //IEnumerator�� �ڷ�ƾȭ
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
            // 1.5�� ���� "�� �Լ�"�� �����صΰ� 1.5�� �Ŀ� �ý��ۿ��� �� �Լ��� �ٽ� �θ�
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
        // 1�� ���� �� MakeObj�� �߻���Ŵ
        //Invoke("MakeObj", 1.0f);
        // 1�� ���� �� 0.5�� ������ �ݺ� ȣ��
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
