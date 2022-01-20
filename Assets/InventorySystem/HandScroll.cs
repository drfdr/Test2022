using UnityEngine;
using UnityEngine.UI;

public class HandScroll : MonoBehaviour{
    [SerializeField] private int x;

    [Header("UI")]
    [SerializeField] Transform InventoryBarGO;
    [SerializeField] private Color color;

    void Start() {
    }

    void Update() {

        if (Input.GetAxis("Mouse ScrollWheel") < 0) { //Up
            if (x >= 10-1) {//LimitTo10
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
                x = 10-1;//LimitTo10
            }
            ChangeX(x);
        }
    }

    public void ChangeX(int x) {
        for (int i = 0; i < 10; i++) {
            if (i == x) {
                transform.GetChild(i).gameObject.SetActive(true);
                InventoryBarGO.GetChild(i).GetChild(0).GetComponent<Image>().color = color;
            } else {
                transform.GetChild(i).gameObject.SetActive(false);
                InventoryBarGO.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
    }
}
