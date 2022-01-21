using UnityEngine;

public class SaveISO : MonoBehaviour{

    public ItemUI ItemUI1;
    public ItemUI ItemUI2;
    public ItemUI ItemUI3;
    public ItemUI ItemUI4;
    public ItemUI ItemUI5;

    public string ISO1;
    public string ISO2;
    public string ISO3;
    public string ISO4;
    public string ISO5;


    public void vSaveISO() {
        ItemUI1 = transform.GetChild(0).GetComponent<ItemUI>();
        ItemUI2 = transform.GetChild(1).GetComponent<ItemUI>();
        ItemUI3 = transform.GetChild(0).GetComponent<ItemUI>();
        ItemUI4 = transform.GetChild(1).GetComponent<ItemUI>();
        ItemUI5 = transform.GetChild(0).GetComponent<ItemUI>();
        ISO1 = ItemUI1.ISO.Name;
        ISO2 = ItemUI2.ISO.Name;
        ISO3 = ItemUI1.ISO.Name;
        ISO4 = ItemUI2.ISO.Name;
        ISO5 = ItemUI1.ISO.Name;
    }

    public void vLoadISO() {
        ItemUI1.vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISO1));
        ItemUI2.vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISO2));
        ItemUI3.vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISO1));
        ItemUI4.vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISO2));
        ItemUI5.vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISO1));

    }
}
