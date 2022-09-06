using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameManager.thing = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect((Screen.width/2) - 100, (Screen.height/2) - 30, 200, 30), "Racing Game Start"))
        {
            GameManager.gameManager.ChangeScene("05 Racing");
        }
        if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) , 200, 30), "Flappy Bird Game Start"))
        {
            GameManager.gameManager.ChangeScene("07 FlappyBird");
        }
        if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 30, 200, 30), "SpartanDefense Game Start"))
        {
            GameManager.gameManager.ChangeScene("08 SpartanKing");
        }
        if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 60, 200, 30), "SideScrollShooting Game Start"))
        {
            GameManager.gameManager.ChangeScene("11 SSSLogin");
        }
    }
}
