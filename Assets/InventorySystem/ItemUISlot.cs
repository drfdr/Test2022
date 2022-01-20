using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUISlot : MonoBehaviour,IDropHandler{

    public int DraggedX;
    public Transform DraggedTransform;
    public int SlotX;
    private GlobalInventory GI;

    private void Start() {
        GI = GlobalInventory.global;
    }



    public void OnDrop(PointerEventData ED) {
        Debug.Log("OnDrop");
        GI.DroppedOnSlot = true;
        GI.SlotGO = gameObject;
        GI.SlotISO = GetComponent<ItemUI>().ISO;
        GI.vSwapISO();

    }

}
