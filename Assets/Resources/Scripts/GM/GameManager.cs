using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string thing;
    private static GameManager sInstance;
    public static GameManager gameManager
    {
        get
        {
            if(sInstance == null)
            {
                GameObject newgameobj = new GameObject("_Gamemanager");
                sInstance = newgameobj.AddComponent<GameManager>();
            }

            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(thing == null)
        {
            thing = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScene(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }
}
