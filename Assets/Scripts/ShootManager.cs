using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField]
    private Transform _gunBarrel;

    private float _timer;

    public void Shoot(WeaponData weaponData)
    {
        if (_timer >= weaponData.weapon.reloadTime)
        {
            _timer = 0;
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position); //get position of touch in worldspace
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 direction = hit.point - _gunBarrel.position;
                Quaternion rotation = Quaternion.LookRotation(direction.normalized);
                GameObject bullet = ObjectPooler.Instance.SpawnFromPool(weaponData.weapon.tag, _gunBarrel.position, rotation);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero; //if it is spawned again from pool
                rb.angularVelocity = Vector3.zero; //same
                rb.AddForce(direction.normalized * weaponData.weapon.projectileSpeed, ForceMode.VelocityChange);
            }
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
}