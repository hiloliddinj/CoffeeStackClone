using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapAnimeController : MonoBehaviour
{
    private Animator _animator;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimeConst.startCap);
    }

    void Update()
    {
        
    }
}
