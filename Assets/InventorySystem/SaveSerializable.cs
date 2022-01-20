[System.Serializable]
public class SaveSerializable{

    public string PlayerName;
    public int SeedBoxETA;

    public string SaveGO1;

    public SaveSerializable(PlayerData PD, SeedBox SB, SavableGOS SGOS) {
        PlayerName = PD.PlayerName;
        SeedBoxETA = SB.SeedboxETA;
        SaveGO1 = SGOS.SaveGO1;
    }
}
