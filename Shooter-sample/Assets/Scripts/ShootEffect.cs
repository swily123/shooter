using System.Collections;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _lightSource;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private AudioSource _reloadSound;

    private void Start()
    {
        _particleSystem.Clear();
        _particleSystem.Stop();
        
        _shotSound.Stop();
        
        _lightSource.SetActive(false);
    }

    public void Perform()
    {
        StopAllCoroutines();
        StartCoroutine(EffectRoutine());
    }

    public void Reload()
    {
        _reloadSound.Play();
    }

    private IEnumerator EffectRoutine()
    {
        _shotSound.Play();
        _lightSource.SetActive(true);
        _particleSystem.Clear();
        _particleSystem.Play();
        
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        
        _lightSource.SetActive(false);
    }
}
