using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdSpawner : MonoBehaviour
{
    public GameObject obstacleObj = null;

    public float heightTransition = 1.0f;

    public float delayTime = 1.0f;

    private int temp = 0;


    enum heightadj
    {
        top = 4,
        up = 3,
        hold = 2,
        down = 1,
        bottom = 0
    }

    public FlappyBirdPlayer PC;


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
        while(true)
        {
            yield return new WaitForSeconds(delayTime);
            MakeObj();
        }
    }

    private void Start()
    {
        temp = PC.score;
        // 1�� ���� �� MakeObj�� �߻���Ŵ
        //Invoke("MakeObj", 1.0f);
        // 1�� ���� �� 0.5�� ������ �ݺ� ȣ��
        //InvokeRepeating("MakeObj", 1.0f, delayTime);
        StartCoroutine("Loading");
    }

    private void Update()
    {
        Count();
    }

    void Count()
    {
        delayTime = 1.0f - (PC.score / 100000);
    }
    
    void MakeObj()
    {
        GameObject obj = null;
        if (obstacleObj != null)
        {
            heightadj x = (heightadj)(Random.Range(0, 5));
            Vector3 adjvec = new Vector3(0, (int)x - 2 , 0);
            obj = Instantiate(obstacleObj, transform.position + adjvec, transform.rotation);
            //Invoke("MakeObj", 1.0f);
        }
    }
}
