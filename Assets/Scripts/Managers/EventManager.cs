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
    public event Action OnCupHatAdded;
    public event Action OnCupSleeveAdded;

    public event Action<int> OnLooseCup;

    public event Action OnPassedFinishLine;
    public event Action OnLevelFinished;


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

    public void OnCupHatAddedTrigger()
    {
        OnCupHatAdded?.Invoke();
    }

    public void OnCupSleeveAddedTrigger()
    {
        OnCupSleeveAdded?.Invoke();
    }

    public void OnLooseCupTrigger(int amount)
    {
        OnLooseCup?.Invoke(amount);
    }

    public void OnPassedFinishLineTrigger()
    {
        OnPassedFinishLine?.Invoke();
    }

    public void OnLevelFinishedtrigger()
    {
        OnLevelFinished?.Invoke();
    }




}
