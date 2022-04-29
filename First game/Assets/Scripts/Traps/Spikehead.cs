using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikehead : EnemyDamage
{
    
    [Header ("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    
    


    private void OnEnable()
    {
        Stop();
    }

    private bool attacking; 
    private void Update()
    {
        if (attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();
        // Check if the spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position,directions[i], range,playerLayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range; // Right direction
        directions[1] = -transform.right * range;// Left direction
        directions[2] = transform.up * range;// Up direction
        directions[3] = -transform.up * range;// Down direction
    }

    private void Stop()
    {
        destination = transform.position;// Set destination as current position so it will stop
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        // Stop spikeHead once it hits something
        Stop();
        SoundManager.instance.PlaySound(impactSound);

    }

}
