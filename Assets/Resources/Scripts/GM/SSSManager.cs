using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private string Pname;
    public string PName
    {
        get { return Pname; }
        set { Pname = value; }
    }

    [SerializeField]
    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    [SerializeField]
    private int coin;
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    private static SSSManager sssgm;
    public static SSSManager SSSGM
    {
        get
        {
            if (sssgm == null)
            {
                GameObject newgameobj = new GameObject("_SSSGM");
                sssgm = newgameobj.AddComponent<SSSManager>();
            }

            return sssgm;
        }
    }

    public void Gameover()
    {
        GameManager.gameManager.thing = "Name: " + Pname + "\n Score: " + score + "\n Coin: " + coin;
        GameManager.gameManager.ChangeScene("99 End");
    }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        this.score = 0;
        this.coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
