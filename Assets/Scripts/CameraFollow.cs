using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _mainCharacter;

    [SerializeField]
    private Vector3 _offset;

    void FixedUpdate()
    {
        transform.position = _mainCharacter.position + _offset;
    }
}