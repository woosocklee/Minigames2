using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSWolf : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator myanim;

    public float movespeed;

    public int hp;

    private SpriteRenderer myrenderer;

    [SerializeField]
    public GameObject dyingeffect;

    [SerializeField]
    public GameObject Coin;

    private Rigidbody2D myrigid;
    private Collision2D mycollision;
    bool dying;

    void Start()
    {
        this.myrenderer = this.gameObject.GetComponent<SpriteRenderer>();
        this.myanim = this.gameObject.GetComponent<Animator>();
        this.myanim.Play("WolfMoving");
        this.myrigid = this.gameObject.GetComponent<Rigidbody2D>();
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.hp <= 0)
        {
            StartCoroutine(DeathofWolf());
            
        }
    }

    private void FixedUpdate()
    {
        if(!this.myrigid.isKinematic)
        {
            this.myrigid.velocity = new Vector2(-1 * movespeed,0);
        }
        else
        {
            
            this.myrigid.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Wolfhp--");
        if(collision.gameObject.CompareTag("FireBall") && !dying)
        {
            StartCoroutine("WolfHurt"); 
        }
        else if(collision.gameObject.CompareTag("TransparentWall") && !dying)
        {
            this.transform.position = new Vector3(260, this.transform.position.y, this.transform.position.z);
            this.movespeed += 100;
        }
        else if(collision.gameObject.CompareTag("Player") && !dying)
        {
            Debug.Log("X: " + this.myrigid.velocity.x + "Y: " + this.myrigid.velocity.y);
            collision.gameObject.GetComponent<SSSPlayer>().curhp -= (int)(movespeed / 10f);
            Destroy(this.gameObject);
        }
    }

    IEnumerator WolfHurt()
    {
        Debug.Log("WolfHurtStart");
        this.myrigid.isKinematic = true;
        this.myanim.Play("WolfDamaging");
        this.hp--;
        Color oldColor = this.myrenderer.color;
        this.myrenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.myrenderer.color = oldColor;
        this.myanim.Play("WolfMoving");
        this.myrigid.isKinematic = false;

    }

    IEnumerator DeathofWolf()
    {
        if (!dying)
        {
            dying = true;
            this.myrigid.isKinematic = true;
            //this.myrigid.bodyType = RigidbodyType2D.Static;
            Debug.Log("DeathofWolf");
            this.myrenderer.color = Color.red;
            this.myanim.Play("WolfDamaging");
            Instantiate(dyingeffect, this.gameObject.transform);
            Instantiate(dyingeffect, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            yield return new WaitForSeconds(0.25f);
            this.myanim.Play("WolfDamaging");
            Instantiate(Coin, this.gameObject.transform.position, this.gameObject.transform.rotation);
            yield return new WaitForSeconds(0.25f);
            SSSManager.SSSGM.Score += 100;
            Destroy(this.gameObject);
        }
        

    }
}
