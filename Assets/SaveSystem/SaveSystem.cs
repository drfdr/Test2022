using UnityEngine;

public class SaveSystem : MonoBehaviour{
    [SerializeField] private PlayerData PD;
    [SerializeField] private SaveISO HandSISO;
    [SerializeField] private SaveISO SideHandSISO;
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
        HandSISO.vSaveISO();
        SideHandSISO.vSaveISO();
        SaveBinary.SaveData(PD, HandSISO,SideHandSISO);
    }

    private void LoadGame() {
        SaveSerializable SaveSerializableX = SaveBinary.LoadData();
        PD.PlayerName = SaveSerializableX.PlayerName;
        PD.NumberOfClicks = SaveSerializableX.NumberOfClicks;
        //HandSISO
        HandSISO.ISOArray = new string[SaveSerializableX.HandArrayLength];
        for (int i = 0; i < SaveSerializableX.HandArrayLength; i++) {
            HandSISO.ISOArray[i] = SaveSerializableX.HandISOArray[i];
                }
        HandSISO.vLoadISO();

        //SideHandSISO
        SideHandSISO.ISOArray = new string[SaveSerializableX.SideHandArrayLength];
        for (int i = 0; i < SaveSerializableX.SideHandArrayLength; i++) {
            SideHandSISO.ISOArray[i] = SaveSerializableX.SideHandISOArray[i];
        }
        SideHandSISO.vLoadISO();
    }
}
