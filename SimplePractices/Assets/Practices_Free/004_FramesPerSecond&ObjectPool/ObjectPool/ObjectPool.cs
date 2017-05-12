using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    PooledObject prefab;
    List<PooledObject> availabelObjects = new List<PooledObject>();

    public PooledObject GetObject()
    {
       
        //use list to take the last one out of the list whenever a new object required
        PooledObject obj;
        int lastAvailableIndex = availabelObjects.Count - 1;
        if (lastAvailableIndex >= 0)
        {
            obj = availabelObjects[lastAvailableIndex];
            availabelObjects.RemoveAt(lastAvailableIndex);
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate<PooledObject>(prefab);
            // use the pool as the parent for everything that it creates
            obj.transform.SetParent(transform, false);
            obj.Pool = this;
        }
        return obj;
    }


    public static ObjectPool GetPool (PooledObject prefab)
    {
        GameObject obj;
        ObjectPool pool;

        if(Application.isEditor)
        {
            obj = GameObject.Find(prefab.name + " Pool");
            DontDestroyOnLoad(obj);
            if(obj)
            {
                pool = obj.AddComponent<ObjectPool>();
                if(pool)
                {
                    return pool;
                }
            }

       }

        obj = new GameObject(prefab.name + " Pool");
        DontDestroyOnLoad(obj);
        pool = obj.AddComponent<ObjectPool>();
        pool.prefab = prefab;
        return pool;

    }

    public void AddObject(PooledObject obj)
    {
        //Object.Destroy(o.gameObject);
        obj.gameObject.SetActive(false);
        availabelObjects.Add(obj);
    }
}
