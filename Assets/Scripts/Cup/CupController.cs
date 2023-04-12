using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CupController : MonoBehaviour
{
    [SerializeField] private float _order;
    [SerializeField] private bool _isHandCup = false;

    [SerializeField] private ParticleSystem _dieParticle;
    [SerializeField] private GameObject _coffeeLiquide;
    [SerializeField] private GameObject _cupHat;
    [SerializeField] private GameObject _cupSleeve;

    private bool _hasHat = false;
    private bool _hasCoffee = false;
    private bool _hasSleeve = false;
    

    private float _moveDelayDuration = 0.02f;

    private bool _startMoveForward = false;


    private Animator _animator;

    #region MonoBehaviour
    private void Start()
    {

        EventManager.current.OnGameStart += StartMoving;
        EventManager.current.OnGoLeft += InvokeMoveCupLeft;
        EventManager.current.OnGoRight += InvokeMoveCupRight;

        _animator = GetComponent<Animator>();
        if (_isHandCup)
        _animator.SetTrigger(AnimeConst.startCap);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.collectableCup))
        {
            other.gameObject.SetActive(false);
            EventManager.current.OnCupAddedTrigger();

        } else if (other.CompareTag(TagConst.espresso))
        {
            _hasCoffee = true;
            _coffeeLiquide.SetActive(true);
            EventManager.current.OnCupCoffeeAddedTrigger();

        } else if (other.CompareTag(TagConst.fourPiramid))
        {
            int amount = 1;
            if (_hasCoffee) amount++;
            if (_hasHat) amount++;
            if (_hasSleeve) amount++;
            EventManager.current.OnLooseCupTrigger(amount);

            SwitchCup(gameObject, false);
            _dieParticle.Play();
            
        } else if (other.CompareTag(TagConst.movingGreen))
        {
            _hasHat = true;
            _cupHat.SetActive(true);
            EventManager.current.OnCupHatAddedTrigger();

        } else if (other.CompareTag(TagConst.sleeve))
        {
            _cupSleeve.SetActive(true);
            EventManager.current.OnCupSleeveAddedTrigger();

        } else if (other.CompareTag(TagConst.finishLine))
        {
            if (!GameManager.passedFinishLine)
            {
                EventManager.current.OnPassedFinishLineTrigger();
            }

        } else if (other.CompareTag(TagConst.disableCups))
        {
            gameObject.SetActive(false);
        }
    }
    #endregion

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

    private void SwitchCup(GameObject cup, bool isActive)
    {
        cup.GetComponent<CapsuleCollider>().enabled = isActive;
        
        _coffeeLiquide.SetActive(false);
        _cupHat.SetActive(false);
        _hasCoffee = false;
        _hasHat = false;

        GameObject animeLevelObject = cup.transform.GetChild(0).gameObject;
        GameObject cubObject = animeLevelObject.transform.GetChild(0).gameObject;

        cubObject.GetComponent<MeshRenderer>().enabled = isActive;
    }
}
