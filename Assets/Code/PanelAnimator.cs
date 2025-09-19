using UnityEngine;

public class PanelAnimator : MonoBehaviour
{
    private RectTransform regionInfo;

    public Vector2 hiddenPos;       // ������� ������� ��� ��
    public Vector2 shownPos;        // ������� ��� ��
    public float speed = 5f;

    private Vector2 targetPos;

    // ��� ���������� ��������
    private Vector2 mobileShownPos = Vector2.zero;  // �����
    private Vector2 mobileHiddenPos = new Vector2(Screen.width * 2, Screen.height * 2); // �������� ����
    private Vector2 mobileSizeDelta = Vector2.zero; // ������������ �� ���� �����

    private Vector2 originalSizeDelta;

    void Start()
    {
        regionInfo = GetComponent<RectTransform>();
        originalSizeDelta = regionInfo.sizeDelta;

        regionInfo.anchoredPosition = hiddenPos;
        targetPos = hiddenPos;
    }

    void Update()
    {
        regionInfo.anchoredPosition = Vector2.Lerp(regionInfo.anchoredPosition, targetPos, Time.deltaTime * speed);
    }

    // ����� ������ � ������ ����������
    public void ShowPanel(bool isMobile)
    {
        if (isMobile)
        {
            regionInfo.anchorMin = Vector2.zero;
            regionInfo.anchorMax = Vector2.one;
            regionInfo.anchoredPosition = Vector2.zero;
            regionInfo.sizeDelta = mobileSizeDelta;
            targetPos = mobileShownPos;
            speed *= 500;
        }
        else
        {
            regionInfo.anchorMin = new Vector2(0, 0.5f);
            regionInfo.anchorMax = new Vector2(0, 0.5f);
            regionInfo.sizeDelta = originalSizeDelta;
            targetPos = shownPos;
        }
    }

    // ������� ������ � ������ ����������
    public void HidePanel(bool isMobile)
    {
        if (isMobile)
        {
            targetPos = mobileHiddenPos;
        }
        else
        {
            targetPos = hiddenPos;
        }
    }
}
