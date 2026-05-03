using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")] 
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0.0F, 1.0F)] private float shootingVolume;
    
    [Header("Damage SFX")] 
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0.0F, 1.0F)] private float damageVolume;
    
    private static AudioManager _instance;

    public static AudioManager Instance => _instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingSfx()
    {
        PlaySfx(shootingClip,  shootingVolume);
    }

    public void PlayDamageSfx()
    {
        PlaySfx(damageClip,  damageVolume);
    }

    private void PlaySfx(AudioClip clip, float volume)
    {
        if (clip == null) return;
        AudioSource.PlayClipAtPoint(
            clip: clip,
            position: Camera.main.transform.position,
            volume: volume
        );
    }
}
