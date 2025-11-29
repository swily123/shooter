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
    
    private Vector3 _shakeAngles = new Vector3();
    private Vector3 _recoilAngles = new Vector3();
    private Vector3 _recoilVelocity = new Vector3();
    
    private float _amplitude = 0f;
    private float _shakeTimer = 0f;
    private float _duration = 1f;
    
    private void Update()
    {
        UpdateRecoil();
        UpdateShake();
        
        _cameraTransform.localEulerAngles = _shakeAngles + _recoilAngles;
    }

    [ContextMenu("Make Shake")]
    public void MakeShake()
    {
        MakeShake(15, 3);
    }
    
    public void MakeShake(float amplitude, float duration)
    {
        _amplitude = amplitude;
        _duration = Mathf.Max(duration, 0.05f);
        _shakeTimer = 1;
    }
    
    [ContextMenu("Make Recoil")]
    public void MakeRecoil()
    {
        MakeRecoil(-Vector3.right * UnityEngine.Random.Range(_impulse * 0.5f, _impulse) + Vector3.up * UnityEngine.Random.Range(-_impulse, _impulse)/4f);
    }
    
    public void MakeRecoil(Vector3 impulse)
    {
        _recoilVelocity += impulse;
    }
    
    private void UpdateRecoil()
    {
        _recoilAngles += _recoilVelocity * Time.deltaTime;
        _recoilVelocity += -_recoilAngles * (Time.deltaTime * _tension);
        _recoilVelocity = Vector3.Lerp(_recoilVelocity, Vector3.zero, Time.deltaTime * _damping);
    }

    private void UpdateShake()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime / _duration;
        }
        
        float time = Time.time * _perlinNoiseTimeScale;
        
        _shakeAngles.x = Mathf.PerlinNoise(time, 0);
        _shakeAngles.y = Mathf.PerlinNoise(0, time);
        _shakeAngles.z = Mathf.PerlinNoise(time, time);
        
        _shakeAngles *= _amplitude;
        _shakeAngles *= _perlinNoiseCurve.Evaluate(Mathf.Clamp01(1 - _shakeTimer));
    }
}