using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameEvent _killCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
            _killCount.Raise();
        gameObject.SetActive(false);
    }
}