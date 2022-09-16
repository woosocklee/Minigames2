using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HNS_Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent Nagent;
    Animator Myanimator;
    public GameObject target;
    float movespeed;
    bool isHit;

    [SerializeField]
    private float killingspeed = 2.0f;

    void Start()
    {
        Nagent = this.gameObject.GetComponent<NavMeshAgent>();
        Myanimator = this.gameObject.GetComponent<Animator>();
        isHit = false;
        movespeed = Nagent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHit)
        {
            Nagent.destination = target.transform.position;
            Myanimator.SetFloat("Speed", Nagent.velocity.magnitude);
            Nagent.speed = movespeed;
        }
        else
        {
            Nagent.destination = this.transform.position;
            Myanimator.SetFloat("Speed", 0);
            Nagent.speed = 0;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("CollwithP");
            collision.gameObject.GetComponent<HNS_Player>().HPloss(Time.deltaTime * killingspeed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isHit)
        {
            Debug.Log("TrigwithP");
            other.gameObject.GetComponent<HNS_Player>().HPloss(Time.deltaTime * killingspeed);
        }
    }


    public void Ouch()
    {
        Myanimator.SetBool("GetHit", true);
        isHit = true;
    }

    void Notanymore()
    {
        isHit = false;
        Myanimator.SetBool("GetHit", false);
    }

}
