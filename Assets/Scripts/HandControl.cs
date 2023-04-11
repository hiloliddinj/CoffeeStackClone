using UnityEngine;

public class HandControl : MonoBehaviour
{
    private float _frontSpeedModifier = 1.5f;
    [SerializeField] private float _horizontalSpeedModifier;

    private Touch _touch;
 
    private bool _didCameToEnd = false;

    private void Update()
    {
        MoveForward();
        CapControl();
    }

    private void CapControl()
    {
        //Touch Control
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved && (transform.position.x > -0.75f && transform.position.x < 0.75f))
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * _horizontalSpeedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }

        //Mouse Control
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis(InputConst.mouseX) < 0 && transform.position.x > -0.85f)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x - _horizontalSpeedModifier,
                        transform.position.y,
                        transform.position.z),
                    .3f);
            }

            if (Input.GetAxis(InputConst.mouseX) > 0 && transform.position.x < 0.78f)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x + _horizontalSpeedModifier,
                        transform.position.y,
                        transform.position.z),
                    .3f);
            }

        }
    }

    private void MoveForward()
    {
        if (!_didCameToEnd)
            transform.Translate(_frontSpeedModifier * Time.deltaTime * Vector3.forward);
    }
}
