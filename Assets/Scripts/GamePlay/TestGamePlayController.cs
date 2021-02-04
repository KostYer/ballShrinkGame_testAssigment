using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGamePlayController : MonoBehaviour
{
 
    [SerializeField] private GamePlayEventHubSO gamePlayEvents = default;
    [SerializeField] private InputEventHubSO inputEventHub = default;

    [SerializeField] PlayerController player = default;
    [SerializeField] GameObject pr_projectile = default;
    [SerializeField] Transform finishPoint = default;
    ObstacleDetector obstaclesDetector = default;

    public LayerMask layerMask;
    private Projectile projectile = default;

   
    Vector3 movementDirection;

    private bool canShoot = false;
    //ObstaclesDetector obstaclesDetector;

    void Start()
    {
        inputEventHub.OnTapStarted += HandleTapStart;
        inputEventHub.OnTapEnded += HandleTapEnd;
        canShoot = true;
        gamePlayEvents.OnProjectileDestoryed += HandleNextTurn;

        movementDirection = (finishPoint.position - player.transform.position).normalized;

        //obstaclesDetector = new ObstaclesDetector(player.transform, movementDirection, layerMask );
        obstaclesDetector = GetComponent<ObstacleDetector>();
    }
    //private void Update()
    //{
    //    movementDirection = (finishPoint.position - player.transform.position);//.normalized ;
    //    Debug.DrawRay(player.transform.position, movementDirection, Color.yellow);
    //    //ObstacleDetectorTest();


    

    //}

    private void HandleNextTurn()
    {
        movementDirection = (finishPoint.position - player.transform.position).normalized;

        if (obstaclesDetector.FindClosestTarget() == null) { AllObstaclesDestroyed(); }
        else
        {
            Transform closestObstacle = obstaclesDetector.FindClosestTarget();
            player.MovePlayerFurther(movementDirection, closestObstacle);
            //closestObstacle = obstaclesDetector.FindClosestTarget();
            //Debug.Log(closestObstacle+" closestObstacle");
            canShoot = true;
        }
    }


    void HandleTapStart()
    {
        if (!canShoot) return;
        player.ShrinkBall();
        projectile = Instantiate(pr_projectile).GetComponent<Projectile>();
        projectile.transform.position = player.shootPoint.position;
        projectile.ResizeProjectile();
        //projectile.IncreaseImpactRadius();

    }

    void HandleTapEnd()
    {

        projectile.Launch(finishPoint.position);
        player.StopBallShrink();
        canShoot = false;
    }


    private void AllObstaclesDestroyed()
    {
        gamePlayEvents.PathCleared();
        canShoot = false;
        player.MoveToLevelFinish(finishPoint);
    }



}
