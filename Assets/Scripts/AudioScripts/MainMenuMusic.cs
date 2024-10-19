using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] AudioSource musicBg;

    public AudioClip background;

    private void Start()
    {
        musicBg.clip = background;
        musicBg.Play();
    }
}
