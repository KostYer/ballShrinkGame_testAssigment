using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InputEventHubSO", menuName = "Game/InputEventHubSO")]
public class InputEventHubSO : ScriptableObject
{
    public event Action OnTapStarted;
    public event Action OnTapEnded;



    public void TapStarted()
    {
        OnTapStarted?.Invoke();
    }


    public void TapEnded()
    {
        OnTapEnded?.Invoke();
    }
}
