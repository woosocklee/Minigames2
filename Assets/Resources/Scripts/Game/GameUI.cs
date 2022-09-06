using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
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
        if (GUI.Button(new Rect(400, 250, 150, 30), "∞‘¿” æ¿"))
        {
            GameManager.gameManager.ChangeScene("99 End");
        }
    }
}
