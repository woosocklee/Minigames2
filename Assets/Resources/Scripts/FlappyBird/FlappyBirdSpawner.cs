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
        while(true)
        {
            yield return new WaitForSeconds(delayTime);
            MakeObj();
        }
    }

    private void Start()
    {
        temp = PC.score;
        // 1초 지연 후 MakeObj를 발생시킴
        //Invoke("MakeObj", 1.0f);
        // 1초 지연 후 0.5초 단위로 반복 호출
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
