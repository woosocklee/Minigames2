using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankHead : MonoBehaviour
{
    // Start is called before the first frame update

    public float headRotateSpeed = 60.0f;


    public float HeadUpperMaxRot = 30.0f;
    public float HeadDownerMaxRot = -10.0f;


    void rotateRight()
    {
        this.transform.Rotate(new Vector3(0,headRotateSpeed,0) * Time.deltaTime);
    }

    void rotateLeft()
    {
        this.transform.Rotate(new Vector3(0, -1 * headRotateSpeed, 0) * Time.deltaTime);
    }

    void rotateUp()
    {
        if(this.transform.localEulerAngles.x > HeadDownerMaxRot)
        {
            this.transform.Rotate(new Vector3(-1 * headRotateSpeed, 0, 0) * Time.deltaTime);
        }
    }

    void rotateDown()
    {
        if (this.transform.localEulerAngles.x < HeadUpperMaxRot)
        {
            this.transform.Rotate(new Vector3(headRotateSpeed, 0, 0) * Time.deltaTime);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputhead();
    }

    void inputhead()
    {
        if(Input.GetKey(KeyCode.Keypad4))
        {
            rotateLeft();
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            rotateRight();
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            rotateUp();
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            rotateDown();
        }


    }

}
