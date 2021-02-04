using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    public LayerMask layermask;
    [SerializeField] PlayerController player = default;
    Transform road = default;

  

    [ContextMenu("FindClosestTarget")]
    public Transform FindClosestTarget()
    {

        road = Road.instance.pathway.transform;
        Transform closestObstacle = null;
        Collider[] hitColliders = Physics.OverlapBox(road.transform.position, road.transform.localScale / 2, road.transform.rotation, layermask);
        if (hitColliders.Length == 0) { return closestObstacle; }


        closestObstacle = hitColliders[0].transform;
        int i = 1;
        while (i < hitColliders.Length)
        {
          ///  hitColliders[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
       
            if (Vector3.Distance(player.transform.position,
                hitColliders[i].transform.position)
                < Vector3.Distance(player.transform.position, closestObstacle.position))
            {
                closestObstacle = hitColliders[i].transform;

               
            }
            i++;
        }
    
       
        return closestObstacle;
    }
    

}
