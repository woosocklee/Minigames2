using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HNS_HPbar : MonoBehaviour
{
    RectTransform myRT;

    [SerializeField]
    private Text HPtext;

    public HNS_Player player;

    void Start()
    {
        this.myRT = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hpbarsize = (float)player.Curhp / (float)player.maxhp;
        HPtext.text = player.Curhp.ToString();
        this.myRT.localScale = new Vector3(hpbarsize, this.myRT.localScale.y, this.myRT.localScale.z);
    }
}
