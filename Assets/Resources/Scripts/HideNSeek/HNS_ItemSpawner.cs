using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_ItemSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] ItemSpawnPoints;

    HNS_Item CurItem;

    [SerializeField]
    HNS_Item ItemTemplate;

    [SerializeField]
    HNS_DirectionArrow DA;

    int b4P;

    void Start()
    {
        b4P = ItemSpawnPoints.Length + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurItem == null)
        {
            int i;
            do
            {
                i = Random.Range(0, ItemSpawnPoints.Length);
            }
            while (b4P == i);
            GameObject SpawnPoint = ItemSpawnPoints[i];
            CurItem = Instantiate(ItemTemplate, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            DA.Item = CurItem.gameObject;
            b4P = i;
            
        }
    }
}
