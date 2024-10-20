using UnityEngine;

public class FinalLevelMusic : MonoBehaviour
{
    [SerializeField] AudioSource musicBg;
    [SerializeField] AudioSource musicSfx;
    [SerializeField] AudioSource blackHoldeSfx;

    public AudioClip background;
    public AudioClip boost;
    public AudioClip shooting;
    public AudioClip openChest;
    public AudioClip death;
    public AudioClip blackHole;
    public AudioClip enemyDie;
    public AudioClip winNoti;
    public AudioClip backgroundWin;

    private void Start()
    {
        musicBg.clip = background;
        musicBg.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        musicSfx.PlayOneShot(clip);
    }
    public void StopBackground()
    {
        musicBg.Stop();
    }
    public void PlayWinBackground()
    {
        StopBlackHole();
        StopBackground();
        PlaySFX(winNoti);
        musicBg.clip = backgroundWin;
        musicBg.Play();
    }
    public void PlayBlackHole()
    {
        blackHoldeSfx.PlayOneShot(blackHole);
    }
    public void StopBlackHole() 
    {
        blackHoldeSfx.Stop();
    }
}
