
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
        totalHealthBar.fillAmount = playerHealth.getStartingHealth() / 10;
        if ((playerHealth.getStartingHealth() / 10) == 4)
            Debug.Log("Yes it's 4");
    }
}
