using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoving : MonoBehaviour
{
    public RaycastSensors LeftS;
    public RaycastSensors RightS;
    public RaycastSensors FrontS;

    public int lap;

    public CarBodyRacing mybody;

    public RacerData myData;

    [Range(0, 60)]
    public float Accelspeed = 10.0f;
    [Range(0, 120)]
    public float rotspeed = 30.0f;
    public float AccelDelta { get { return Accelspeed * Time.deltaTime * (0.5f + myData.aggression); } }
    public float rotDelta { get { return rotspeed * Time.deltaTime * (0.5f + myData.control); } }

    public float moveSpeedadj { get { return (oncol? curmaxmovespeed / 2: curmaxmovespeed); } }

    [Range(0, 15)]
    public float maxmovespeed = 10.0f;

    public float curmaxmovespeed;

    private float movespeed;

    private bool oncol;

    CarMovement Player;

    [SerializeField]
    private bool mistake;

    void Moveforward()
    {
        this.movespeed += AccelDelta;
        //this.transform.Translate(Vector3.forward * movespeed);

    }

    void MoveBack()
    {
        this.movespeed -= AccelDelta;
        //this.transform.Translate(Vector3.back * movespeed);

    }

    void MoveRight()
    {
        this.transform.Rotate(new Vector3(0, 1, 0) * rotDelta);
    }

    void MoveLeft()
    {
        this.transform.Rotate(new Vector3(0, -1, 0) * rotDelta);
    }


    // Start is called before the first frame update
    void Start()
    {
        this.lap = 0;
        this.oncol = false;
        this.movespeed = 0;
        this.Player = FindObjectOfType<CarMovement>();
        Debug.Log(Player);
        curmaxmovespeed = maxmovespeed * (0.5f + myData.skill);
        StartCoroutine(CheckMistake());
    }

    // Update is called once per frame
    void Update()
    {
        if (mistake) 
        {
            if (LeftS.rot.y + 10 * myData.mistakes < RightS.rot.y)
            {
                MoveRight();
            }
            else if (LeftS.rot.y > RightS.rot.y + 10 * myData.mistakes)
            {
                MoveLeft();
            }
        }
        else if (LeftS.rot.y < RightS.rot.y)
        {
            MoveRight();
        }
        else if (LeftS.rot.y > RightS.rot.y)
        {
            MoveLeft();
        }

        if (this.FrontS.distance < 3f)
        {
            MoveBack();
        }
        else
        {
            Moveforward();
        }

        //좌우 센서에 max dist 안에 뭔가 걸리면 좌/우회전
        //정면 센서에 max dist 안에 뭔가 걸리면 뒤로 후진
        //두 경우 모두 아니면 직진.

        if(this.movespeed > this.moveSpeedadj)
        {
            this.movespeed = this.curmaxmovespeed;
        }

        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);

        this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);

        if(Player.mybody.lap > this.mybody.lap)
        {
            curmaxmovespeed = maxmovespeed * (1 + Player.mybody.lap - this.mybody.lap) * (0.5f + myData.skill);
        }
        else if(Player.mybody.lap == this.mybody.lap)
        {
            curmaxmovespeed = maxmovespeed * (1f + (float)(Player.mybody.LineNumber - this.mybody.LineNumber) / 8f) * (0.5f + myData.skill);
        }
        else if(Player.mybody.lap < this.mybody.lap)
        {
            curmaxmovespeed = (maxmovespeed / 2.0f) * (0.5f + myData.skill);
        }
        else
        {
            curmaxmovespeed = maxmovespeed * (0.5f + myData.skill);
        }

    }

    private void FixedUpdate()
    {
        this.lap = mybody.lap;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.oncol = true;

        if(collision.gameObject.CompareTag("Wall"))
        {
            this.gameObject.transform.position -= this.transform.forward * 2f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.oncol = false;
    }
    
    IEnumerator CheckMistake()
    {
        while (true)
        {
            if(myData.mistakes > Random.Range(0f, 1f))
            {
                mistake = true;
                yield return new WaitForSeconds(2f);
            }
            else
            {
                mistake = false;
                yield return new WaitForSeconds(2f);
            }
        }
    }
    
}
