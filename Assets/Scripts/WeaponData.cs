using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private Weapon _weapon;

    public Weapon weapon => _weapon;
}