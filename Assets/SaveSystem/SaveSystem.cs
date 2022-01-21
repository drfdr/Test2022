using UnityEngine;

public class SaveSystem : MonoBehaviour{
    [SerializeField] private PlayerData PD;
    [SerializeField] private SaveISO SISO;
    [SerializeField] private int ArrayLength;
     
    private void Start() {
        LoadGame();
    }

    private void OnApplicationQuit() {

        SaveGame();
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadGame();
        }
    }

    private void SaveGame() {
        SISO.vSaveISO();
        SaveBinary.SaveData(PD, SISO);
    }

    private void LoadGame() {
        SaveSerializable SaveSerializableX = SaveBinary.LoadData();
        PD.PlayerName = SaveSerializableX.PlayerName;
        PD.NumberOfClicks = SaveSerializableX.NumberOfClicks;
        SISO.ISOArray = new string[10];
        for (int i = 0; i < 10; i++) {
            SISO.ISOArray[i] = SaveSerializableX.ISOArray[i];
                }
        SISO.vLoadISO();
    }
}
