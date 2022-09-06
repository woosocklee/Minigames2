using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyRacing : MonoBehaviour
{
    // Start is called before the first frame update


    public int lap;

    private bool lapchecker;

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitobj = other.gameObject;

        if (hitobj.CompareTag("Finish") && this.lapchecker == true)
        {
            Debug.Log("트리거콜리전 입장");
            this.lap++;
            this.lapchecker = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitobj = other.gameObject;
        if (hitobj.CompareTag("Finish"))
        {
            Debug.Log("트리거콜리전 유지중");
            this.lapchecker = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitobj = other.gameObject;
        if (hitobj.CompareTag("Finish"))
        {
            Debug.Log("트리거콜리전 나감");
            this.lapchecker = true;
        }

    }
    void Start()
    {
        this.lap = 0;
        this.lapchecker = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
