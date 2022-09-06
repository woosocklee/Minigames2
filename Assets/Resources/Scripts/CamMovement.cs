using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Camobj = null;

    [Range(0,10)]
    public float movespeed = 0.0f;

    private float moveDelta { get {return movespeed*Time.deltaTime; } }

    public float maxstrain = 3.0f;

    void CamForward()
    {
        if (Vector3.Distance(this.Camobj.transform.localPosition, this.transform.localPosition) < maxstrain)
        {
            this.transform.localPosition +=  Vector3.forward * moveDelta * -1;
        }


    }
    void CamBack()
    {
        if (Vector3.Distance(this.Camobj.transform.localPosition, this.transform.localPosition) < maxstrain)
        {
            this.transform.localPosition += Vector3.forward * moveDelta * 1;
        }

    }
    void MoveRight()
    {
        if(Mathf.Abs(this.transform.rotation.y) < maxstrain )
        {
        this.transform.rotation = Quaternion.Euler(new Vector3(0,-1,0) * moveDelta);
        }
    }
    void MoveLeft()
    {
        if (Mathf.Abs(this.transform.rotation.y) < maxstrain)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 1, 0) * moveDelta);
        }
    }

    void Input_Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            CamForward();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            CamBack();
        }
        else if(Vector3.Distance(this.transform.position, new Vector3(0,3,-3)) > 0.1f )
        {
            this.transform.localPosition += (new Vector3(0, 3, -3) - this.transform.localPosition).normalized * moveDelta;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveRight();
            }
            else if (Input.GetKey(KeyCode.S))
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
        //else if(this.transform.rotation != this.Car.transform.rotation)
        //{
        //    this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0) - this.transform.);
        //}
   }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input_Move();
    }
}
