using UnityEngine;

public class AccelerometerControl : MonoBehaviour
{
    private float speed = 100.0f;
    private float smoothTime = 0.1f; // Время сглаживания для перемещения
    private float rotationSmoothTime = 0.1f; // Время сглаживания для вращения
    private float maxRotationAngle = 45.0f; // Максимальный угол поворота
    private Vector3 velocity = Vector3.zero;
    private float currentRotationAngle = 0f;
    private float rotationVelocity = 0f;
    private Vector3 direction;

    private void Update()
    {
        // Получение входных данных с акселерометра
        direction = Input.acceleration;

        // Ограничение движения только по оси X (вправо и влево)
        Vector3 movement = new Vector3(direction.x, 0, 0);

        // Перемещение объекта
        Vector3 targetPosition = transform.position + movement * speed * Time.deltaTime;
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        newPosition.y = transform.position.y; // Ограничение движения по оси Y
        transform.position = newPosition;

        // Плавное изменение угла поворота
        float targetRotationAngle = Mathf.Clamp(direction.x, -1, 1) * maxRotationAngle;
        currentRotationAngle = Mathf.SmoothDamp(currentRotationAngle, targetRotationAngle, ref rotationVelocity, rotationSmoothTime);
        transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Ограничение позиции объекта в пределах экрана
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenWidth + objectWidth, screenWidth - objectWidth), transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        // Возвращение в исходное положение вращения, если акселерометр не активен
        if (direction.x == 0)
        {
            currentRotationAngle = Mathf.SmoothDamp(currentRotationAngle, 0, ref rotationVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        }
    }
}
