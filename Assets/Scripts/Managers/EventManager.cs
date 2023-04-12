using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;


    public event Action OnGameStart;
    public event Action OnGoLeft;
    public event Action OnGoRight;

    public event Action OnCupAdded;
    

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

    

}
