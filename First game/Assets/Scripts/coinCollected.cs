using UnityEngine;

public class coinCollected : MonoBehaviour
{
    [SerializeField] int value;

    [Header("Coin Sound")]
    [SerializeField] private AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D otherObjects)
    {
        SoundManager.instance.PlaySound(coinSound);
        Destroy(gameObject);
        ScoreManager.instance.AddPoints(value);
        // Comment
    }
}
