using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSFireBall : MonoBehaviour
{
    // Start is called before the first frame update

    Animator myanim;
    Collider2D mycollider;

    Rigidbody2D myrigid;

    [SerializeField]
    private float fireballspeed;

    private bool dying;


    void Start()
    {
        this.myanim = this.gameObject.GetComponent<Animator>();
        this.mycollider = this.gameObject.GetComponent<Collider2D>();
        this.myrigid = this.gameObject.GetComponent<Rigidbody2D>();
        myanim.Play("Fireball");
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionStart");

        if (collision.gameObject.CompareTag("Wolf"))
        {
            Debug.Log("Destroy!");
            this.dying = true;
            StartCoroutine("DestroyProcess");
        }
        else if(collision.gameObject.CompareTag("TransparentWall"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyProcess()
    {
        this.myanim.Play("FireBallDeath");
        this.mycollider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if(dying)
        {
            this.myrigid.velocity = new Vector2(0, 0);
        }
        else
        {
            myrigid.velocity = new Vector2(1, 0) * fireballspeed;
        }
        
    }

}
