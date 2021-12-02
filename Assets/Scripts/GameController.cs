using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private EnemiesOnPlatform[] _allEnemies; //list of platforms with number of enemies on each

    [SerializeField]
    private ShootManager _shootManager;

    [SerializeField]
    private MainCharacter _mainCharacter;

    [SerializeField]
    private WeaponData _weaponData;

    [SerializeField]
    private NavMeshAgent _agent;

    public NavMeshAgent agent => _agent;

    private int _currentPlatform;

    public int currentPlatform => _currentPlatform;

    private Transform _characterTransform;

    private int _platformKillCounter; //how many enemies were killed on current platform

    public void NextPlatform()
    {
        _currentPlatform++;
        _platformKillCounter = 0;
    }

    public void Kill() //when bullet kills enemy
    {
        _platformKillCounter++;
    }

    private void Start()
    {
        _characterTransform = _mainCharacter.gameObject.transform;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (_agent.destination == _characterTransform.position && _platformKillCounter >= _allEnemies[_currentPlatform].numberOfEnemies) //if all enemies on current platform are killed
                _mainCharacter.MoveToNextWayPoint();
            else if (_mainCharacter.isRunning == false)
                _shootManager.Shoot(_weaponData);
        }
    }
}