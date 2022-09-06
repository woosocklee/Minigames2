using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAxisMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Car = null;

    public float maxstrain = 30.0f;

    [Range(0,60)]
    public float rotatingspeed = 15.0f;

    void InputWheelAxis()
    {
        //print("���� y�� ����: " + this.transform.localRotation.eulerAngles.y);

        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            float yangle = this.transform.localRotation.eulerAngles.y;
            yangle += (yangle > 180 ? -360 : 0);

            //print("yangle ��: " + yangle);
            if(yangle < maxstrain + 1 && yangle > 0)
            {
                this.transform.Rotate(new Vector3(0, -1 * rotatingspeed, 0) * Time.deltaTime);
            }
            else if(yangle > -1 * maxstrain - 1 && yangle < 0 )
            {
                this.transform.Rotate(new Vector3(0, rotatingspeed, 0) * Time.deltaTime);
            }

            if(yangle < 0.1f && yangle > -0.1f)
            {
                yangle = 0.0f;
            }
        }

    }

    void RotateRight()
    {
        float yangle = this.transform.localRotation.eulerAngles.y;
        yangle += (yangle > 180 ? -360 : 0);
        if (yangle < maxstrain)
        {
            //print("�������� ������");
            this.transform.Rotate(new Vector3(0, rotatingspeed, 0) * Time.deltaTime);
        }
    }

    void RotateLeft()
    {
        float yangle = this.transform.localRotation.eulerAngles.y;
        yangle += (yangle > 180 ? -360 : 0);
        if (yangle > -1 * maxstrain)
        {
            //print("�������� ������");
            this.transform.Rotate(new Vector3(0, -1 * rotatingspeed, 0) * Time.deltaTime);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.InputWheelAxis();
    }
}
