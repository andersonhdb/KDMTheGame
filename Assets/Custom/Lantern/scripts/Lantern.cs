using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private Light _lanternLight;
    [SerializeField]
    private float _averageIntensity = 2.69f;
    [SerializeField]
    private float _noiseRange = .5f;
    [SerializeField]
    private float _flickerSpeed = 1f;

    [SerializeField]
    private Color _normalColor;
    [SerializeField]
    private Color _hoveringColor;
    [SerializeField]
    private Color _unavailableColor;

    private float _startIntensity;
    private float _currentIntensity;
    private float _targetIntensity;

    private float _timer = 0f;
    [SerializeField]
    private bool _turnedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        //_turnedOn = true;
        _lanternLight.color = _normalColor;
        _currentIntensity = _lanternLight.intensity;
        SetNextIntensity(Random.Range(-_noiseRange, _noiseRange) + _averageIntensity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_turnedOn)
        {
            if (_timer * _flickerSpeed <= 1f)
            {
                _timer += Time.deltaTime;
                _currentIntensity = Mathf.Lerp(_startIntensity, _targetIntensity, _timer * _flickerSpeed);
                _lanternLight.intensity = _currentIntensity;
            }
            while (_currentIntensity == _targetIntensity)
            {
                SetNextIntensity(Random.Range(-_noiseRange, _noiseRange) + _averageIntensity);
            }
        }
        else if (!_turnedOn && _currentIntensity != 0)
        {
            _timer += Time.deltaTime;
            _currentIntensity = Mathf.Lerp(_startIntensity, 0f, _timer * _flickerSpeed);
            _lanternLight.intensity = _currentIntensity;
        }
    }

    public void TurnOn()
    {
        _turnedOn = true;
        SetNextIntensity(Random.Range(-_noiseRange, _noiseRange) + _averageIntensity);
    }

    public void TurnOff()
    {
        _turnedOn = false;
        SetNextIntensity(0f);
    }

    public void SetIntensity(float nextIntensity)
    {
        _averageIntensity = nextIntensity;
    }

    public void SetRange(float nextRange)
    {
        _lanternLight.range = nextRange;
    }

    private void SetNextIntensity(float nextIntensity)
    {
        _targetIntensity = nextIntensity;
        _startIntensity = _currentIntensity;
        _timer = 0f;
    }

    public void HoveringLight()
    {
        _lanternLight.color = _hoveringColor;
    }

    public void UnavailableLight()
    {
        _lanternLight.color = _unavailableColor;
    }

    public void NormalLight()
    {
        _lanternLight.color = _normalColor;
    }
}
