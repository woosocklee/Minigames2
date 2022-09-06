using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSCoin : MonoBehaviour
{
    // Start is called before the first frame update

    Collider2D mycolider;

    public float movespeed;

    void Start()
    {
        Debug.Log("ÄÚÀÎ »ý¼ºµÊ");
        this.mycolider = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Movetoleft();
    }

    void Movetoleft()
    {
        this.transform.position += new Vector3(-1 * movespeed, 0, 0) * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SSSPlayer>())
        {
            SSSManager.SSSGM.Coin += 1;
            Debug.Log("Á¡¼öÈ¹µæ");
            Destroy(this.gameObject);
        }
    }
}
