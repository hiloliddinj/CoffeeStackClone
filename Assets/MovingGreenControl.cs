using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MovingGreenControl : MonoBehaviour
{
    [SerializeField] private float yUp, yDown;
    private float _speed = 3.0f;

    private int _yDirection = 1;

    void Update()
    {
        MoveGreen();
    }

    private void MoveGreen()
    {
        if (transform.position.y > yUp)
            _yDirection = -1;
        else if (transform.position.y < yDown)
            _yDirection = 1;

        transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(
                    transform.position.x,
                    transform.position.y + _speed * _yDirection * Time.deltaTime,
                    transform.position.z),
                0.3f);
    }
}
