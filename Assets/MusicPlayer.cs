using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip; // Przypisz swój plik audio w Unity Editorze
    private AudioSource audioSource;

    void Start()
    {
        // Utwórz komponent AudioSource, jeœli go nie ma
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ustaw klip audio
        audioSource.clip = musicClip;

        audioSource.volume = 0.2f;

        // W³¹cz pêtlê
        audioSource.loop = true;

        // Odtwórz muzykê
        audioSource.Play();
    }

    public void MusicStop()
    {
        audioSource.Stop();
    }
}