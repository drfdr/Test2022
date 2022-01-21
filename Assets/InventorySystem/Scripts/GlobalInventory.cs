using UnityEngine;
using UnityEngine.UI;

public class GlobalInventory : MonoBehaviour {


    public int DragX;
    public ItemSO DragISO;
    public GameObject DragGO;
    public GameObject DragGOBag;

    public int SlotX;
    public ItemSO SlotISO;
    public GameObject SlotGO;
    public GameObject SlotGOBag;

    public bool DroppedOnFilledSlot;

    #region Global
    public static GlobalInventory global = null;
    void Awake() {
        if (global == null)
            global = this;
        else if (global != this)
            Destroy(global);
    }
    #endregion


    public void vSwapItemsUI() {

        if (DroppedOnFilledSlot) {
            SlotX = SlotGO.transform.GetSiblingIndex();
            SlotGOBag = SlotGO.GetComponent<ItemUI>().Bag;

            DragGO.transform.SetSiblingIndex(SlotX);
            SlotGO.transform.SetSiblingIndex(DragX);
            DroppedOnFilledSlot = false;
        } 
    }

    public void vSwapISO() {

        if (DroppedOnFilledSlot) {
            DragGO.GetComponent<ItemUI>().vRefreshISO(SlotISO);
            SlotGO.GetComponent<ItemUI>().vRefreshISO(DragISO);
        }
    }
}
