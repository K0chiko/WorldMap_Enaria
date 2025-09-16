using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CloseRegionPanel : MonoBehaviour
{

    private Button regionInfoButton;
    public PanelController panelRegionInfo;

    void Start()
    {
        regionInfoButton = GetComponent<Button>();
        regionInfoButton.onClick.AddListener(panelRegionInfo.HidePanel);

    }



}




