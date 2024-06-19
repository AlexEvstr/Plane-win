using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _enemySpeed);
    }
}