using UnityEngine;

public class LaneHandler : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject[] lanes;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveBeats(Vector3 move)
    {
        foreach (GameObject lane in lanes)
        {
            lane.GetComponent<BeatScroller>().Begin(move);
        }
    }

    public void AdjustDifficulty(float difficultyScale)
    {
        foreach (GameObject lane in lanes)
        {
            lane.GetComponent<BeatScroller>().AdjustDifficulty(difficultyScale);
        }
    }
}
