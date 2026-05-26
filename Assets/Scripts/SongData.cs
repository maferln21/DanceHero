using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "Scriptable Objects/SongData")]
public class SongData : ScriptableObject
{
    public string animationName;
    public string songName;
    public TextAsset noteChart;
    public float speed;
}
