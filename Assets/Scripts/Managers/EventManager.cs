using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    public event Action ExampleEvent;
    public event Action<int> OpenDoorEvent;

    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void OpenDoorEventTrigger(int id)
    {
        OpenDoorEvent?.Invoke(id);
    }

    public void ExampleEventTrigger()
    {
        ExampleEvent?.Invoke();
    }

}
