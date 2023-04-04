using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformDistribution : MonoBehaviour
{

    public List<int> xlist;
    public List<int> ylist;
    public List<GameObject> objlist;

    public int size;
    public int objsize;

    public GameObject Bullet;

    public void MakeUD(int maxsize)
    { 
        for(int i = 0; i < maxsize; ++i)
        {
            xlist.Add(i);
        }

        ylist.AddRange(xlist);

        for(int i = 0; i < maxsize; i++)
        {
            ChangeListNumber(xlist, Random.Range(0, maxsize), Random.Range(0, maxsize));
            ChangeListNumber(ylist, Random.Range(0, maxsize), Random.Range(0, maxsize));
        }
    }

    void ChangeListNumber(List<int> targetlist, int indexA, int indexB)
    {
        int A = targetlist[indexA];
        targetlist[indexA] = targetlist[indexB];
        targetlist[indexB] = A;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //리스트 제작.
            MakeUD(size);

            //균등 분포

            foreach (var obj in objlist)
            {
                Destroy(obj);
            }
            objlist.Clear();
            for (int i = 0; i < objsize; i++)
            {
                int j = i;

                while(j > size)
                {
                    j -= size;
                    for(int k = 0; k < size; k++)
                    {
                        ChangeListNumber(xlist, Random.Range(0, size), Random.Range(0, size));
                        ChangeListNumber(ylist, Random.Range(0, size), Random.Range(0, size));
                    }
                }
                Vector3 Curvector = new Vector3(xlist[j], ylist[j], 0);
                objlist.Add(Instantiate(Bullet, Curvector, Bullet.transform.rotation));

                //Debug.Log(Curvector);
            }
        }
    }
}
