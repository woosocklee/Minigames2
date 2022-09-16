using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject Sword;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwordOn()
    {
        Sword.SetActive(true);
        //Instantiate(Sword);
    }
    public void SwordOff()
    {
        Sword.SetActive(false);
        Debug.Log("SWORDOFF");
        //Destroy(Sword);
    }


}
