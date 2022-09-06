using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    // Start is called before the first frame update

    string curtext;
    [SerializeField]
    Text CurText;

    [SerializeField]
    Button Submitbutton;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ChangeText()
    {
        curtext = CurText.text;
    }

    public void ID_Create()
    {
        SSSManager.SSSGM.PName = this.curtext;
        GameManager.gameManager.ChangeScene("09 SideScrollShootingGame");
    }
}
