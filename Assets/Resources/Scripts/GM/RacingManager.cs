using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingManager : MonoBehaviour
{
    // Start is called before the first frame update

    public CarMovement player;
    public AutoMoving enemy1;
    public AutoMoving enemy2;

    public int WinningLap = 2;

    void Start()
    {
        
    }

    private void Update()
    {
        if (player.lap >= WinningLap)
        {
            GameManager.gameManager.thing = "Winner: Player";
            GameManager.gameManager.ChangeScene("99 End");
        }
        if (enemy1.lap >= WinningLap)
        {
            GameManager.gameManager.thing = "Winner: Enemy1";
            GameManager.gameManager.ChangeScene("99 End");
        }
        if (enemy2.lap >= WinningLap)
        {
            GameManager.gameManager.thing = "Winner: Enemy2";
            GameManager.gameManager.ChangeScene("99 End");
        }
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 100, 30), "player Lap: " + player.lap);

        GUI.TextArea(new Rect(0, 60, 100, 30), "Enemy1 Lap: " + enemy1.lap);

        GUI.TextArea(new Rect(0, 120, 100, 30), "Enemy2 Lap: " + enemy2.lap);
    }
}
