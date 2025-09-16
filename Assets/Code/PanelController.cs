using System.Globalization;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private RectTransform regionInfo;

    public Vector2 hiddenPos;       // где панель спрятана (например, (-500, 0))
    public Vector2 shownPos;        // где панель на экране (например, (0, 0))
    public float speed = 5f;
    private Vector2 targetPos;

    void Start()
    {
        regionInfo = GetComponent<RectTransform>();

        regionInfo.anchoredPosition = hiddenPos;
        targetPos = hiddenPos;
    }

    // Update is called once per frame
    void Update()
    {
        regionInfo.anchoredPosition = Vector2.Lerp(
                    regionInfo.anchoredPosition,
                    targetPos,
                    Time.deltaTime * speed
                     );
    }

    public void ShowPanel()
    {
        targetPos = shownPos;
    }

    public void HidePanel()
    {
        targetPos = hiddenPos;
    }
}
