using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspressoMovement : MonoBehaviour
{
    [SerializeField] private float xRight, xLeft;

    private int _xDirection = 1;

    private void Update()
    {
        MoveEspresso();
    }

    private void MoveEspresso()
    {


        if (transform.position.x > xRight)
            _xDirection = -1;
        else if (transform.position.x < xLeft)
            _xDirection = 1;


        transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(
                    transform.position.x + 0.003f * _xDirection,
                    transform.position.y,
                    transform.position.z),
                0.3f);



    }
}
