using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Road : MonoBehaviour
{
    [SerializeField] Transform target = default;
    [SerializeField] Transform player = default;
    [SerializeField] GameObject pr_pathway = default;


    [SerializeField] GamePlayEventHubSO gamePlayEvents = default;
    public GameObject pathway;

    public static Road instance = null;
    //[SerializeField] float angleCorrection;
    void Start()
    {
        if (instance == null)
        {  
            instance = this;  
        }
        else if (instance == this)
        { 
            Destroy(gameObject);  
        }


        pathway = GameObject.Instantiate(pr_pathway) as GameObject;
       
        gamePlayEvents.OnPlayerResize += ResizePathwayX;
        gamePlayEvents.OnPlayerMoved += AllignPathway;

        AllignPathway();
    }

    


    private void ResizePathwayX()
    {
        pathway.transform.localScale = new Vector3(player.transform.localScale.x, pathway.transform.localScale.y, pathway.transform.localScale.z);
    }

    [ContextMenu("AllignPathway ")]
    void AllignPathway()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 FinishPos = target.position;
        playerPos.y = 0.1f; FinishPos.y = 0.1f;

        /*position*/
        Vector3 centerPos = Vector3.Lerp(playerPos, FinishPos, 0.5f);
        //centerPos.y = 0.1f;
        pathway.transform.position = centerPos;

        /*rotation*/
        pathway.transform.LookAt(FinishPos);

        /*scale*/
        //float scaleX = Mathf.Abs(transform.position.x  - target.position.x);
        var distance = (playerPos - FinishPos).magnitude;
        pathway.transform.localScale = new Vector3(player.transform.localScale.x , pathway.transform.localScale.y, distance  );

 
    }

   




}
