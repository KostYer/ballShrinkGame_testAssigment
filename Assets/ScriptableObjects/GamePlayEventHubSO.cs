using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GamePlayEventHub", menuName = "Game/GamePlayEventHub")]
public class GamePlayEventHubSO : ScriptableObject
{

    public event Action OnPlayerDied;
    public event Action OnPlayerResize;
    public event Action OnProjectileDestoryed;
    public event Action OnPlayerMoved;
    public event Action OnLevelFinished;
    public event Action OnPathCleared;



    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public void PlayerResized()
    {
        OnPlayerResize?.Invoke();
    }

    public void ProjectileDestoryed()
    {
        OnProjectileDestoryed?.Invoke();
    }
    public void BallChangedPosition()
    {
        OnPlayerMoved?.Invoke();
    }

    public void LevelFinished()
    {
        OnLevelFinished?.Invoke();
    }

    public void PathCleared()
    {
        OnPathCleared?.Invoke();
    }

}
