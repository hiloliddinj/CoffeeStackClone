using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cupsInRaw;

    private int _cupCounter = 1;

    void Start()
    {
        EventManager.current.OnCupAdded += AddCup;
    }

    private void OnDisable()
    {
        EventManager.current.OnCupAdded -= AddCup;
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
}
