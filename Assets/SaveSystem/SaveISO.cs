using UnityEngine;

public class SaveISO : MonoBehaviour{

    public ItemUI[] ItemUIArray;

    public string[] ISOArray;

    public int ArrayLength;


    public void vSaveISO() {
        ISOArray = new string[10];
        for (int i = 0; i < 10; i++) {
            ISOArray[i] = ItemUIArray[i].ISO.Name;
        }
    }

    public void vLoadISO() {
        for (int i = 0; i < 10; i++) {
            ItemUIArray[i].vRefreshISO(Resources.Load<ItemSO>("ISO/" + ISOArray[i]));
        }
    }
}
