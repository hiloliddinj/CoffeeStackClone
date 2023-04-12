using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;


    public event Action OnGameStart;
    public event Action OnGoLeft;
    public event Action OnGoRight;

    public event Action OnCupAdded;
    public event Action OnCupCoffeeAdded;

    public event Action<int> OnLooseCup;


    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void OnGameStartTrigger() {
        OnGameStart?.Invoke();
    }

    public void OnGoLeftTrigger() {
        OnGoLeft?.Invoke();
    }

    public void OnGoRightTrigger() {
        OnGoRight?.Invoke();
    }

    public void OnCupAddedTrigger()
    {
        OnCupAdded?.Invoke();
    }

    public void OnCupCoffeeAddedTrigger()
    {
        OnCupCoffeeAdded?.Invoke();
    }

    public void OnLooseCupTrigger(int amount)
    {
        OnLooseCup?.Invoke(amount);
    }




}
