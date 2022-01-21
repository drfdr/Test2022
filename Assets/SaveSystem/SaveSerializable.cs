[System.Serializable]
public class SaveSerializable{

    public string PlayerName;
    public int NumberOfClicks;

    public string[] ISOArray;

    public SaveSerializable(PlayerData PD, SaveISO SISO) {
        PlayerName = PD.PlayerName;
        NumberOfClicks = PD.NumberOfClicks;
        ISOArray = new string[10];
        for (int i = 0; i < 10; i++) {
           ISOArray[i] = SISO.ISOArray[i];
        }
    }
}
