using UnityEngine;

public class HandControl : MonoBehaviour
{
    public static float horizontalSpeedModifier = 0.1f;
    public static float frontSpeedModifier = 1.5f;
    public static float t = 0.1f;

    private Touch _touch;
 
    private bool _didCameToEnd = false;
    private bool _gameStarted = false;

    private void Update()
    {
        MoveForward();
        CapControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.moveUp))
        {
            _didCameToEnd = true;
            EventManager.current.OnLevelFinishedtrigger();
        }
    }

    private void CapControl()
    {
        //Touch Control
        //if (Input.touchCount > 0)
        //{
        //    _touch = Input.GetTouch(0);

        //    if (_touch.phase == TouchPhase.Moved && (transform.position.x > -0.75f && transform.position.x < 0.75f))
        //    {
        //        transform.position = new Vector3(
        //            transform.position.x + _touch.deltaPosition.x * horizontalSpeedModifier,
        //            transform.position.y,
        //            transform.position.z);
        //    }
        //}

        //Mouse Control
        if (Input.GetKey(KeyCode.Mouse0)) {

            if (!_gameStarted) {
                EventManager.current.OnGameStartTrigger();
                _gameStarted = true;
            }
                
            //LEFT
            if (Input.GetAxis(InputConst.mouseX) < 0 && transform.position.x > -0.85f && !GameManager.passedFinishLine)
            {
                EventManager.current.OnGoLeftTrigger();
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x - horizontalSpeedModifier,
                        transform.position.y,
                        transform.position.z),
                    t);
                //transform.Translate(horizontalSpeedModifier * Time.deltaTime * Vector3.left, Space.World);
            }
            //RIGHT
            if (Input.GetAxis(InputConst.mouseX) > 0 && transform.position.x < 0.78f && !GameManager.passedFinishLine)
            {
                EventManager.current.OnGoRightTrigger();
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(
                        transform.position.x + horizontalSpeedModifier,
                        transform.position.y,
                        transform.position.z),
                    t);

                //transform.Translate(horizontalSpeedModifier * Time.deltaTime * Vector3.right, Space.World);
            }

        }
    }

    private void MoveForward()
    {
        if (!_didCameToEnd && _gameStarted)
            transform.Translate(frontSpeedModifier * Time.deltaTime * Vector3.forward, Space.World);
    }
}
