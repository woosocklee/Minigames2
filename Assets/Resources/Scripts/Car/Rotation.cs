using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0,10)]
    public GameObject target = null;

    void Start()
    {
        //오일러 회전 반복하면 짐벌락 현상 일어날 수 있음.
        //transform.eulerAngles(new Vector3(0, 45, 0)); 요런거.
        //rotate1();

        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate2();
        //rotate3();
        //if(target == null)
        //{
        //    rotate6();
        //}
        //else
        //{
        //    lookat1();//타겟 방향으로 회전하기
        //}

        Input_Rot();
    }

    //public float rot = 1.0f;
    void rotate1() // global 좌표계 사용
    {
        Quaternion Q = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        transform.rotation = Q;
    }

    void rotate2() // local 좌표계 사용
    {
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void rotate3()
    {
        this.transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.up);
    }

    float speed = 10.0f;
    void rotate4()
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);
    }
    void rotate5()
    {
        float rot = speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rot);
    }
    void rotate6()
    {
        float rot = speed * Time.deltaTime;
        this.transform.RotateAround(new Vector3(3, 0, 0), Vector3.up, rot);
    }

    void lookat1()
    {
        Vector3 dirtotarget = target.transform.position - this.transform.position;
        this.transform.forward = dirtotarget.normalized;
    }
    void lookat2()
    {
        Vector3 dirtotarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(dirtotarget, Vector3.up);
    }


    void Input_Rot()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            float rot = speed * Time.deltaTime;
            transform.Rotate(Vector3.up * rot);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            float rot = speed * Time.deltaTime;
            transform.Rotate(Vector3.down * rot);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float rot = speed * Time.deltaTime;
            transform.Rotate(Vector3.right * rot);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            float rot = speed * Time.deltaTime;
            transform.Rotate(Vector3.left * rot);
        }
    }
}
