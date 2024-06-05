using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip; // Przypisz sw�j plik audio w Unity Editorze
    private AudioSource audioSource;

    void Start()
    {
        // Utw�rz komponent AudioSource, je�li go nie ma
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ustaw klip audio
        audioSource.clip = musicClip;

        audioSource.volume = 0.2f;

        // W��cz p�tl�
        audioSource.loop = true;

        // Odtw�rz muzyk�
        audioSource.Play();
    }

    public void MusicStop()
    {
        audioSource.Stop();
    }
}