using UnityEngine;

public class PlaneTriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "UFO")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "scoreObject")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}