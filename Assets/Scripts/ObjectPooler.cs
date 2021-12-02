using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion 

    [SerializeField]
    private List<Pool> _pools;

    private Dictionary<string, Queue<GameObject>> _poolDictionary; //if new weapons will be added

    void Start()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.bulletPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            _poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
            return null;
        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        _poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}