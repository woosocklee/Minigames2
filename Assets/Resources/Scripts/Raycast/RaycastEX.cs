using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEX : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 10.0f;
    [Range(0, 60)]
    public float rotatingSpeed = 30.0f;

    public GameObject leftRay;
    public GameObject rightRay;
    private RaycastHit lefthit;
    private RaycastHit righthit;



    private RaycastHit rayHit;
    private RaycastHit[] rayhits;
    private Ray ray;
    private Vector3 reflect;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        //ray = new Ray(transform.position, transform.forward);
        
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        
        

    }

    void Ray_1()
    {
        if(Physics.Raycast(ray, out rayHit, distance))
        {
            print(rayHit.collider.gameObject.name + " dist: " + rayHit.distance);
            reflect = Vector3.Reflect(this.transform.forward, rayHit.normal);
            Vector3 castingvec = Vector3.Normalize(this.transform.forward + reflect);
            print(castingvec);
            this.transform.Rotate(new Vector3(0,castingvec.x,0) *rotatingSpeed * Time.deltaTime);
        }
    }

    void Ray_2()
    {
        rayhits = Physics.RaycastAll(ray, distance);
        foreach(RaycastHit casted in rayhits)
        {
            print(casted.collider.gameObject.name + "hit!");
        }
    }
    void Ray_3()
    {
        rayhits = Physics.RaycastAll(ray, distance);
        foreach (RaycastHit casted in rayhits)
        {
            if(casted.collider.gameObject.tag == "Obstacle")
            {
                print(casted.collider.gameObject.name + " hit! -- Tag: " + casted.collider.gameObject.tag);
            }

            if(casted.collider.gameObject.layer == LayerMask.NameToLayer("Second"))
            {
                print(casted.collider.gameObject.name + " hit! -- Layer: " + casted.collider.gameObject.layer);

            }
            if (casted.collider.gameObject.layer == LayerMask.NameToLayer("First"))
            {
                print(casted.collider.gameObject.name + " hit! -- Layer: " + casted.collider.gameObject.layer);

            }



        }
        rayhits = Physics.SphereCastAll(ray, 0.0f, distance);
        foreach(RaycastHit casted in rayhits)
        {
            print(casted.collider.gameObject.name + " hit!");
        }
    }
    private void OnDrawGizmos()
    {
        ondrawgizmo3();
    }

    void ondrawgizmo1()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        Gizmos.color = new Color32(255, 255, 0, 255);

        // : origin
        //Gizmos.DrawSphere(ray.origin, distance);
        Gizmos.DrawWireSphere(ray.origin, distance);


    }

    void ondrawgizmo2()
    {
        if (rayhits != null)
        {
            foreach (RaycastHit casted in rayhits)
            {
                if (casted.collider != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(casted.point, 0.1f);

                    // : to point
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.position, transform.position + transform.forward * casted.distance);

                    // : normal vec

                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(casted.point, casted.point + casted.normal);

                    // : reflction vec
                    Vector3 reflect = Vector3.Reflect(this.transform.forward, casted.normal);
                    Gizmos.DrawLine(casted.point, casted.point + reflect);
                }
            }
        }
    }

    void ondrawgizmo3()
    { 
        if (rayHit.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rayHit.point, 0.1f);

            // : to point
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayHit.distance);

            // : normal vec

            Gizmos.color = Color.white;
            Gizmos.DrawLine(rayHit.point, rayHit.point + rayHit.normal);

            // : reflction vec
            Vector3 reflect = Vector3.Reflect(this.transform.forward, rayHit.normal);
            Gizmos.DrawLine(rayHit.point, rayHit.point + reflect);
        }
    }

}

