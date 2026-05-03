using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("AI Variables")]
    [SerializeField] private float minFireRate = 0.2F;
    [SerializeField] private float fireRateVariance = 0F;
    [SerializeField] private bool useAI;
    
    [Header("Base Variables")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float baseFireRate = 0.33F;
    [SerializeField] private float projectileLifeTime;
    
    private Coroutine _fireRoutine;
    private bool _isFiring = false;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();
        if (useAI)
        {
            IsFiring = true;
        }
    }
    
    // public bool IsFiring { get; set; }
    public bool IsFiring
    {
        get => _isFiring;
        set => _isFiring = value;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (_isFiring && _fireRoutine == null)
        {
            _fireRoutine = StartCoroutine(FireContinuously());
        }
        else if (!_isFiring && _fireRoutine != null)
        {
            StopCoroutine(_fireRoutine);
            _fireRoutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            var projectile = Instantiate(
                original: projectilePrefab, 
                position: transform.position, 
                rotation: Quaternion.identity
            );
            projectile.transform.rotation = transform.rotation;
            var projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.linearVelocity = transform.up * projectileSpeed;
            Destroy(projectile, projectileLifeTime);
            var waitTime = GetFireRateTime();
            _audioManager.PlayShootingSfx();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private float GetFireRateTime()
    {
        var newFireRate = Random.Range(
            minInclusive: baseFireRate - fireRateVariance,
            maxInclusive: baseFireRate + fireRateVariance
        );
        newFireRate = Mathf.Clamp(newFireRate, minFireRate, float.MaxValue);
        return newFireRate;
    }
}
