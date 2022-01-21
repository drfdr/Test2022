using UnityEngine;

public class SaveSystem : MonoBehaviour{
    [SerializeField] private PlayerData PD;
    [SerializeField] private SaveISO SISO;
     
    private void Start() {
    }

    private void OnApplicationQuit() {
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
        SISO.ISO1 = SaveSerializableX.ISO1;
        SISO.ISO2 = SaveSerializableX.ISO2;
        SISO.ISO3 = SaveSerializableX.ISO3;
        SISO.ISO4 = SaveSerializableX.ISO4;
        SISO.ISO5 = SaveSerializableX.ISO5;
        SISO.vLoadISO();
    }
}
