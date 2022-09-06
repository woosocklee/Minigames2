using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanKing3DActionCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform Charbody;
    [SerializeField]
    private Transform Camarm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamMoveRot();
    }

    void CamMoveRot()
    {
        Vector2 MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") );
        Vector3 Camangle = Camarm.rotation.eulerAngles;
        float xrot = Camangle.x - MouseDelta.y;

        if(xrot < 180f)
        {
            xrot = Mathf.Clamp(xrot, -1f, 70f);
        }
        else
        {
            xrot = Mathf.Clamp(xrot, 335f, 361f);
        }

        Camarm.rotation = Quaternion.Euler(xrot, Camangle.y + MouseDelta.x , Camangle.z);
        Charbody.rotation = Quaternion.Euler(Charbody.rotation.eulerAngles.x, Camangle.y + MouseDelta.x, Camangle.z);
        
    }

}
