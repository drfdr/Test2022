using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {

    public ItemSO ISO;

    public GameObject Bag;

    public int x;

    private Image IMG;
    private GlobalLinks GL;
    private Item sItem;
    private RectTransform RT;
    private CanvasGroup CG;
    private GlobalInventory GI;


    private void Awake() {
        RT = GetComponent<RectTransform>();
        CG = GetComponent<CanvasGroup>();
        IMG = GetComponent<Image>();
        Bag = transform.parent.gameObject;
    }

    private void Start() {
        GL = GlobalLinks.global;
        GI = GlobalInventory.global;
        if (ISO) {
            vRefreshISO(ISO);
        }
    }

    public void OnPointerDown(PointerEventData ED) {
        CG.blocksRaycasts = false;
        CG.alpha = .5F;
        GI.DragGO = gameObject;
        GI.DragISO = ISO;
    }


    public void OnDrag(PointerEventData ED) {
        RT.anchoredPosition += ED.delta;
     
    }


    public void OnEndDrag(PointerEventData ED) {
        CG.alpha = 1;
        CG.blocksRaycasts = true;
        vLayoutRebuild();
    }

    public void vLinkData() {
        x = transform.GetSiblingIndex();
        if (x <= Bag.transform.childCount - 1) {
            sItem = Bag.transform.GetChild(x).GetComponent<Item>();
            IMG.sprite = sItem.Image;
        }
    }

    public void vRefreshISO(ItemSO ISO) {
        GetComponent<ItemUI>().ISO = ISO;
        GetComponent<Image>().sprite = ISO.Icon;
        name = ISO.name;
    }

    public void vLayoutRebuild() {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
    }
}
