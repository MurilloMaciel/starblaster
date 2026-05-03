using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private int scoreValue = 50;
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private bool applyCameraShake = false;
    
    private CameraShake _cameraShake;
    private AudioManager _audioManager;
    private ScoreKeeper _scoreKeeper;
    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindFirstObjectByType<LevelManager>();
        _audioManager = AudioManager.Instance;
        _scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer == null) return;
        TakeDamage(damageDealer.GetDamage());
        PlayHitParticles();
        damageDealer.OnHit();
        _audioManager.PlayDamageSfx();
        if (applyCameraShake)
        {
            _cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isPlayer)
        {
            _levelManager.LoadGameOver();
        }
        else
        {
            _scoreKeeper.AddScore(scoreValue);
        }
        Destroy(gameObject);
    }

    private void PlayHitParticles()
    {
        if (hitParticles == null) return;
        var particles = Instantiate(hitParticles, transform.position, transform.rotation);
        Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
    }

    public int GetHealth()
    {
        return health;
    }
}
