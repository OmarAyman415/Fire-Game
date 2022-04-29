
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{

    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;// time before the fire trap fires up
    [SerializeField] private float activeTime;// fires activated time 

    [Header("SFX")]
    [SerializeField] private AudioClip fireSound;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trap is triggered
    private bool active; // when the trap is active and can hurt the player

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerHealth != null && active)// If the player is on firetrap and the firetrap is active
            // Damage the player
            playerHealth.TakeDamage(damage);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            // to not make the fire trap activated more than once at a time
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            // if the fire is activated and the player touched the fire, make the player get damage
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);

        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")// if the player exited the fire trap
            //Don't access it's health
            playerHealth = null;
    }

    private IEnumerator ActivateFiretrap()
    {
        // Turn FireTrap to red to notify the player
        triggered = true;
        spriteRend.color = Color.red; 
        // Wait for delay, 
        yield return new WaitForSeconds(activationDelay);
        // return color back to normal
        spriteRend.color = Color.white;
        // activate trap
        active = true;
        // turn on animation
        anim.SetBool("activated",true);
        SoundManager.instance.PlaySound(fireSound);


        // wait until {activeTime} seconds
        yield return new WaitForSeconds(activeTime);
        //Deactivate the trap
        active = false;
        //reset all variables and animator as well
        triggered = false;
        anim.SetBool("activated", false);
    }


}
