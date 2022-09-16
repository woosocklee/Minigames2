using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HNS_DirectionArrow : MonoBehaviour
{
    [SerializeField]
    GameObject Axis;

    public GameObject Item;

    private NavMeshAgent Nagent;


    // Start is called before the first frame update
    void Start()
    {
        this.Nagent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Item != null)
        {
            
            this.Nagent.destination = Item.transform.position;
            Axis.transform.LookAt(Nagent.desiredVelocity /*(this.Nagent.nextPosition - this.transform.position).normalized*/);
            //Debug.Log("NextPos: " + this.Nagent.nextPosition);
            //Debug.Log("curPos: " + this.transform.position);
        }

        this.transform.localPosition = new Vector3(0, 0, 0);
    }
}
