using UnityEngine;
using UnityEngine.UI;

public class CloseRegionPanel : MonoBehaviour
{
    private Button closeButton;
    public PanelAnimator panelAnimator;

    void Start()
    {
        closeButton = GetComponent<Button>();


        closeButton.onClick.AddListener(() =>
        {
            bool isMobile = ScreenChecker.IsMobileScreen();
            panelAnimator.HidePanel(isMobile);
        });
    }
}
