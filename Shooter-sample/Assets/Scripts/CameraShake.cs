using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Noise")]
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _perlinNoiseTimeScale = 1f;
    [SerializeField] private AnimationCurve _perlinNoiseCurve;

    [Header("Recoil")]
    [SerializeField] private float _tension = 10;
    [SerializeField] private float _damping = 10;
    [SerializeField] private float _impulse = 10;
    
    private Vector3 _shakeAngles;
    private Vector3 _recoilAngles;
    private Vector3 _recoilVelocity;
    
    private float _amplitude;
    private float _shakeTimer;
    private float _duration = 1f;
    
    private void Update()
    {
        UpdateRecoil();
        UpdateShake();
        
        _cameraTransform.localEulerAngles = _shakeAngles + _recoilAngles;
    }
    
    private void UpdateRecoil()
    {
        _recoilAngles += _recoilVelocity * Time.deltaTime;
        _recoilVelocity += -_recoilAngles * (Time.deltaTime * _tension);
        _recoilVelocity = Vector3.Lerp(_recoilVelocity, Vector3.zero, Time.deltaTime * _damping);
    }

    private void UpdateShake()
    {
        if (_shakeTimer <= 0f)
        {
            _shakeTimer = 0f;
            _shakeAngles = Vector3.zero;
            _amplitude = 0f;
            return;
        }

        _shakeTimer -= Time.deltaTime / _duration;
        _shakeTimer = Mathf.Max(_shakeTimer, 0f);

        float progress = 1f - _shakeTimer;
        float time = Time.time * _perlinNoiseTimeScale;

        float nx = Mathf.PerlinNoise(time, 0f) - 0.5f;
        float ny = Mathf.PerlinNoise(0f, time) - 0.5f;
        float nz = Mathf.PerlinNoise(time, time) - 0.5f;

        float strength = _amplitude * _perlinNoiseCurve.Evaluate(progress);

        _shakeAngles = new Vector3(nx, ny, nz) * strength;
    }

    private void MakeShake(float amplitude, float duration)
    {
        _amplitude = amplitude;
        _duration = Mathf.Max(duration, 0.05f);
        _shakeTimer = 1;
    }
    
    private void MakeRecoil(Vector3 impulse)
    {
        _recoilVelocity += impulse;
    }
    
    [ContextMenu("Make Recoil")]
    public void MakeRecoil()
    {
        MakeRecoil(-Vector3.right * Random.Range(_impulse * 0.5f, _impulse) + Vector3.up * Random.Range(-_impulse, _impulse)/4f);
    }
    
    [ContextMenu("Make Shake")]
    public void MakeShake()
    {
        MakeShake(15, 3);
    }
}