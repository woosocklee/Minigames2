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

    [Range(0, 60)]
    public float Accelspeed = 10.0f;
    [Range(0, 120)]
    public float rotspeed = 30.0f;
    public float AccelDelta { get { return Accelspeed * Time.deltaTime; } }
    public float rotDelta { get { return rotspeed * Time.deltaTime; } }

    public float moveSpeedadj { get { return (oncol? maxmovespeed / 2: maxmovespeed); } }

    [Range(0, 15)]
    public float maxmovespeed = 10.0f;

    private float movespeed;

    private bool oncol;

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
    }

    // Update is called once per frame
    void Update()
    {
        if( LeftS.rot.y < RightS.rot.y )
        {
            MoveRight();
        }
        else if (LeftS.rot.y > RightS.rot.y)
        {
            MoveLeft();
        }

        if(this.FrontS.distance != this.FrontS.maxdistance)
        {
            MoveBack();
        }
        else
        {
            Moveforward();
        }

        //좌우 센서에 maxdist 안에 뭔가 걸리면 좌/우회전
        //정면 센서에 maxdist 안에 뭔가 걸리면 뒤로 후진
        //두 경우 모두 아니면 직진.

        if(this.movespeed > this.moveSpeedadj)
        {
            this.movespeed = this.maxmovespeed;
        }

        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);

        this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);


    }

    private void FixedUpdate()
    {
        this.lap = mybody.lap;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.oncol = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        this.oncol = false;
    }


}
