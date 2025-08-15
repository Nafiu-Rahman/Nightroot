using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
    public AudioClip eerieForestClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = eerieForestClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
