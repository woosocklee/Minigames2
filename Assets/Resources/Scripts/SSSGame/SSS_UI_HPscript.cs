using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSS_UI_HPscript : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform myRT;

    public GameObject player;

    void Start()
    {
        this.myRT = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        SSSPlayer pdata = player.GetComponent<SSSPlayer>();
        float hpbarsize = (float)pdata.curhp / (float)pdata.maxhp;

        this.myRT.localScale = new Vector3(hpbarsize, this.myRT.localScale.y, this.myRT.localScale.z);
    }
}
