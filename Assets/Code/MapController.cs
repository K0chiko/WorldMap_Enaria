using UnityEngine;

public class MapController : MonoBehaviour
{
    public RectTransform map;   // твоя картинка-карта
    public float moveSpeed = 500f;
    public int edgeSize = 20;   // зона в пикселях для "подведения к краю"
    private Vector3 lastMousePos;

    void Update()
    {
        Vector3 move = Vector3.zero;

        // --- 1. WASD (инверсия) ---
        float h = Input.GetAxis("Horizontal"); // A/D или стрелки
        float v = Input.GetAxis("Vertical");   // W/S или стрелки
        move += new Vector3(-h, -v, 0);

        // --- 2. Движение мышью у краёв (инверсия) ---
        if (Input.mousePosition.x <= edgeSize) move.x += 1;
        if (Input.mousePosition.x >= Screen.width - edgeSize) move.x -= 1;
        if (Input.mousePosition.y <= edgeSize) move.y += 1;
        if (Input.mousePosition.y >= Screen.height - edgeSize) move.y -= 1;

        // --- 3. Drag ЛКМ (оставляем как есть) ---
        if (Input.GetMouseButtonDown(0))
            lastMousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            move += delta / 10f; // чувствительность
            lastMousePos = Input.mousePosition;
        }

        // --- Применяем движение ---
        map.anchoredPosition += (Vector2)(move * moveSpeed * Time.deltaTime);

        // --- Ограничение позиции ---
        Vector2 clampedPos = map.anchoredPosition;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -930f, 930f);
        clampedPos.y = Mathf.Clamp(clampedPos.y, -615f, 615f);
        map.anchoredPosition = clampedPos;
    }
}
