using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite defaultImage;
    public Sprite pressedImage;

    private SpriteRenderer sr;
    private KeyCode key;
    private bool pressed;

    void Start()
    {
        pressed = false;
        sr = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }


    void Update()
    {
        if (pressed == true)
        {
            pressed = false;
        }

        if (Input.GetKeyDown(key))
        {
            sr.sprite = pressedImage;
            pressed = true;
        }

        if (Input.GetKeyUp(key))
        {
            sr.sprite = defaultImage;
        }
    }

    public void SetKey(KeyCode key)
    {
        this.key = key;
    }

    public bool isPressed()
    {
        return pressed;
    }
}
