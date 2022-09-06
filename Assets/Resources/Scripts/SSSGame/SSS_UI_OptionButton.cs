using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSS_UI_OptionButton : MonoBehaviour
{
    [SerializeField]
    Button thisbutton;
    // Start is called before the first frame update
    void Start()
    {
        thisbutton = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void buttonlistener()
    {
        Debug.Log("ÇØÄ¡¿ü³ª?");
    }
    
}
