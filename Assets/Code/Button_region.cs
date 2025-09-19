using UnityEngine;
using UnityEngine.UI;

public class Button_region : MonoBehaviour
{
    private Button regionInfoButton;

    public PanelAnimator panelAnimator;
    public PanelTextLoader textLoader;

    public string buttonId; // задаёшь в инспекторе (например, "btn1")

    void Start()
    {
        regionInfoButton = GetComponent<Button>();
        regionInfoButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        bool isMobile = ScreenChecker.IsMobileScreen();

        textLoader.LoadText(buttonId);
        panelAnimator.ShowPanel(isMobile);
    }
}