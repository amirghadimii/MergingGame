using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    
    private void Awake()
    {
    //this is not a good definition for singlton pattern - search about it
        SharedInstance = this;
    }

    // Update is called once per frame

    public GameObject GetPooledObject(int amountToPool)
    {
         
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            List < bool > ActiveCount=new List<bool>(pooledObjects.Count);
            if (pooledObjects[i].activeInHierarchy)
            {
                
            }
        }





        if (pooledObjects.Count != 0)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
                
            }

        }
        else
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        return null;
    }
}
