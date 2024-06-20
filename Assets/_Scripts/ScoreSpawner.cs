using System.Collections;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _scores;

    private void Start()
    {
        StartCoroutine(SpawnScore());
    }

    private IEnumerator SpawnScore()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
            GameObject newScore = Instantiate(_scores[Random.Range(0, _scores.Length)]);
            newScore.transform.position = new Vector2(Random.Range(-2.0f, 2.0f), 7);
            yield return new WaitForSeconds(Random.Range(1, 5f));
        }
    }
}