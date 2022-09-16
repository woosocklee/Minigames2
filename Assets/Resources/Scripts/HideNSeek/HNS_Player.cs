using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_Player : MonoBehaviour
{
    // Start is called before the first frame update

    Animator myanimator;

    [SerializeField]
    public float maxhp;
    private float curhp;
    public float Curhp { get { return curhp; } }

    private int score;
    public int Score { get { return score; } }


    public void HPloss(float f)
    {
        this.curhp -= f;
    }

    //CharacterController pcControl;
    [SerializeField]
    private Transform Camarm;
    Rigidbody myrigid;

    public float runSpeed = 6.0f;
    Vector3 velocity;

    public float rotationSpeed = 360.0f;

    public HNS_Weapon Weapon;

    private bool isAttack = false;


    void Start()
    {
        myanimator = this.gameObject.GetComponent<Animator>();
        this.myrigid = this.gameObject.GetComponent<Rigidbody>();
        isAttack = false;
        this.curhp = this.maxhp;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CharControl_Slerp();

        //Debug.Log("HP: " + hp);

        Attack();

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            myrigid.velocity = new Vector3(0, 0, 0);
            myanimator.SetTrigger("Attack");
            isAttack = true;
        }
    }

    void CharControl_Slerp()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal")
                                , 0
                                , Input.GetAxis("Vertical"));

        if(direction.magnitude > 0.01f && !isAttack)
        {
            Vector3 forword = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

            if (Input.GetAxis("Vertical") != 0f && Input.GetAxis("Horizontal") != 0f)
            {
                this.myrigid.velocity = this.myrigid.velocity = new Vector3((Camarm.forward * runSpeed * Input.GetAxis("Vertical") + Camarm.right * runSpeed * Input.GetAxis("Horizontal")).x, 0, (Camarm.forward * runSpeed * Input.GetAxis("Vertical") + Camarm.right * runSpeed * Input.GetAxis("Horizontal")).z)/1.414f;
            }
            this.myrigid.velocity = new Vector3((Camarm.forward * runSpeed * Input.GetAxis("Vertical") + Camarm.right * runSpeed * Input.GetAxis("Horizontal")).x, 0, (Camarm.forward * runSpeed * Input.GetAxis("Vertical") + Camarm.right * runSpeed * Input.GetAxis("Horizontal")).z);
        }

        myanimator.SetFloat("Speed", this.myrigid.velocity.magnitude/2);

    }

    public void SetScore(int score)
    {
        this.score += score;
    }
    

    void StartAttack()
    {
        Weapon.SwordOn();
    }

    void EndAttack()
    {
        isAttack = false;
        Weapon.SwordOff();
    }
}
