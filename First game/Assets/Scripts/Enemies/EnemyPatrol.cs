using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    

    [Header("Enemy")]
    [SerializeField] private Transform Enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    private Vector3 initScale;
    private bool movingLeft;
    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Awake()
    {
        initScale = Enemy.localScale;
    }
    private void Update()
    {
        
        if (movingLeft)
        {
            if (Enemy.position.x >= leftEdge.position.x) // Didn't cross left edge
                MoveInDirection(-1);
            else // Change direction
                ChangeDirection();

        }
        else
        {
            if (Enemy.position.x <= rightEdge.position.x)// Didn't cross right edge
                MoveInDirection(1);
            else// Change direction
                ChangeDirection();
        }
        
    }
    private void ChangeDirection()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;
        if(idleTimer> idleDuration)
            movingLeft = !movingLeft; 
    }
    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        //Make enemy face direction
        Enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction,
            initScale.y,
            initScale.z);

        //Move in that direction
        Enemy.position = new Vector3(Enemy.position.x + Time.deltaTime * direction * speed,
            Enemy.position.y,
            Enemy.position.z);
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
}
