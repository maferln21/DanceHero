using UnityEngine;
using UnityEngine.Events;
using   System.Collections;

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
    [SerializeField]
    private string failAnimationName = "Hit;";
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
    public void Fail()
    {
        StopAllCoroutines();
        StartCoroutine(FailCoroutine());
    }
    private IEnumerator FailCoroutine()
    {
        characterAnimator.Play(failAnimationName, 0, 0f);
        yield return null;
        yield return new WaitForSeconds(characterAnimator.GetCurrentAnimatorStateInfo(0).length);
        characterAnimator.Play(currentSongData.animationName, 0, 0f);
    }
    public void WinSong()
    {
        StopAllCoroutines();
        characterAnimator.Play("Win", 0, 0f);
    }
    public void LoseSong()
    {
        StopAllCoroutines();
        characterAnimator.Play("Lose", 0, 0f);
    }
}    
