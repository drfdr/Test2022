[System.Serializable]
public class SaveSerializable{

    public string PlayerName;
    public int NumberOfClicks;

    public string ISO1;
    public string ISO2;
    public string ISO3;
    public string ISO4;
    public string ISO5;

    public SaveSerializable(PlayerData PD, SaveISO SISO) {
        PlayerName = PD.PlayerName;
        NumberOfClicks = PD.NumberOfClicks;
        ISO1 = SISO.ISO1;
        ISO2 = SISO.ISO2;
        ISO3 = SISO.ISO3;
        ISO4 = SISO.ISO4;
        ISO5 = SISO.ISO5;

    }
}
