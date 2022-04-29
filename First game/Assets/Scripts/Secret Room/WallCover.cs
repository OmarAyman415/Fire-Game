using UnityEngine;

public class WallCover : MonoBehaviour
{

    //[Header("Collier Parameters")]
    //[SerializeField] private float colliderDistance;
    //[SerializeField] private BoxCollider2D boxCollider;

    //[Header("Player Layer")]
    //[SerializeField] private LayerMask playerLayer;
    //private bool coverState = true;

    [SerializeField] SpriteRenderer[] wallElements;
    float alphaValue = 1f;

    bool playerEntered = false;
    public float disappearRate = 1f;
    public bool toggleWall = false;



    private void Update()
    {
        if (playerEntered)
        {
            alphaValue -= Time.deltaTime * disappearRate;

            if (alphaValue <= 0)
            {
                alphaValue = 0;
            }

            foreach (SpriteRenderer wallItem in wallElements)
            {
                wallItem.color = new Color(wallItem.color.r, wallItem.color.g, wallItem.color.b, alphaValue);
            }
        }
        else
        {
            alphaValue += Time.deltaTime * disappearRate;

            if (alphaValue >= 1)
            {
                alphaValue = 1;
            }

            foreach (SpriteRenderer wallItem in wallElements)
            {
                wallItem.color = new Color(wallItem.color.r, wallItem.color.g, wallItem.color.b, alphaValue);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEntered = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && toggleWall)
        {
            playerEntered = false;
        }
    }

    //private bool PlayerInSight()
    //{
    //    RaycastHit2D hit =
    //        Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x,// Range from center
    //        new Vector3(boxCollider.bounds.size.x, boxCollider.bounds.size.y, boxCollider.bounds.size.z),// Size of the box
    //        0,// Angle
    //        Vector2.left,
    //        0,
    //        playerLayer);// Player that collide with



    //    return hit.collider != null;
    //}


}