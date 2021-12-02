using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private Transform[] _wayPoints;

    private bool _isRunning;

    public bool isRunning => _isRunning;

    public void MoveToNextWayPoint()
    {
        _gameController.agent.SetDestination(_wayPoints[_gameController.currentPlatform].position);
        _gameController.NextPlatform();
        GetComponent<Animator>().SetBool("IsRunning", true);
        _isRunning = true;
    }

    void FixedUpdate()
    {
        if (_gameController.currentPlatform == _wayPoints.Length) //if this is last platform
            Destroy(_gameController); //to avoid errors
        if (_gameController.currentPlatform == _wayPoints.Length && _gameController.agent.destination == transform.position) //if character reach final waypoint
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (_isRunning == true && _gameController.agent.destination == transform.position)
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
            _isRunning = false;
        }
    }
}