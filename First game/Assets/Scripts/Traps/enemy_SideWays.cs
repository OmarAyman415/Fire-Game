using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_SideWays : MonoBehaviour
{
    [SerializeField] private float movementDistance;// Distance that the enemy covers
    [SerializeField] private float speed;// Enemy speed
    [SerializeField] private float damage;// Enemy Damage

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;// Left edge from initial enemy position
        rightEdge = transform.position.x + movementDistance;// Right edge from initial enemy position
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge) // enemy crossed the left edge
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); // enemy move to the right
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)// enemy crossed the right edge
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);// enemy move to the left
            }
            else
                movingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

