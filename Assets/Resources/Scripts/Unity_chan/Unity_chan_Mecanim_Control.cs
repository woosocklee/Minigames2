using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_chan_Mecanim_Control : MonoBehaviour
{
    // Start is called before the first frame update

    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.pcController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetFloat("Speed", pcController.velocity.magnitude);
        Charcontrol_slerp();
    }

    void Charcontrol_slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        else
        {

        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            this.animator.SetTrigger("Slide");
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            this.animator.SetTrigger("Happy");
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            this.animator.SetBool("Sit", !this.animator.GetBool("Sit"));
        }

        pcController.Move(direction * runSpeed * Time.deltaTime);
    }
}
