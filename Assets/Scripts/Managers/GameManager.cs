using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cupsInRaw;

    private int _currentGameMoney = 0;

    void Start()
    {
        EventManager.current.OnCupAdded += AddCup;
        EventManager.current.OnCupCoffeeAdded += OnCupCoffeeAdded;
    }

    private void OnDisable()
    {
        EventManager.current.OnCupAdded -= AddCup;
        EventManager.current.OnCupCoffeeAdded -= OnCupCoffeeAdded;
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
                _currentGameMoney++;
                Debug.Log("CurrentMoney: " + _currentGameMoney);
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
        _currentGameMoney++;
        Debug.Log("CurrentMoney: " + _currentGameMoney);
    }
}
