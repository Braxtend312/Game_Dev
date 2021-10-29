using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // what game object is pooled
    public GameObject objPrefab;
    // How many game objects to pool
    public int createdOnStart;

    private List<GameObject> pooledObjs = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < createdOnStart; x++)
        {
            CreateNewObject();
        }
    }
    
    GameObject CreateNewObject()
    {
        //crea game object
        GameObject obj = Instantiate(objPrefab);
        // deactivate game object
         obj.SetActive(false);
        pooledObjs.Add(obj);

        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);

        if(obj == null)
        {
            obj = CreateNewObject();
        }
        obj.SetActive(true);

        return obj;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
