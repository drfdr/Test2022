using UnityEngine;

public class GlobalLinks : MonoBehaviour{
    public Transform Hand;
    public Transform HandUI;
    public GameObject OnTop;
    public GameObject ItemUI;


    public static GlobalLinks global = null;
    void Awake() {
        if (global == null)
            global = this;
        else if (global != this)
            Destroy(global);
    }

}
