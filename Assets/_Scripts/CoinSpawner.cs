using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        while (true)
        {
            GameObject coin = Instantiate(_coinPrefab);
            coin.transform.position = new Vector2(Random.Range(-2.0f, 2.0f), 7);
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}
