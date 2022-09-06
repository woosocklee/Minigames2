using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public float jumpstatus = 5.0f;
    public Rigidbody myrigid;
    public int score = 0;

    void Jump()
    {
        myrigid.velocity = new Vector3(0,jumpstatus,0);
    }

    void inputs()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
    }


    void Start()
    {
        this.myrigid = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputs();
        if(this.transform.position.y > 0 || this.transform.position.y < -13 )
        {
            Debug.Log("Out of Screen");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")) // 장애물에 닿아 사망
        {
            Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Point"))
        {
            Debug.Log(other.gameObject.name);
            this.score += 100;
            //점수 얻기
        }
    }
}
