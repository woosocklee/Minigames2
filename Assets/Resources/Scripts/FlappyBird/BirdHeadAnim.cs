using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHeadAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator myanim;
    public GameObject Body;
    public GameObject Main;


    void Jump()
    {
        myanim.Play("move");
    }

    void inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
    }

    void Start()
    {
        this.myanim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs();
        this.Body.transform.eulerAngles = new Vector3(-90 + (Main.GetComponent<Rigidbody>().velocity.y > 0 ? (Main.GetComponent<Rigidbody>().velocity.y) * -4 : (Main.GetComponent<Rigidbody>().velocity.y) * -2), 0, 0);
    }
}
