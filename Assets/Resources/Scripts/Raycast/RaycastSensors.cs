using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSensors : MonoBehaviour
{
    [Range(0, 50)]
    public float maxdistance;
    public float distance;
    private Vector3 Rot;
    public Vector3 rot { get { return Rot; } }

    Ray ray;
    RaycastHit rayhit;
    

    Vector3 rayvec;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.up;

        wallcheck();

        this.Rot = new Vector3(0, this.transform.forward.y * (maxdistance - distance), 0);


    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * maxdistance, Color.red);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.blue);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rayhit.point, 0.1f);

        //Vector3 reflect = Vector3.Reflect(this.transform.up, rayhit.normal);
        //Gizmos.DrawLine(rayhit.point, rayhit.point + reflect);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(rayhit.point, rayhit.point + this.Rot );



    }


    void wallcheck()
    {
        if(!Physics.Raycast(ray, out rayhit, maxdistance))
        {
            this.distance = this.maxdistance;
        }
        else
        {
            if (rayhit.collider != null)
            {
                if (rayhit.collider.gameObject.CompareTag("Finish") || rayhit.collider.CompareTag("LapLines"))
                {
                    this.distance = this.maxdistance;
                }
                else
                {
                    this.distance = Vector3.Distance(this.transform.position, rayhit.point);

                }
            }
            else
            {
            this.distance = Vector3.Distance(this.transform.position, rayhit.point);
            }
        }
    }


}
