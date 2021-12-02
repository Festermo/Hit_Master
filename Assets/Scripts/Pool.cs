using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField]
    private string _tag;

    public string tag => _tag;

    [SerializeField]
    private GameObject _bulletPrefab;

    public GameObject bulletPrefab => _bulletPrefab;

    [SerializeField]
    private int _size; //how many active bullets may be at scene at same time

    public int size => _size;
}