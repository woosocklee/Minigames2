using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMain : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1, 15)]
    public float Accel = 5.0f;
    public float rotspeed = 30.0f;
    public float MaxAngle = 60.0f;


    void GoUp()
    {
        this.transform.Translate(new Vector3(0, Accel, 0) * Time.deltaTime);
    }

    void GoDown()
    {
        this.transform.Translate(new Vector3(0, -1 * Accel, 0) * Time.deltaTime);
    }

    void GoForward()
    {
        this.transform.Translate(new Vector3(0, 0, Accel) * Time.deltaTime);
    }

    void GoBackward()
    {
        this.transform.Translate(new Vector3(0, 0, -1 * Accel) * Time.deltaTime);
    }
    void GoRight()
    {
        this.transform.Translate(new Vector3(Accel,0, 0 ) * Time.deltaTime);
    }
    void GoLeft()
    {
        this.transform.Translate(new Vector3(-1 * Accel, 0, 0) * Time.deltaTime);
    }

    void RotateLeft()
    {
        this.transform.Rotate(new Vector3(0, -1 * rotspeed, 0) * Time.deltaTime );
    }

    void RotateRight()
    {
        this.transform.Rotate(new Vector3(0, rotspeed, 0) * Time.deltaTime);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GoUp();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            GoDown();
        }

        if (Input.GetKey(KeyCode.W))
        {
            GoForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GoBackward();
        }
        if(Input.GetKey(KeyCode.A))
        {
            GoLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GoRight();
        }

        if(Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateRight();
        }

    }
}
