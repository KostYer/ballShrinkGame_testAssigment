using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] private GamePlayEventHubSO gamePlayEvents = default;
    Animator animator;
    string animTriggerName = "DoorTrigger";

    void Start()
    {
        gamePlayEvents.OnPathCleared+= DoorTrigger;
      
        animator = GetComponent<Animator>();
    }

    //[ContextMenu("DoorChangeState")]
    void DoorTrigger()
    {
        animator.SetTrigger(animTriggerName);
        
    }
}
