using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    private int _randomIndex;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            if (LevelManager.levelIndex < 5)
            {
                _randomIndex = Random.Range(0, 2);
            }
            else
            {
                _randomIndex = Random.Range(0, _enemies.Length);

            }

            GameObject newEnemy = Instantiate(_enemies[_randomIndex]);
            newEnemy.transform.position = new Vector2(Random.Range(-2.0f, 2.0f), 7);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        }
    }
}