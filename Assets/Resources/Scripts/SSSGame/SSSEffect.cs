using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSEffect : MonoBehaviour
{
    // Start is called before the first frame update

    Animator myanimator;
    SpriteRenderer mySR;

    void Start()
    {
        Debug.Log("ÀÌÆåÆ® »ý¼ºµÊ");
        this.myanimator = this.gameObject.GetComponent<Animator>();
        this.mySR = this.gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(breakaftereffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator breakaftereffect()
    {
        yield return new WaitForSeconds(myanimator.runtimeAnimatorController.animationClips[0].length);
        Destroy(this.gameObject);
    }
}
