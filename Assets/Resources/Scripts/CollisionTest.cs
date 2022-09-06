using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedRotate = 10.0f;
    public float speedMove = 5.0f;
    //private Rigidbody rigidbody;

    //GameObject other = null;

    void Start()
    {
        //this.rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime;
        move = move * speedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rotate);
        this.gameObject.transform.Translate(Vector3.forward * move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitobj = collision.gameObject;
        print("Collision Enter: " + hitobj);
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitobj = collision.gameObject;
        print("Collision Stay: " + hitobj);
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitobj = collision.gameObject;
        print("Collision Exit: " + hitobj);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitobj = other.gameObject;
        print("Trigger Enter: " + hitobj);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitobj = other.gameObject;
        print("Trigger Stay: " + hitobj);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitobj = other.gameObject;
        print("Trigger Exit: " + hitobj);
    }


}
