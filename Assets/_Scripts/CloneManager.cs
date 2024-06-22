using UnityEngine;

public class CloneManager : MonoBehaviour
{
    public GameObject original;  // Ссылка на оригинальный объект самолета
    private GameObject clone;    // Ссылка на клон объекта
    [SerializeField] private AudioAndVibroGame _audioAndVibroGame;

    void Start()
    {
        // Можно инициализировать оригинальный объект в Start
        if (original == null)
        {
            original = this.gameObject;
        }
    }

    public void CreateClone()
    {
        if (clone == null)
        {
            _audioAndVibroGame.PlayPercent100AudioClip();
            clone = Instantiate(original, original.transform.position, original.transform.rotation);
            // Удалить скрипты управления с клона
            if (clone.GetComponent<AccelerometerControl>() != null)
            {
                Destroy(clone.GetComponent<AccelerometerControl>());
            }
            if (clone.GetComponent<TouchControl>() != null)
            {
                Destroy(clone.GetComponent<TouchControl>());
            }
            // Добавить компонент для обратного движения
            ReverseMovement reverseMovement = clone.AddComponent<ReverseMovement>();
            reverseMovement.Initialize(original);
            // Уничтожить клон через 5 секунд
            Destroy(clone, 5f);
        }
    }
}
