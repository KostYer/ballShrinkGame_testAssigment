using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private InputEventHubSO inputEventHub = default;
    //void Start()
    //{

    //}
    public event Action OnTapStarted;
    public event Action OnTapEnded;
    private Touch touch;


    void Update()
    {
/////desctop  input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputEventHub.TapStarted();

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            inputEventHub.TapEnded();

        }

/////mobile input
 
        if (Input.touchCount > 0    )
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                inputEventHub.TapStarted();
            }

            //if (touch.phase == TouchPhase.Moved)
            //{
                 
            //}

            if (touch.phase == TouchPhase.Ended)
            {

                inputEventHub.TapEnded();
            }

        }






    }
}
