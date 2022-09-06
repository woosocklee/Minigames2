using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSS_UI_Name : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text myname;
    void Start()
    {
        //this.myname = this.gameObject.GetComponent<Text>();
        myname.text = "" + SSSManager.SSSGM.PName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
