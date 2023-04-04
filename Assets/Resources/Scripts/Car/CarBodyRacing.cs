using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyRacing : MonoBehaviour
{
    // Start is called before the first frame update


    public int lap;

    private bool lapchecker;

    public int LineNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitobj = other.gameObject;

        if (hitobj.CompareTag("Finish") && this.lapchecker == true && LineNumber > 5)
        {
            Debug.Log("Ʈ�����ݸ��� ����");
            this.lap++;
            this.lapchecker = false;
            LineNumber = 0;
        }
        else if(hitobj.CompareTag("LapLines"))
        {
            Debug.Log("LapLine�� �ε���");
            LineNumber = other.gameObject.GetComponent<LapChecker>().Count;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitobj = other.gameObject;
        if (hitobj.CompareTag("Finish"))
        {
            Debug.Log("Ʈ�����ݸ��� ������");
            this.lapchecker = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitobj = other.gameObject;
        if (hitobj.CompareTag("Finish"))
        {
            Debug.Log("Ʈ�����ݸ��� ����");
            this.lapchecker = true;
        }

    }
    void Start()
    {
        this.lap = 0;
        this.lapchecker = true;
    }
}
