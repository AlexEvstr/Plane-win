using UnityEngine;

public class ReverseMovement : MonoBehaviour
{
    private GameObject original; // Ссылка на оригинальный объект

    public void Initialize(GameObject original)
    {
        this.original = original;
    }

    void Update()
    {
        if (original != null)
        {
            // Зеркальное перемещение по оси X
            Vector3 mirroredPosition = new Vector3(-original.transform.position.x, original.transform.position.y, original.transform.position.z);
            transform.position = mirroredPosition;

            // Зеркальное вращение по оси Y
            Quaternion mirroredRotation = Quaternion.Euler(original.transform.eulerAngles.x, -original.transform.eulerAngles.y, original.transform.eulerAngles.z);
            transform.rotation = mirroredRotation;
        }
    }
}
