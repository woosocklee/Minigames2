using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSS_UI_Coin : MonoBehaviour
{
    // Start is called before the first frame update
    Text mycoin;
    void Start()
    {
        this.mycoin = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mycoin.text = "" + SSSManager.SSSGM.Coin;
    }
}
