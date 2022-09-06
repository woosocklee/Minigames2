using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Button(new Rect((Screen.width / 2) - 75, (Screen.height/2) - 200 , 150 ,100), GameManager.gameManager.thing);

        if (GUI.Button(new Rect((Screen.width / 2)-100, (Screen.height/2), 200, 100), "Wanna Replay?"))
        {
            GameManager.gameManager.ChangeScene("00 Start");
        }
    }
}
