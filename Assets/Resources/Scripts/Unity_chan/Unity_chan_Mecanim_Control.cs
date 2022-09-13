using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unity_chan_Mecanim_Control : MonoBehaviour
{
    // Start is called before the first frame update


    // Start is called before the first frame update
    [SerializeField]
    private Transform Charbody;
    [SerializeField]
    private Transform Camarm;

    void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.pcController = this.gameObject.GetComponent<CharacterController>();
        this.Nagent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CamMoveRot();
    }

    void CamMoveRot()
    {
        Vector2 MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Debug.Log(MouseDelta);
        Vector3 Camangle = Camarm.rotation.eulerAngles;
        float xrot = Camangle.x - MouseDelta.y;

        if (xrot < 180f)
        {
            xrot = Mathf.Clamp(xrot, -1f, 70f);
        }
        else
        {
            xrot = Mathf.Clamp(xrot, 335f, 361f);
        }

        Camarm.rotation = Quaternion.Euler(xrot, Camangle.y + MouseDelta.x, Camangle.z);
        Charbody.rotation = Quaternion.Euler(Charbody.rotation.eulerAngles.x, Camangle.y + MouseDelta.x, Camangle.z);

    }




    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    NavMeshAgent Nagent;


    //void Start()
    //{
    //    this.animator = this.gameObject.GetComponent<Animator>();
    //    this.pcController = this.gameObject.GetComponent<CharacterController>();
    //    this.Nagent = this.gameObject.GetComponent<NavMeshAgent>();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    this.animator.SetFloat("Speed", Nagent.velocity.magnitude);
    //    Charcontrol_slerp();
    //    //
    //    //if (Input.GetMouseButtonDown(1))
    //    //{
    //    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //    RaycastHit hit;
    //    //
    //    //    if (Physics.Raycast(ray, out hit))
    //    //    {
    //    //        Nagent.destination = hit.point;
    //    //        Debug.Log(Nagent.destination);
    //    //        //동일한 코드: Nagent.SetDestination(hit.point);
    //    //    }
    //    //}
    //
    //}
    //
    //void Charcontrol_slerp()
    //{
    //    direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //
    //    if(direction.sqrMagnitude > 0.01f)
    //    {
    //        Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
    //        transform.LookAt(transform.position + forward);
    //    }
    //    else
    //    {
    //
    //    }
    //
    //    if(Input.GetKeyDown(KeyCode.F))
    //    {
    //        this.animator.SetTrigger("Slide");
    //    }
    //    if(Input.GetKeyDown(KeyCode.Q))
    //    {
    //        this.animator.SetTrigger("Happy");
    //    }
    //    if(Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        
    //        this.animator.SetBool("Sit", !this.animator.GetBool("Sit"));
    //    }
    //
    //    pcController.Move(direction * runSpeed * Time.deltaTime);
    //}
}
