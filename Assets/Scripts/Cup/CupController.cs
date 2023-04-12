using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CupController : MonoBehaviour
{
    [SerializeField] private float _order;
    [SerializeField] private bool _isHandCup = false;
    private float _moveDelayDuration = 0.02f;

    private bool _startMoveForward = false;

    private void Start()
    {
        EventManager.current.OnGameStart += StartMoving;
        EventManager.current.OnGoLeft += InvokeMoveCupLeft;
        EventManager.current.OnGoRight += InvokeMoveCupRight;
    }

    private void OnDisable()
    {
        EventManager.current.OnGameStart -= StartMoving;
        EventManager.current.OnGoLeft -= InvokeMoveCupLeft;
        EventManager.current.OnGoRight -= InvokeMoveCupRight;
    }

    private void Update()
    {
        if (_startMoveForward && !_isHandCup)
        {
            transform.Translate(HandControl.frontSpeedModifier * Time.deltaTime * Vector3.forward, Space.World);
        }
    }

    private void StartMoving()
    {
        _startMoveForward = true;
    }

    private void InvokeMoveCupLeft()
    {
        Invoke(nameof(MoveCupLeft), _order * _moveDelayDuration);
    }

    private void InvokeMoveCupRight()
    {
        Invoke(nameof(MoveCupRight), _order * _moveDelayDuration);
    }

    private void MoveCupLeft()
    {
        //Mouse Control
        if (transform.position.x > -0.85f && !_isHandCup)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(
                    transform.position.x - HandControl.horizontalSpeedModifier,
                    transform.position.y,
                    transform.position.z),
                HandControl.t);
            //transform.Translate(HandControl.horizontalSpeedModifier * Time.deltaTime * Vector3.left, Space.World);
        }
    }

    private void MoveCupRight()
    {
        if (transform.position.x < 0.78f && !_isHandCup)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(
                    transform.position.x + HandControl.horizontalSpeedModifier,
                    transform.position.y,
                    transform.position.z),
                HandControl.t);
            //transform.Translate(HandControl.horizontalSpeedModifier * Time.deltaTime * Vector3.right, Space.World);
        }  
    }
}
