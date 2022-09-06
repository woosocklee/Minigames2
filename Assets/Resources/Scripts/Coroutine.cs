using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    // Start is called before the first frame update

    private int count = 0;
    

    IEnumerator CountTime(float delayTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(delayTime);
            yield return null;

            count++;
            if(count > 10)
            {
                yield break;
            }
            print(count.ToString());

            /*

            yield return new WaitForSeconds(delayTime);
            ++count;
            print(count.ToString());


            */
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
