using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private float speed = 5.0f;
    [SerializeField]
    private float smoothTime = 0.3f; // Время сглаживания
    [SerializeField]
    private float rotationSmoothTime = 0.1f; // Время сглаживания для вращения
    [SerializeField]
    private float maxRotationAngle = 45.0f; // Максимальный угол поворота
    private Vector3 velocity = Vector3.zero;
    private float currentRotationAngle = 0f;
    private float rotationVelocity = 0f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Получение смещения по оси X
                float moveDirection = touch.deltaPosition.x;

                // Перемещение объекта в сторону касания с плавным сглаживанием
                Vector3 targetPosition = transform.position + new Vector3(moveDirection, 0, 0) * speed * Time.deltaTime;
                Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
                newPosition.y = transform.position.y; // Ограничение движения по оси Y
                transform.position = newPosition;

                // Плавное изменение угла поворота
                float targetRotationAngle = Mathf.Clamp(moveDirection, -1, 1) * maxRotationAngle;
                currentRotationAngle = Mathf.SmoothDamp(currentRotationAngle, targetRotationAngle, ref rotationVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Возвращение в исходное положение вращения
                currentRotationAngle = Mathf.SmoothDamp(currentRotationAngle, 0, ref rotationVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
            }

            // Ограничение позиции объекта в пределах экрана
            float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
            float objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenWidth + objectWidth, screenWidth - objectWidth), transform.position.y, transform.position.z);
        }
        else
        {
            // Возвращение в исходное положение вращения, если нет касаний
            currentRotationAngle = Mathf.SmoothDamp(currentRotationAngle, 0, ref rotationVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        }
    }
}
