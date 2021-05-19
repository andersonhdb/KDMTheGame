using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class IntroStartState : IntroState
{
    [SerializeField]
    private CameraNav _cam;
    [SerializeField]
    private LanternArray[] _lights;

    [SerializeField]
    private TextMeshProUGUI[] _introText;

    [SerializeField]
    private FadePanel _textOverlay;


    [SerializeField]
    private TimeLineEvents[] _events;
    private float _timeLine;
    private int _triggerIndex = 0;

    private void OnEnable()
    {
        Input_Manager.Clear();
        _cam.TransitionTo(0);
        foreach (var lights in _lights)
        {
            foreach (var light in lights.lanterns)
            {
                light.TurnOff();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(_triggerIndex < _events.Length))
        {
            return;
        }
        _timeLine += Time.deltaTime;
        if (_timeLine >= _events[_triggerIndex].EventTime)
        {
            _events[_triggerIndex].Event.Invoke();
            _triggerIndex++;
        }
    }

    private void OnDisable()
    {

    }



    //All events that will trigger during this state:
    public void LightLanternsAtScene(int i)
    {
        foreach (var lantern in _lights[i].lanterns)
        {
            lantern.TurnOn();
        }
    }

    public void TurnOffLanternsAtScene(int i)
    {
        foreach (var lantern in _lights[i].lanterns)
        {
            lantern.TurnOff();
        }
    }

    public void GetToScene(int i)
    {
        _cam.TransitionTo(i);
    }

    public void DisplayTextAtIndex(int i)
    {
        //_overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 0.3f);
        _introText[i].gameObject.SetActive(true);
        _textOverlay.Fade();
        Debug.Log("Called Fade In", this);
    }

    public void HideTextAtIndex(int i)
    {
        _introText[i].gameObject.SetActive(false);
        //_overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 0f);
    }

    public void TextFadeOut()
    {
        _textOverlay.Fade();
    }

    [System.Serializable]
    public class LanternArray
    {
        public Lantern[] lanterns;
    }

    [System.Serializable]
    public class TimeLineEvents
    {
        public float EventTime;
        public UnityEvent Event;
    }

}
