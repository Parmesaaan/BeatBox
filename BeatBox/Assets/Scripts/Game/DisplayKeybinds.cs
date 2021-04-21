using TMPro;
using UnityEngine;

public class DisplayKeybinds : MonoBehaviour
{
    public TextMeshProUGUI red;
    public TextMeshProUGUI orange;
    public TextMeshProUGUI yellow;
    public TextMeshProUGUI green;
    public TextMeshProUGUI blue;
    public TextMeshProUGUI purple;

    private GameInfo gameInfo;

    private void Awake()
    {
        this.gameInfo = FindObjectOfType<GameInfo>();
        if(gameInfo)
        {
            red.SetText(gameInfo.buttonKeys.GetValue(0).ToString());
            orange.SetText(gameInfo.buttonKeys.GetValue(1).ToString());
            yellow.SetText(gameInfo.buttonKeys.GetValue(2).ToString());
            green.SetText(gameInfo.buttonKeys.GetValue(3).ToString());
            blue.SetText(gameInfo.buttonKeys.GetValue(4).ToString());
            purple.SetText(gameInfo.buttonKeys.GetValue(5).ToString());
        }
        else
        {
            red.SetText("Q");
            orange.SetText("W");
            yellow.SetText("E");
            green.SetText("I");
            blue.SetText("O");
            purple.SetText("P");
        }

    }
}
