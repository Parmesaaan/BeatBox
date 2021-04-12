using UnityEngine;

public class SongSelect : MonoBehaviour
{
    public GameInfo gameInfo;

    public AudioClip music;
    public Texture2D[] beatMaps;
    public float bpm;
    public float latencyModifier;
    public Sprite backgroundImage;

    public void setGameInfo()
    {
        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        gameInfo.SetMusic(this.music);
        gameInfo.SetBeatMaps(this.beatMaps);
        gameInfo.SetBPM(this.bpm);
        gameInfo.SetLatencyModifier(this.latencyModifier);
        gameInfo.SetBackgroundImage(this.backgroundImage);
    }
}
