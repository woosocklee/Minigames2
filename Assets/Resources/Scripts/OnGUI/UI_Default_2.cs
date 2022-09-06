using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Default_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    this.count++;
        //}
    }

    private int count = 0;

    private void OnGUI()
    {
        string str = "Text test 2";
        string str2 = "ddd";
        string str3 = "click Count : " + count.ToString();
        GUI.TextArea(new Rect(200, 50, 100, 30), "Text Test");
        GUI.TextField(new Rect(200, 100, 100, 30), str);
        GUI.Box(new Rect(200, 150, 100, 30), str2);
        GUI.Box(new Rect(200, 200, 100, 30), str3);

        if(GUI.Button(new Rect(200, 250, 100, 30), "Button"))
        {
            this.count++;
        }

    }
}
