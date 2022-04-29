using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [Header("SFX")]
    [SerializeField] private AudioClip collectSound;

    private Health playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.GetComponent<Health>().fullHealth())
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            SoundManager.instance.PlaySound(collectSound);
            playerHealth = collision.GetComponent<Health>();
            //playerHealth.AddMaxHealth();

            //Debug.Log(playerHealth.getStartingHealth());
        }
    }
}
