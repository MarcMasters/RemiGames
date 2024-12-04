using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    // Crear AudioSource sin "PlayOnAwake" y meterlo en prefabs
    [SerializeField] private AudioSource soundFXObject;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume)
    {
        // random index
        int randIndex = Random.Range(0,audioClips.Length);

        // spawn in gameObject
        // Se crea el objeto AudioSource y luego se le asigna un clip a reproducir
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign audioClip
        audioSource.clip = audioClips[randIndex];

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // get length of sound FX clip
        float clipLength = audioSource.clip.length;

        // destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
