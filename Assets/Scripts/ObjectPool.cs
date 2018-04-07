using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {


    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region simple singleton
    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

#endregion
    void Start()
    {
      
    }


    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (pools == null || pools.Count == 0)
        {
            Debug.LogError("You need to init pool manually!");
            return;
        }
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("this "+tag+" isn't existed yet. Create new one!");
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pools.Count; i++)
            {
                if (pools[i].tag == tag)
                {
                    var obj = Instantiate(pools[i].prefab);
                    obj.tag = tag;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    break;
                }
            }
            poolDictionary.Add(tag, objectPool);
        }

        var objPool = poolDictionary[tag];
        print(tag + " with pool size: "+objPool.Count);
        GameObject objToRespawn = null;
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i].tag == tag)
            {
                if (objPool.Count >= pools[i].size)
                {
                    objToRespawn = objPool.Dequeue();
                }
                else
                {
                    objToRespawn = Instantiate(pools[i].prefab);
                    objToRespawn.tag = tag;
                }
                break;
            }
        }

        if (objToRespawn == null)
        {
            Debug.LogError("Object to respwn equal null!!!");
        }
        else
        {
            objToRespawn.SetActive(true);
            objToRespawn.transform.position = position;
            objToRespawn.transform.rotation = rotation;
            objPool.Enqueue(objToRespawn);
        }
     

    }
}
