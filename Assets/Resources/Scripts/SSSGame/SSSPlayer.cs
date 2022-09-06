using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Animator myanimator;
    SpriteRenderer mySPR;
    Rigidbody2D myrigid;


    [SerializeField]
    private float movespeed = 50.0f;

    [SerializeField]
    private GameObject fireball;


    float timer = 0.0f;

    [SerializeField]
    private float firerate = 0.5f;

    public int maxhp;
    public int curhp;
    void Start()
    {
        this.myanimator = this.gameObject.GetComponent<Animator>();
        this.mySPR = this.gameObject.GetComponent<SpriteRenderer>();
        this.myrigid = this.gameObject.GetComponent<Rigidbody2D>();
        this.curhp = maxhp;
    }
    void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            //this.myrigid.velocity += new Vector3(0, 1, 0) * movespeed * Time.deltaTime;
            Debug.Log("goup");
            //this.transform.position += new Vector3(0, 1, 0) * movespeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
           //this.myrigid.velocity -= new Vector3(0, 1, 0) * movespeed * Time.deltaTime;
            Debug.Log("godown");
            //this.transform.position -= new Vector3(0, 1, 0) * movespeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //this.myrigid.velocity += new Vector3(1, 0, 0) * movespeed * Time.deltaTime;
            Debug.Log("goright");
            //this.transform.position += new Vector3(1, 0, 0) * movespeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //this.myrigid.velocity -= new Vector3(1, 0, 0) * movespeed * Time.deltaTime;
            Debug.Log("goleft");
            //this.transform.position -= new Vector3(1, 0, 0) * movespeed * Time.deltaTime;
        }

        this.myrigid.velocity += new Vector2(1 * ((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)), 1 * ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0))) * movespeed * Time.deltaTime;


    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.myanimator.Play("DragonAttack");
            //this.myanimator.SetBool("IsAttack",true);
            Debug.Log("공격!");
        }

        if(Input.GetKey(KeyCode.Space))
        {
            GameObject obj = null;

            if(timer > firerate)
            {

                if (fireball != null)
                {
                    obj = Instantiate(fireball, transform.position + new Vector3(100,0,0), Quaternion.Euler(0,0,90));
                //Invoke("MakeObj", 1.0f);
                }
                timer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.myanimator.Play("DragonIdle");
            //this.myanimator.SetBool("IsAttack",true);
            Debug.Log("공격끝");
        }
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        Attack();
        if(this.curhp <= 0)
        {
            SSSManager.SSSGM.Gameover();
        }
    }
}
