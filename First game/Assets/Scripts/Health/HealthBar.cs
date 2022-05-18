
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject player;
    public static HealthBar instance { get; private set; }
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
        playerHealth = player.GetComponent<Health>();
    }

    public void RenewPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
        totalHealthBar.fillAmount = playerHealth.getStartingHealth() / 10;
        if (playerHealth == null)
        {
            RenewPlayer();
        }
        if ((playerHealth.getStartingHealth() / 10) == 4)
            Debug.Log("Yes it's 4");
    }
}
