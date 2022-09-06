using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Animation spartanKing;

    public float runSpeed = 3.0f;
    Vector3 velocity;

    public float rotationSpeed = 360.0f;

    public GameObject Weapon;
    private Rigidbody myrigid;

    [SerializeField]
    bool isDead = false;
    [SerializeField]
    bool isColide = false;
    [SerializeField]
    bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");
        myrigid = this.gameObject.GetComponent<Rigidbody>();
        isAttack = false;
        isColide = false;
        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!(isColide || isAttack || isDead))
        {
            spartanKing.CrossFade("charge", 0.3f);
            myrigid.velocity = this.transform.forward * runSpeed;
        }
    }

    IEnumerator AttackToIdle()
    {
        Debug.Log("A2I");
        isAttack = true;
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
        isAttack = false;
        isColide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Trigger Enter");
        if (Weapon != other.gameObject)
        {
            if (other.gameObject.tag == "Weapon")
            {
                if (isDead != true)
                {
                    isDead = true;
                    SpartanMain.SpartanManager.Score += 100;
                    StartCoroutine("DeathOfSpartan");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy Collision Enter");
        Debug.Log("collision Tag: " + collision.gameObject.tag);

        if (!isAttack && collision.gameObject.CompareTag("Obstacle"))
        {
            isColide = true;
            Debug.Log("Enemy meet Obstacle2");
            StartCoroutine("AttackToIdle");
            Block AttackedBlock = collision.gameObject.GetComponent<Block>();
            if ( AttackedBlock != null)
            {
                AttackedBlock.HP--;
            }
        }
        if(collision.gameObject.CompareTag("Finish"))
        {
            SpartanMain.SpartanManager.Gameover();
        }
        if (Weapon != collision.gameObject)
        {
            if (collision.gameObject.tag == "Weapon")
            {
                if (isDead != true)
                {
                    isDead = true;
                    SpartanMain.SpartanManager.Score += 100;
                    StartCoroutine("DeathOfSpartan");
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColide = false;

    }

    IEnumerator DeathOfSpartan()
    {
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.Play("die");
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {

    }
}

