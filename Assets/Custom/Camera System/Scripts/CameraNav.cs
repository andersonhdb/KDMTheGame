using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraNav : MonoBehaviour
{


    private float _distance = 0f;
    private float _angle = 0f;
    [SerializeField]
    private Transform[] _possiblePositions = new Transform[3];

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private bool _isTransitioning = false;
    private float _speed = 0.5f;
    private float _rotSpeed = 1;
    private int _toPosition = 0;



    //Movement cinematics variables
    private float _transitionTime = 2f;
    private float _transtioningTimeCounter = 0f;


    private void Awake()
    {

        if (_possiblePositions[0] == null)
        {
            _possiblePositions[0] = GameObject.Find("StartPoint").GetComponent<Transform>();
        }
        if (_possiblePositions[1] == null)
        {
            _possiblePositions[1] = GameObject.Find("NewGamePoint").GetComponent<Transform>();
        }
        if (_possiblePositions[2] == null)
        {
            _possiblePositions[2] = GameObject.Find("LoadGamePoint").GetComponent<Transform>();
        }
        _originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (_isTransitioning)
        {
            _transtioningTimeCounter += Time.deltaTime;
            transform.position = Vector3.Lerp(_originalPosition, _possiblePositions[_toPosition].position, Easing.Quadratic.InOut(_transtioningTimeCounter / _transitionTime));
            transform.rotation = Quaternion.Lerp(_originalRotation, _possiblePositions[_toPosition].rotation, Easing.Quadratic.InOut(_transtioningTimeCounter / _transitionTime));
            _distance = Vector3.Distance(transform.position, _possiblePositions[_toPosition].position);
            _angle = Quaternion.Angle(transform.rotation, _possiblePositions[_toPosition].rotation);
            if (_distance < 0.05 && _angle < 1)
            {
                _isTransitioning = false;
                _transtioningTimeCounter = 0f;
                _originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _originalRotation = transform.rotation;
            }
            return;
        }

        transform.position = _possiblePositions[_toPosition].position;
        transform.rotation = _possiblePositions[_toPosition].rotation;
    }

    public void TransitionTo(int index)
    {
        _toPosition = index;
        _isTransitioning = true;
    }
}
