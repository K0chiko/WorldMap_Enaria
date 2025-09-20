using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public int edgeSize = 20;             // зона в пикселях у края экрана
    public SpriteRenderer mapRenderer;    // объект карты (спрайт)
    public float dragThreshold = 10f;     // порог в пикселях, чтобы отличать click от drag

    private Vector3 lastMousePos;
    private Vector3 mouseDownPos;

    private float minX, maxX, minY, maxY;

    public static bool ClickBlocked { get; private set; } // флаг для Province

    void Start()
    {
        // размеры карты
        Bounds mapBounds = mapRenderer.bounds;

        // размеры камеры
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        // задаём границы движения камеры
        minX = mapBounds.min.x + halfWidth;
        maxX = mapBounds.max.x - halfWidth;
        minY = mapBounds.min.y + halfHeight;
        maxY = mapBounds.max.y - halfHeight;
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // 1. WASD
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move += new Vector3(h, v, 0);

        // 2. Движение мышью у краёв
        if (Input.mousePosition.x <= edgeSize) move.x -= 1;
        if (Input.mousePosition.x >= Screen.width - edgeSize) move.x += 1;
        if (Input.mousePosition.y <= edgeSize) move.y -= 1;
        if (Input.mousePosition.y >= Screen.height - edgeSize) move.y += 1;

        // 3. Drag ЛКМ / палец
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
            mouseDownPos = Input.mousePosition;
            ClickBlocked = false; // сбрасываем
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;

            // если движение больше порога → это drag
            if ((Input.mousePosition - mouseDownPos).magnitude > dragThreshold)
                ClickBlocked = true;

            // двигаем камеру
            move -= new Vector3(delta.x / 50f, delta.y / 50f, 0);
            lastMousePos = Input.mousePosition;
        }

        // применяем
        transform.position += move * moveSpeed * Time.deltaTime;

        // ограничение камеры по краям карты
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        clampedPos.y = Mathf.Clamp(clampedPos.y, minY, maxY);
        transform.position = clampedPos;
    }
}
