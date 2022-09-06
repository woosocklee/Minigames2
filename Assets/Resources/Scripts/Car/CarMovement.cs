using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 60)]
    public float Accelspeed = 10.0f;
    [Range(0, 120)]
    public float rotspeed = 30.0f;
    public float AccelDelta { get { return Accelspeed * Time.deltaTime * ( this.oncol ? 0.5f : 1f ); } }
    public float rotDelta { get { return rotspeed * Time.deltaTime; } }
    public float moveSpeedadj { get { return (oncol ? maxmovespeed / 100 : maxmovespeed); } }

    [Range(0, 15)]
    public float maxmovespeed = 10.0f;

    private float movespeed;

    public int lap;

    private bool oncol;

    private bool booststate;
    private float boosttimer;
    public float boostcooldown;
    public CarBodyRacing mybody;
    private Rigidbody myrigid;
    
    void BoostOn()
    {
        this.booststate = true;
        this.Accelspeed *= 4;
        this.maxmovespeed *= 4;
        this.boosttimer = 0;
    }

    void BoostOff()
    {
        booststate = false;
        this.Accelspeed /= 4;
        this.maxmovespeed /= 4;
        this.boosttimer = 0;
    }


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
        this.transform.Rotate(new Vector3(0,1,0) * rotDelta);
    }
    void MoveLeft()
    {
        this.transform.Rotate(new Vector3(0, -1, 0) * rotDelta);
    }

    void Input_Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Moveforward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.W))
            {
                MoveRight();
            }
            else if(Input.GetKey(KeyCode.S))
            {
                MoveLeft();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveLeft();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveRight();
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(booststate == false && boosttimer > boostcooldown)
            {
                BoostOn();
            }
        }

    }

    void Start()
    {
        this.lap = 0;
        this.oncol = false;
        this.movespeed = 0;
        myrigid = this.GetComponent<Rigidbody>();
        this.booststate = false;
        this.boosttimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.Input_Move();

        if(this.movespeed > this.moveSpeedadj)
        {
            this.movespeed = this.moveSpeedadj;
        }
        else if(this.movespeed < -1 * this.moveSpeedadj)
        {
            this.movespeed = -1 * this.moveSpeedadj;
        }
        if(this.movespeed > 0)
        {
            this.movespeed -= this.myrigid.drag * Time.deltaTime;
        }
        else if (this.movespeed < 0)
        {
            this.movespeed += this.myrigid.drag * Time.deltaTime;
        }


        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
        this.boosttimer += Time.deltaTime;
        if(this.boosttimer > 4.0f && this.booststate == true)
        {
            BoostOff();
        }
    }

    private void FixedUpdate()
    {
        this.lap = mybody.lap;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Plane"))
        {
            Debug.Log(collision.gameObject.name);
            this.oncol = true;
            this.myrigid.AddForce(Vector3.back,ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Plane"))
        {
            this.oncol = false;
        }
    }


}
