using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBBackground : MonoBehaviour
{
    // Start is called before the first frame update

    private Renderer renderer;
    static Material backgroundTexture;

    private void Awake()
    {
        this.renderer = this.GetComponent<Renderer>();
    }

    void Start()
    {
        backgroundTexture = renderer.material;
    }

    public float offset;
    public float bgspeed;

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * bgspeed;
        backgroundTexture.SetTextureOffset("_BaseMap", new Vector3(offset,0));

    }
}
