using UnityEngine;

public class SongSelect : MonoBehaviour
{
    public GameInfo gameInfo;

    public AudioClip music;
    public Texture2D[] beatMaps;
    public float bpm;
    public float latencyModifier;

    public void setGameInfo()
    {
        gameInfo.SetMusic(this.music);
        gameInfo.SetBeatMaps(this.beatMaps);
        gameInfo.SetBPM(this.bpm);
        gameInfo.SetLatencyModifier(this.latencyModifier);
    }
}
