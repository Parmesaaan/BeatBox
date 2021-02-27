using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D[] beatMaps;

    [Header("Prefabs")]
    public GameObject redPrefab;
    public GameObject orangePrefab;
    public GameObject yellowPrefab;
    public GameObject greenPrefab;
    public GameObject bluePrefab;
    public GameObject purplePrefab;

    [Header("Lanes")]
    public Transform redLane;
    public Transform orangeLane;
    public Transform yellowLane;
    public Transform greenLane;
    public Transform blueLane;
    public Transform purpleLane;

    private void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        int beatMapIndex = 0;
        foreach(Texture2D beatMap in beatMaps)
        {
            for (int x = 0; x < beatMap.width; x++)
            {
                for (int y = 0; y < beatMap.height; y++)
                {
                    GenerateBeat(x, y, beatMap, beatMapIndex);
                }
            }
            beatMapIndex++;
        }
    }

    void GenerateBeat(int x, int y, Texture2D beatMap, int beatMapIndex)
    {
        Color pixelColor = beatMap.GetPixel(x, y);

        if (pixelColor.a == 0) // Ignore pixel if it's transparent
        {
            return;
        }

        switch (y)
        {
            case 5:
                Instantiate(redPrefab, new Vector2(redLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, redLane);
                break;
            case 4:
                Instantiate(orangePrefab, new Vector2(orangeLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, orangeLane);
                break;
            case 3:
                Instantiate(yellowPrefab, new Vector2(yellowLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, yellowLane);
                break;
            case 2:
                Instantiate(greenPrefab, new Vector2(greenLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, greenLane);
                break;
            case 1:
                Instantiate(bluePrefab, new Vector2(blueLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, blueLane);
                break;
            case 0:
                Instantiate(purplePrefab, new Vector2(purpleLane.transform.position.x, ((float) x / 4f) + ((float) 512 * beatMapIndex) + 9f), Quaternion.identity, purpleLane);
                break;
        }
    }
}
