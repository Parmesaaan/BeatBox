using UnityEngine;

public class Beat : MonoBehaviour
{
    public BeatType beatType = BeatType.Normal;
    public bool pressable;

    void Start()
    {
        pressable = false;
    }

    void Update()
    {
        if(gameObject.transform.position.y <= 1.5f)
        {
            pressable = true;
        }

        if(gameObject.transform.position.y <= -0.5f)
        {
            pressable = false;
        }

        if (gameObject.transform.position.y <= -2f)
        {
            gameObject.SetActive(false);
        }
    }

    public enum BeatType
    {
        Normal,
        Sustained
    }
}
