using UnityEngine;

public class HandControl : MonoBehaviour
{
    private Touch _touch;
    private float _frontSpeedModifier;
    private float _horizontalSpeedModifier;

    private bool _didCameToEnd;

    void Start()
    {
        _frontSpeedModifier = 0.02f;
        _horizontalSpeedModifier = 0.02f;
    }


    void Update()
    {
        //Touch Control
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * _frontSpeedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }

        //Mouse Control
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis(InputConst.mouseX) < 0)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x - .05f,
                        transform.position.y,
                        transform.position.z),
                    .3f);
            }

            if (Input.GetAxis(InputConst.mouseX) > 0)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x + .05f,
                        transform.position.y,
                        transform.position.z),
                    .3f);
            }

        }

    }

    private void FixedUpdate()
    {
        if (!_didCameToEnd)
            transform.Translate(.5f * Time.deltaTime * Vector3.forward);
    }
}
