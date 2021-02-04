
using UnityEngine;
using UnityEngine.UI;

public class HealtBarController : MonoBehaviour
{
    [SerializeField] Image healthBar = default;
    [SerializeField] PlayerController player = default;
    [SerializeField] private GamePlayEventHubSO gamePlayEvents = default;

    private float initialSizeDiff;

    void Start()
    {
        gamePlayEvents.OnPlayerResize += SetHealth;
        initialSizeDiff = player.transform.localScale.x - player.deathScale;
        SetHealth();
        
        //Debug.Log("sd");
    }

    private void SetHealth()
    {
        healthBar.fillAmount = (player.transform.localScale.x - player.deathScale) / initialSizeDiff;
    }
     
    

    
}
