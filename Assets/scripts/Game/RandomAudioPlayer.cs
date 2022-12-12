using System.Linq;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] AudioClips = new AudioClip[] { };
    private AudioSource _audioSource;
    public float MinAudioPitch = .8f;
    public float MaxAudioPitch = 1.2f;

    private void Start()
    {
        if (!TryGetComponent(out _audioSource))
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayRandomSound()
    {
        if (AudioClips.Any())
        {
            _audioSource.pitch = Random.Range(MinAudioPitch, MaxAudioPitch);
            _audioSource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Length)]);
        }
    }
}
