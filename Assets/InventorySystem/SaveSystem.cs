using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour{
    [SerializeField] private PlayerData PD;
    [SerializeField] private SeedBox SB;
    [SerializeField] private SavableGOS SGOS;
    [SerializeField] private bool NOGOWASSAVED;
     
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
        SGOS.SaveGO1 = SGOS.transform.GetChild(0).GetComponent<Item>().RealName;    
        SaveLoad.SaveData(PD, SB, SGOS);
    }

    private void LoadGame() {
        SaveSerializable SaveSerializableX = SaveLoad.LoadData();
        PD.PlayerName = SaveSerializableX.PlayerName;
        SB.SeedboxETA = SaveSerializableX.SeedBoxETA;

        //ReloadingSavedGOS//
        foreach (Transform child in SGOS.transform) {
            Destroy(child.gameObject);
        }
        if (string.IsNullOrEmpty(SaveSerializableX.SaveGO1)) {
            Debug.Log("No GameObject Was Saved");
        } else {
            string stringLoadGO1 = SaveSerializableX.SaveGO1;
            GameObject LoadGO1 = Instantiate(Resources.Load(stringLoadGO1, typeof(GameObject))) as GameObject;
            LoadGO1.transform.SetParent(SGOS.transform);
            Debug.Log("GameObject: " + stringLoadGO1 + " :Was Saved and now It has been Loaded");
        }
    }
}
