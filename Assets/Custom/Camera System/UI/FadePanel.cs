using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    private Rigidbody _rb;
    private Image _fadePanel;

    private float _alphaFade;
    private float _alphaStart;
    private float _timer;

    private bool _fade = true;
    private bool _direction = true;

    [SerializeField]
    private float _alphaValue = 1;


    [SerializeField]
    private float _fadeTime = 1f;


    private void Awake()
    {
        _fadePanel = GetComponent<Image>();
        _alphaFade = _alphaValue;
        SetAlpha();
        _alphaFade = _fadePanel.color.a;
        _alphaStart = _alphaFade;
        _timer = 0f;
        if (_alphaFade == 0)
        {
            _fade = false;
            _direction = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_fade)
        {
            _timer += Time.deltaTime;
            if (_direction) // fade In
            {
                _alphaFade = Mathf.Lerp(_alphaStart, 0, _timer / _fadeTime);
                SetAlpha();
                if (_timer / _fadeTime >= 1f)
                {
                    _direction = !_direction;
                    _fade = false;
                    _timer = 0f;
                }
            }
            else //fade out
            {
                _alphaFade = Mathf.Lerp(_alphaStart, 1, _timer / _fadeTime);
                SetAlpha();
                if (_timer / _fadeTime > 1)
                {
                    _direction = !_direction;
                    _fade = false;
                    _timer = 0f;
                }
            }
        }
    }

    public void Fade()
    {
        _fade = true;
        _alphaStart = _alphaFade;
    }

    public void SetAlpha()
    {
        var color = _fadePanel.color;
        color.a = _alphaFade;
        _fadePanel.color = color;
    }
}
