using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Default : MonoBehaviour
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
        string str = "Text Test";
        
        //string.Format();
        GUI.TextArea(new Rect(200, 50, 100, 30), str);
    }
}
