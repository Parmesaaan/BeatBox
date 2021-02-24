using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite defaultImage;
    public Sprite pressedImage;

    private SpriteRenderer sr;
    private KeyCode key;

    void Start()
    {
        sr = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }


    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            sr.sprite = pressedImage;
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
}
