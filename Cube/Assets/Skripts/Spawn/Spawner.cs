using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Creature[] _easy;
    [SerializeField] private Creature[] _medium;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _time;
    [SerializeField] private float _speed = 1f;

    private ScoreController _scoreController;
    private float _elapseonTime = 0f;

    private void Start()
    {
        _scoreController = gameObject.GetComponent<ScoreController>();

        foreach (var enemy in _easy)
        {
            enemy.Init(this);
        }
        foreach (var enemy in _medium)
        {
            enemy.Init(this);
        }
    }

    private void Update()
    {
        Spawn();
    }

    private void MoveObject()
    {
        _speed += Time.deltaTime * _secondsBetweenSpawn;
    }

    public void Spawn()
    {
        _elapseonTime += Time.deltaTime;

         Creature enemy = null;
        if (_elapseonTime >= _time)
        {
            _elapseonTime = 0f;

            if (_scoreController.ScoreTraveled < _scoreController.Score)
            {
                int randomSpawn = Random.Range(0, _easy.Length);
                enemy = _easy[randomSpawn];
            }
            else if (_scoreController.ScoreTraveled > _scoreController.Score)
            {
                int randomSpawn = Random.Range(0, _medium.Length);
                enemy = _medium[randomSpawn];
            }

            enemy.Spawn(_spawnPoints[enemy.PositionIndex].position, Quaternion.identity, _speed);
        } 
    }
}
