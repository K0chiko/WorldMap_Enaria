using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Button_region : MonoBehaviour
{

    private Button regionInfoButton;
    public PanelController panelRegionInfo;

    void Start()
    {
        regionInfoButton = GetComponent<Button>();
        regionInfoButton.onClick.AddListener(panelRegionInfo.ShowPanel);

    }



}




