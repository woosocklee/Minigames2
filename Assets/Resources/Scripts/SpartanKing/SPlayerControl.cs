using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerControl : MonoBehaviour
{
    Animation spartanKing;

    //CharacterController pcControl;
    [SerializeField]
    private Transform Camarm;
    Rigidbody myrigid;

    public float runSpeed = 6.0f;
    Vector3 velocity;

    public float rotationSpeed = 360.0f;

    public GameObject Weapon;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");
        myrigid = gameObject.GetComponent<Rigidbody>();
        //pcControl = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Animation_Play_3();
        //CharacterControl();
        Animation_Play_3();
        CharacterControl_Slerp();
        //this.transform.localEulerAngles = new Vector3(0, 0, 0);
        
    }
    void Animation_Play()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.Play("attack");
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            spartanKing.Play("idle");
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            spartanKing.Play("walk");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            spartanKing.Play("run");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            spartanKing.Play("charge");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            spartanKing.Play("idlebattle");
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            spartanKing.Play("resist");
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            spartanKing.Play("victory");
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            spartanKing.Play("salute");
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            spartanKing.Play("diehard");
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            spartanKing.Play("die");
        }
    }
    void Animation_Play_2()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.wrapMode = WrapMode.Once;
            //spartanKing.Play("attack");
            spartanKing.CrossFade("attack", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("attack");
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idle");
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("walk");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("run");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("charge");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idlebattle");
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("resist");
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("victory");
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("salute");
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("diehard");
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("die");
        }
    }

    void Animation_Play_3()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.myrigid.velocity = new Vector3(0, 0, 0);
            if (spartanKing.IsPlaying("attack") != true)
            {
                
                StartCoroutine("AttackToIdle");
                Debug.Log("АјАн");
            }
        }
        
    }

    IEnumerator AttackToIdle()
    {
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);
        Weapon.SetActive(true);
        Weapon.GetComponent<CapsuleCollider>().enabled = true;
        //float delayTime = 1.167f - 0.3f;

        float delayTime = spartanKing.GetClip("attack").length - 0.3f;
        yield return new WaitForSeconds(delayTime);
        Weapon.GetComponent<CapsuleCollider>().enabled = false;
        Weapon.SetActive(false);
        if (spartanKing.IsPlaying("die") != true)
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idle");
        }
    }

    void CharacterControl()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal")
                                , 0
                                , Input.GetAxis("Vertical"));
        velocity *= runSpeed;

        if (velocity.magnitude > 0.5f)
        {
            spartanKing.CrossFade("run", 0.3f);
            transform.LookAt(transform.position + velocity);
        }
        else
        {
            spartanKing.CrossFade("idle", 0.3f);
        }
        //pcControl.Move(velocity * Time.deltaTime+Physics.gravity*0.01f);
        //pcControl.SimpleMove(velocity);
        
    }

    void CharacterControl_Slerp()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal")
                                , 0
                                , Input.GetAxis("Vertical"));
        //direction *= runSpeed;

        if (direction.sqrMagnitude > 0.01f && !spartanKing.IsPlaying("attack"))
        {
            spartanKing.CrossFade("run", 0.3f);

            Vector3 forword = Vector3.Slerp(transform.forward, direction, rotationSpeed*Time.deltaTime/Vector3.Angle(transform.forward, direction));

            //this.transform.Rotate(new Vector3(0, 1, 0) * Input.GetAxis("Horizontal"));
            if(Input.GetAxis("Vertical") != 0f && Input.GetAxis("Horizontal") != 0f)
            {
                this.myrigid.velocity = (Camarm.forward * runSpeed * Input.GetAxis("Vertical") / 1.414f) + (Camarm.right * runSpeed * Input.GetAxis("Horizontal") / 1.414f);
            }
            this.myrigid.velocity = Camarm.forward * runSpeed * Input.GetAxis("Vertical") + Camarm.right * runSpeed * Input.GetAxis("Horizontal");
        }
        else
        {
            if (spartanKing.IsPlaying("idie") != true)
            {
                if (spartanKing.IsPlaying("attack") != true)
                {
                    spartanKing.CrossFade("idle", 0.3f);
                }
            }
        }
        //pcControl.Move(direction * runSpeed* Time.deltaTime+Physics.gravity*0.01f);
        //pcControl.SimpleMove(direction * runSpeed);
        //this.transform.Translate(direction * runSpeed * Time.deltaTime );

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Weapon != other.gameObject)
        {
            if (other.gameObject.tag == "Weapon")
            {
                if (isDead != true)
                {
                    isDead = true;
                    spartanKing.wrapMode = WrapMode.Once;
                    spartanKing.Play("die");
                }
            }
        }
    }
}
