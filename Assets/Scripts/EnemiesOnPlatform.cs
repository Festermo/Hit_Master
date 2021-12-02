using UnityEngine;

[System.Serializable]
public class EnemiesOnPlatform
{
    [SerializeField]
    private int _numberOfEnemies; //how many enemies are standing on this platform

    public int numberOfEnemies => _numberOfEnemies;
}