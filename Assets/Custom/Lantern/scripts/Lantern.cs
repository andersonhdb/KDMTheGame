using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private Light _lanternLight;
    [SerializeField]
    private float _lightIntensity;
    [SerializeField]
    private float _noiseRange;
    [SerializeField]
    private float _trasientDuration = 1;
    
    private bool _isTransitioning = false;
    private bool _isOff = false;
    private float _targetIntensity;
    private float _previousIntensity;
    private float _currentIntensity;

    [SerializeField]
    private Color _unselected;
    [SerializeField]
    private Color _unavailable;
    [SerializeField]
    private Color _hovering;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTransitioning)
        {
            _currentIntensity += Time.deltaTime;
            _lanternLight.intensity = Mathf.Lerp(_previousIntensity, _targetIntensity, _currentIntensity / _trasientDuration);
            if(_currentIntensity >= _trasientDuration)
            {
                _currentIntensity = 0f;
                _isTransitioning = false;
            }
            return;
        }
        if (!_isOff)
        {
            _previousIntensity = _targetIntensity;
            _targetIntensity = _lightIntensity + Random.Range(-_noiseRange/2, _noiseRange/2);
            _isTransitioning = true;
        }
    }

    public void TurnOff()
    {
        _previousIntensity = _targetIntensity;
        _targetIntensity = 0f;
        _isTransitioning = true;
        _isOff = true;
    }

    public void TurnOn()
    {
        _previousIntensity = _targetIntensity;
        _targetIntensity = _lightIntensity + Random.Range(-_noiseRange / 2, _noiseRange / 2);
        _isOff = false;
        _isTransitioning = true;
    }

    public void SetLightRange(float newRange)
    {
        _lanternLight.range = newRange;
    }
}
