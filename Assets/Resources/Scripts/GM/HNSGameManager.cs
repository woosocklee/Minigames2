using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNSGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    HNS_Player Player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Curhp <= 0)
        {
            GameManager.gameManager.thing = "Score: " + Player.Score;
            GameManager.gameManager.ChangeScene("99 End");
        }
    }
}
