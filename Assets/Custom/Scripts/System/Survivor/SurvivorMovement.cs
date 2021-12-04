using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorMovement : MonoBehaviour
{
    [SerializeField]
    private Lantern _survivorLantern;
    private int _maxMovement = 5;
    [SerializeField]
    private float _currentMovement;

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _turningSpeed = 90;

    [SerializeField]
    private Animator _anim;

    private Rigidbody _rb;
    [SerializeField]
    private GameObject _movementTemplate;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetMovement();
        SetTemplateVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            _rb.velocity = Vector3.zero;
        }
        _anim.SetFloat("ySpeed", _rb.velocity.magnitude);
    }

    public void MoveForward()
    {
        if (_currentMovement >= 0)
        {
            float variation = Time.deltaTime * _speed;
            _rb.velocity = transform.forward * _speed;
            _currentMovement -= variation;
            _movementTemplate.transform.localScale = new Vector3(
                2 * _currentMovement,
                _movementTemplate.transform.localScale.y,
                2 * _currentMovement);
            _survivorLantern.SetRange(_currentMovement);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    public void MoveBackward()
    {
        if (_currentMovement >= 0)
        {
            float variation = Time.deltaTime;
            _rb.velocity = -transform.forward;
            _currentMovement -= variation;
            _movementTemplate.transform.localScale = new Vector3(2 * _currentMovement,
                                                                 _movementTemplate.transform.localScale.y,
                                                                 2 * _currentMovement);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    public void TurnRight()
    {
        transform.Rotate(0, _turningSpeed * Time.deltaTime, 0);
    }

    public void TurnLeft()
    {
        transform.Rotate(0, -_turningSpeed * Time.deltaTime, 0);
    }

    public void SetMaxMovement(int maxMovement)
    {
        this._maxMovement = maxMovement;
    }

    public void ResetMovement()
    {
        _currentMovement = _maxMovement;
        _movementTemplate.transform.localScale = new Vector3(_maxMovement * 2,
                                                            _movementTemplate.transform.localScale.y,
                                                            _maxMovement * 2);
    }

    public void SetTemplateVisibility(bool visibility)
    {
        _movementTemplate.SetActive(visibility);
    }

    public int GetMaxMovement()
    {
        return _maxMovement;
    }

    public Lantern GetLantern()
    {
        return _survivorLantern;
    }
}
