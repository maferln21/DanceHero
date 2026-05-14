using UnityEngine;
using UnityEngine.Events;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private Animator  characterAnimator;
    [SerializeField]
    private UnityEvent onSongStart;
    [SerializeField]
    private UnityEvent onSongEnd;
    public void PlaySong(SongData songData)
    {
        characterAnimator.Play(songData.animationName);
        SoundManager.instance.PlayMusic(songData.songName);
        onSongStart?.Invoke();
    }
    public void StopSong()
    {
            SoundManager.instance.StopMusic();
            onSongEnd?.Invoke();
    }
}
