using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IDragHandler, IEndDragHandler,IBeginDragHandler {
    public ItemSO ISO;

    [HideInInspector] public GameObject Bag;
    private bool Hand;
    private GlobalLinks GL;
    private RectTransform RT;
    private CanvasGroup CG;
    private GlobalInventory GI;
    private bool bOnTopOncer;



    private void Start() {
        GL = GlobalLinks.global;
        GI = GlobalInventory.global;
        RT = GetComponent<RectTransform>();
        CG = GetComponent<CanvasGroup>();
        Bag = transform.parent.gameObject;
        vRefreshISO(ISO);
    }


    public void OnBeginDrag(PointerEventData ED) {
        if (!(name == "Empty")) {
            CG.blocksRaycasts = false;
            CG.alpha = .5F;
            GI.DragGO = gameObject;
            GI.DragISO = ISO;
            vOnTop();
        }
    }

    public void OnDrag(PointerEventData ED) {
        if(!(name == "Empty")){
            RT.anchoredPosition += ED.delta;
        }
    }


    public void OnEndDrag(PointerEventData ED) {
        CG.alpha = 1;
        CG.blocksRaycasts = true;
        vLayoutRebuild();
        vOnTopEnd();
    }

    public void vRefreshISO(ItemSO ISO) {
        GetComponent<ItemUI>().ISO = ISO;
        GetComponent<Image>().sprite = ISO.Icon;
        name = ISO.name;
    }

    public void vLayoutRebuild() {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
    }

    public void vOnTop() {
        var canvas = gameObject.AddComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2;
        gameObject.AddComponent<GraphicRaycaster>();
    }
    public void vOnTopEnd() {
        Destroy(GetComponent<GraphicRaycaster>());
        Destroy(GetComponent<Canvas>());
    }
}
