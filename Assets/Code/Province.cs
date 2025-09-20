using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Province : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Подсветка")]
    public Color baseColor = Color.white;
    public Color highlightColor = Color.yellow;

    [Header("ID для панели")]
    public string provinceId;

    private Material instanceMaterial;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    public PanelAnimator panelAnimator;
    public PanelTextLoader textLoader;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();

        // Делаем уникальный материал для провинции
        instanceMaterial = new Material(meshRenderer.sharedMaterial);
        meshRenderer.material = instanceMaterial;
        instanceMaterial.color = baseColor;

        // Подключаем Mesh к коллайдеру (только для Raycast)
        meshCollider.sharedMesh = GetComponent<MeshFilter>().sharedMesh;
        meshCollider.convex = false;   // пусть остаётся в "естественном" виде
        // isTrigger не ставим! иначе Unity ругнётся
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        instanceMaterial.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        instanceMaterial.color = baseColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CameraController.ClickBlocked)
            return; // клик отменён, т.к. это был drag

        bool isMobile = ScreenChecker.IsMobileScreen();

        textLoader.LoadText(provinceId);
        panelAnimator.ShowPanel(isMobile);
    }


}
