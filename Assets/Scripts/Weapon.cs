using UnityEngine;

[System.Serializable]
public class Weapon
{
    [SerializeField]
    private float _projectileSpeed;

    public float projectileSpeed => _projectileSpeed;

    [SerializeField]
    private float _reloadTime;

    public float reloadTime => _reloadTime;

    [SerializeField]
    private string _tag;

    public string tag => _tag;
}