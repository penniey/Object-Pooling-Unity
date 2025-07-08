using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Queue<GameObject> _poolQueue = new Queue<GameObject>();
    private GameObject _prefab;
    private Transform _parent;

    public Pool(GameObject prefab, int initialSize, Transform parent = null)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = CreateNewObject();
            obj.SetActive(false);
            _poolQueue.Enqueue(obj);
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Object.Instantiate(_prefab, _parent);
        obj.AddComponent<PooledObject>().Pool = this;
        return obj;
    }

    public GameObject Get()
    {
        if (_poolQueue.Count > 0)
        {
            GameObject obj = _poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return CreateNewObject();
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _poolQueue.Enqueue(obj);
    }
}

public class PooledObject : MonoBehaviour
{
    public Pool Pool { get; set; }

    private void OnDisable()
    {
        if (Pool != null)
        {
            Pool.ReturnToPool(gameObject);
        }
    }
}
