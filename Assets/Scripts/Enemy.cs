using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
            Destroy(gameObject);
    }
}