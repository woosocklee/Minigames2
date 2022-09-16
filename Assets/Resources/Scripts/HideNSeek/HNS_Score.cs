using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HNS_Score : MonoBehaviour
{
    // Start is called before the first frame update
    Text myscore;

    [SerializeField]
    HNS_Player Player;

    void Start()
    {
        this.myscore = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myscore.text = "Score: " + Player.Score;
    }
}
