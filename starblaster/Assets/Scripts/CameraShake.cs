using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude = 0.5F;
    [SerializeField] private float shakeDuration = 0.5F;
    
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        var timeElapsed = 0F;
        
        do
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            
        } while(timeElapsed < shakeDuration);
        
        transform.position = _initialPosition;
    }
}
