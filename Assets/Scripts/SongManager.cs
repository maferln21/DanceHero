using UnityEngine;
using UnityEngine.Events;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private Animator  characterAnimator;
    [SerializeField]
    private UnityEvent onSongStart;
    [SerializeField]
    private UnityEvent onSongSelected;
    [SerializeField]
    private UnityEvent onSongEnd;
    [SerializeField]
    private NotesManager notesManager;
    private SongData currentSongData;
    public void SelectSong(SongData songData)
    {
        currentSongData = songData;
        onSongSelected?.Invoke();
    }
    public void StopSong()
    {
            SoundManager.instance.StopMusic();
            onSongEnd?.Invoke();
    }
    public void StartSong()
    {
        characterAnimator.Play(currentSongData.animationName);
        SoundManager.instance.PlayMusic(currentSongData.songName);
        notesManager.StartNoteChart(currentSongData.noteChart, currentSongData.speed);
        onSongStart?.Invoke();    
    }
}    
