using UnityEngine;
using TMPro;

public class ButtonKeybind : MonoBehaviour
{
    private GameInfo gameInfo;
    public TextMeshProUGUI text;
    public int buttonIndex;
    public bool isChanging;

    void Start()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        isChanging = false;
        text.SetText(gameInfo.GetButtonKeys()[buttonIndex].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(isChanging)
        {
            foreach(KeyCode tempKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(tempKey))
                {
                    if(tempKey == KeyCode.Escape)
                    {
                        isChanging = false;
                    } else
                    {
                        gameInfo.SetButtonKey(buttonIndex, tempKey);
                        text.SetText(tempKey.ToString());
                        gameInfo.SetHasCustomControls(true);
                        isChanging = false;
                    }
                }
            }
        }
    }

    public void SetIsChanging(bool isChanging)
    {
        this.isChanging = isChanging;
    }
}
