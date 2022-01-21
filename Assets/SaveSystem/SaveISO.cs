using UnityEngine;

public class SaveISO : MonoBehaviour{

    public ItemUI[] ItemUIArray;

    public string[] ISOArray;

    public int ArrayLength;


    public void Start() {
        ArrayLength = transform.childCount;
        ItemUIArray = new ItemUI[ArrayLength];
        for (int i = 0; i < ArrayLength; i++) {
            ItemUIArray[i] = transform.GetChild(i).GetComponent<ItemUI>();
        }
    }

    public void vSaveISO() {
        ISOArray = new string[ArrayLength];
        for (int i = 0; i < ArrayLength; i++) {
            ISOArray[i] = ItemUIArray[i].ISO.Name;
        }
    }

    public void vLoadISO() {
        for (int i = 0; i < ArrayLength; i++) {
            ItemUIArray[i].vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISOArray[i]));
        }
    }
}
