using UnityEngine;

public class NormalLevelMusic : MonoBehaviour
{
    [SerializeField] AudioSource musicBg;
    [SerializeField] AudioSource musicSfx;

    public AudioClip background; 
    public AudioClip eatPellet;
    public AudioClip powerPelletDuration;
    public AudioClip eatGhost; 
    public AudioClip death; 
    public AudioClip eatFruit;
    public AudioClip activeFlame;
    public AudioClip flame;

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
}
