using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cupsInRaw;
    [SerializeField] private TextMeshProUGUI _scoreOnHand;

    private int _currentGameMoney = 1;

    void Start()
    {
        _scoreOnHand.text = _currentGameMoney.ToString();
        EventManager.current.OnCupAdded += AddCup;
        EventManager.current.OnCupCoffeeAdded += OnCupCoffeeAdded;
        EventManager.current.OnLooseCup += OnLooseCup;
        
    }

    private void OnDisable()
    {
        EventManager.current.OnCupAdded -= AddCup;
        EventManager.current.OnCupCoffeeAdded -= OnCupCoffeeAdded;
        EventManager.current.OnLooseCup -= OnLooseCup;
    }

    void Update()
    {
        
    }

    private void AddCup()
    {
        
        //ActivateCup
        foreach (var cup in _cupsInRaw)
        {
            if (!cup.GetComponent<CapsuleCollider>().enabled)
            {
                //EnableView
                SwitchCup(cup, true);
                UpdateHandScore(1);
                break;
            }                
        }
    }

    private void SwitchCup(GameObject cup, bool isActive)
    {
        cup.GetComponent<CapsuleCollider>().enabled = isActive;


        GameObject animeLevelObject = cup.transform.GetChild(0).gameObject;
        GameObject cubObject = animeLevelObject.transform.GetChild(0).gameObject;

        cubObject.GetComponent<MeshRenderer>().enabled = isActive;

        if (isActive)
        {
            Animator animator = animeLevelObject.GetComponent<Animator>();
            animator.speed = 3;
            animator.SetTrigger(AnimeConst.startCap);
        }
    }

    private void OnCupCoffeeAdded()
    {
        UpdateHandScore(1);
    }

    private void UpdateHandScore(int amount)
    {
        _currentGameMoney += amount;
        Debug.Log("CurrentMoney: " + _currentGameMoney);
        _scoreOnHand.text = _currentGameMoney.ToString();
    }

    private void OnLooseCup(int amount)
    {
        UpdateHandScore(-amount);
    }
}
