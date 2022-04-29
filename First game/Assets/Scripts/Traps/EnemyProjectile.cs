using UnityEngine;

public class EnemyProjectile : EnemyDamage // Will Damage the player every time they touch
{
    [SerializeField] private float speed;// Speed of the Projectile
    [SerializeField] private float resetTime;// Life time of the Projectile

    private float lifeTime;
    private Animator anim;
    private bool hit;
    private BoxCollider2D boxCollide;
    private void Awake()
    {
        // Get the animation and boxCollider components 
        anim = GetComponent<Animator>();
        boxCollide = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {

        if (hit) return;// if the projectile hit something then stop moving

        float movementSpeed = speed * Time.deltaTime;

        transform.Translate(movementSpeed, 0, 0); // Move the projectile with (movementSpeed) velocity

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)// to prevent the projectile from moving too long
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;

        base.OnTriggerEnter2D(collision);// Execute logic from parent script from EnamyDamage script

        if (anim != null)
            anim.SetTrigger("explode");// When the object is a fireball, Explode it
        else
            gameObject.SetActive(false);// When the object is an arrow, Deactivate the arrow
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
