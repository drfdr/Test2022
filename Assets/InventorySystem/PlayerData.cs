using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour{
    public string PlayerName;
    public int NumberOfClicks;

    [SerializeField] private Text nameTXT;
    [SerializeField] private Text NoCTXT;
   
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            NumberOfClicks++;
        }
        nameTXT.text = PlayerName + "";
        NoCTXT.text = NumberOfClicks + "";
    }
}
