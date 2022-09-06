using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBody : MonoBehaviour
{

    public float maxFBangle = 20.0f;
    public float maxLRangle = 40.0f;
    void RotateLeft()
    {
        float zangle = this.transform.localRotation.eulerAngles.z;
        zangle = zangle + (zangle > 180 ? -360 : 0);
        if (zangle < maxLRangle)
        {
            this.transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
        }
    }

    void RotateRight()
    {

        float zangle = this.transform.localRotation.eulerAngles.z;
        zangle = zangle + (zangle > 180 ? -360 : 0);

        if (zangle > -1 * maxLRangle)
        {
            this.transform.Rotate(new Vector3(0, 0, -60) * Time.deltaTime);
        }
    }

    void RotateUpper()
    {
        float xangle = this.transform.localRotation.eulerAngles.x;
        xangle = xangle + (xangle > 180 ? -360 : 0);
        if (xangle > -1 * maxFBangle)
        {
            this.transform.Rotate(new Vector3(-60, 0, 0) * Time.deltaTime);
        }
    }

    void RotateLower()
    {
        float xangle = this.transform.localRotation.eulerAngles.x;
        xangle = xangle + (xangle > 180 ? -360 : 0);

        if (xangle < maxFBangle)
        {
            this.transform.Rotate(new Vector3(60, 0, 0) * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("xangle: " + xangle + "\n");
        //print("zangle: " + zangle + "\n");
        if (Input.GetKey(KeyCode.W))
        {
            RotateLower();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RotateUpper();
        }
        else
        {
            float xangle = this.transform.localRotation.eulerAngles.x;
            xangle = xangle + (xangle > 180 ? -360 : 0);

            if (xangle > 0)
            {
                //print("x방향 + 에서 0으로 돌아가는중");
                this.transform.Rotate(new Vector3(-60, 0, 0) * Time.deltaTime);
            }
            else if (xangle < 0)
            {
                //print("x방향 - 에서 0으로 돌아가는중");
                this.transform.Rotate(new Vector3(60, 0, 0) * Time.deltaTime);
            }
            print("z방향 + 에서 0으로 돌아가는중");
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            float zangle = this.transform.localRotation.eulerAngles.z;
            zangle = zangle + (zangle > 180 ? -360 : 0);

            if (zangle > 0)
            {
                print("z방향 + 에서 0으로 돌아가는중");
                this.transform.Rotate(new Vector3(0, 0, -60) * Time.deltaTime);
            }
            else if (zangle < 0)
            {
                print("z방향 - 에서 0으로 돌아가는중");
                this.transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
            }
        }

        this.transform.localRotation = new Quaternion(this.transform.localRotation.x, 0, this.transform.localRotation.z, this.transform.localRotation.w);
        //print(this.transform.localRotation);
    }

}
