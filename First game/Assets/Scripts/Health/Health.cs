using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;// Default Health value
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iframes")]
    [SerializeField] private float iframeDuration;
    [SerializeField] private int numberOfFlashes;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Hurt and Die Sounds")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip dieSound;

    private bool invulnerable;

    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable) return;
        // Decrease current health but don't go below 0
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        // as current health is above zero, do hurt animation
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invulnerability());
        }
        // else do death animation
        else
        {

            if (!dead)// to prevent more that one death animation
            {
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(dieSound);
                Debug.Log(gameObject.tag);
                if (gameObject.tag != "Player")
                    ScoreManager.instance.AddPoints(10);
                // Deactivate all attached component classes
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                dead = true;
            }
        }
    }

    public void AddHealth(float additionalHealth)
    {
        // increase current health but don't go above starting health
        currentHealth = Mathf.Clamp(currentHealth + additionalHealth, 0, startingHealth);
    }

    public void AddMaxHealth()
    {
        Debug.Log("Added health");
        startingHealth++;
        currentHealth = startingHealth;
        Debug.Log("Current Health  = " + currentHealth + " and Starting health = " + startingHealth);

    }

    public float getStartingHealth()
    {
        return startingHealth;
    }

    public bool fullHealth()
    {
        return currentHealth == startingHealth;
    }

    // do Invulnerability animation with the player takes damage
    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        // invulnerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframeDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframeDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 12, false);
        invulnerable = false;

    }

    public bool isDead()
    {
        return currentHealth <= 0;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
