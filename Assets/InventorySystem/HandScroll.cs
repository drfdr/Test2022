using UnityEngine;
using UnityEngine.UI;

public class HandScroll : MonoBehaviour{
    [SerializeField] private int x;

    [Header("UI")]
    [SerializeField] Transform SlotUI;
    [SerializeField] private Color color;


    void Update() {

        if (Input.GetAxis("Mouse ScrollWheel") < 0) { //Up
            if (x >= SlotUI.childCount-1) {
                x = 0;
            } else {
               x++;
                }
             ChangeX(x);
            }

        if (Input.GetAxis("Mouse ScrollWheel") > 0){ //Down
            if (x > 0) {
                x--;
            } else {
                x = SlotUI.childCount - 1;
            }
            ChangeX(x);
        }
    }

    public void ChangeX(int x) {
        for (int i = 0; i <= SlotUI.childCount-1; i++) {
            if (i == x) {
                transform.GetChild(i).gameObject.SetActive(true);
                SlotUI.GetChild(i).GetComponent<Image>().color = color;
            } else {
                transform.GetChild(i).gameObject.SetActive(false);
                SlotUI.GetChild(i).GetComponent<Image>().color = Color.black;
            }
        }
    }
}
