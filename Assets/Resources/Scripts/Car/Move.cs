using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 15)]
    public float movespeed = 10.0f;
    void Start()
    {
        //this.transform.position = new Vector3(0.0f ,5.0f,0.0f);
        //this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Input_Move();
    }

    void Move_1()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        //this.transform.Translate(new Vector3(moveDelta, 0.0f, 0.0f));
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        transform.position = pos;

    }
    void Move_2()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);

        // forward => ���� = (0,0,1) �� ��ǥ��. Translate�� �ڽ��� Local��ǥ�踦 �������� �̵������ش�. ������ ������ ������⵵ ���ư�.
    }

    void Moveforward()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);

    }
    void MoveBack()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        this.transform.Translate(Vector3.back * moveDelta);

    }
    void MoveRight()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        this.transform.Translate(Vector3.right * moveDelta);

    }
    void MoveLeft()
    {
        float moveDelta = this.movespeed * Time.deltaTime;
        this.transform.Translate(Vector3.left * moveDelta);
    }

    void Input_Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Moveforward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
    }
}
