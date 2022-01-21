[System.Serializable]
public class SaveSerializable{

    public string PlayerName;
    public int NumberOfClicks;

    public string[] HandISOArray;
    public string[] SideHandISOArray;
    public int HandArrayLength;
    public int SideHandArrayLength;

    public SaveSerializable(PlayerData PD, SaveISO HandSISO,SaveISO SideHandSISO) {
        PlayerName = PD.PlayerName;
        NumberOfClicks = PD.NumberOfClicks;
        //Hand
        HandArrayLength = HandSISO.ArrayLength;
        HandISOArray = new string[HandArrayLength];
        for (int i = 0; i < HandArrayLength; i++) {
           HandISOArray[i] = HandSISO.ISOArray[i];
        }
        //SideHand
        SideHandArrayLength = SideHandSISO.ArrayLength;
        SideHandISOArray = new string[SideHandArrayLength];
        for (int i = 0; i < SideHandArrayLength; i++) {
            SideHandISOArray[i] = SideHandSISO.ISOArray[i];
        }
    }
}
