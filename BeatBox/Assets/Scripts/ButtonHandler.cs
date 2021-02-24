using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject[] buttons;

    private KeyCode[] keyCodes;

    void Start()
    {
        keyCodes = gameHandler.GetKeyCodes();
        int counter = 0;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().SetKey(keyCodes[counter]);
            counter++;
        }
    }


    void Update()
    {

    }
}
