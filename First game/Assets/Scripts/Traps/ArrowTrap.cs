using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private float cooldownTimer;
    private void Attack()
    {
        cooldownTimer = 0;

        SoundManager.instance.PlaySound(arrowSound);// Play Arrow sound
        arrows[FindArrow()].transform.position = firePoint.position;// Move the arrow
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();// Activate the arrow
    }

    // Get all arrows that in inactive to relaunch them all
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        // Throw one arrow at a time
        if (cooldownTimer >= attackCooldown)
            Attack();
    }



}
