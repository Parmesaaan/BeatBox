using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    private bool started;
    private Vector3 move;
    private float difficultyScale;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (started)
        {
            transform.position -= move;
        } else
        {
            
        }
    }

    public void Begin(Vector3 move)
    {
        gameObject.SetActive(true);
        started = true;
        this.move = move * difficultyScale;
    }

    public void AdjustDifficulty(float difficultyScale)
    {
        this.difficultyScale = difficultyScale;
        foreach (Transform transform in GetComponentsInChildren(typeof(Transform)))
        {
            float offset = Mathf.Sqrt(difficultyScale);
            transform.position = new Vector3(transform.position.x, transform.position.y * (difficultyScale * difficultyScale), transform.position.z);
        }
    }

    public void Reset()
    {
        started = false;
        gameObject.SetActive(true);
        gameObject.transform.position.Set(initialPosition.x, initialPosition.y, initialPosition.z);
        gameObject.SetActive(false);
    }
}
