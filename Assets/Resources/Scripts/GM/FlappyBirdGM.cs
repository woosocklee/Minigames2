using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PC;

    void Start()
    {
        GameManager.gameManager.thing = "Score: " + PC.GetComponent<FlappyBirdPlayer>().score;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PC == null)
        {
            GameManager.gameManager.ChangeScene("99 End");
        }
        else
        {
            GameManager.gameManager.thing = "Score: " + PC.GetComponent<FlappyBirdPlayer>().score;
        }
    }
}
