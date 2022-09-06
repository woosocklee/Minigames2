using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanMain : MonoBehaviour
{
    // Start is called before the first frame update

    public int Score = 0;

    private static SpartanMain sInstance;
    public static SpartanMain SpartanManager
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newgameobj = new GameObject("SpartanMain");
                sInstance = newgameobj.AddComponent<SpartanMain>();
            }

            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gameover()
    {
        GameManager.gameManager.thing = "Score: " + Score;
        GameManager.gameManager.ChangeScene("99 End");
    }
}
