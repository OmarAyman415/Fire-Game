using UnityEngine;

public class platformMovment : MonoBehaviour
{
    //[SerializeField] private float movementDistance;// Distance that the enemy covers
    //[SerializeField] private float speed;// platform speed

    //private bool movingLeft;
    //private float leftEdge;
    //private float rightEdge;

    //private void Awake()
    //{
    //    leftEdge = transform.position.x - movementDistance;// Left edge from initial enemy position
    //    rightEdge = transform.position.x + movementDistance;// Right edge from initial enemy position
    //}

    //private void Update()
    //{
    //    if (movingLeft)
    //    {
    //        if (transform.position.x > leftEdge) // enemy crossed the left edge
    //        {
    //            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); // enemy move to the right
    //        }
    //        else
    //            movingLeft = false;
    //    }
    //    else
    //    {
    //        if (transform.position.x < rightEdge)// enemy crossed the right edge
    //        {
    //            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);// enemy move to the left
    //        }
    //        else
    //            movingLeft = true;
    //    }
    //}


    [SerializeField] private float speed; // Speed of the platform
    private int startingPoint = 0;// Starting index (Position of the platform)
    [SerializeField] private Transform[] points;// An array of transform points (Positions where the platform moves to)

    private int i;
    private void Start()
    {
        transform.position = points[startingPoint].position;

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;// inc the index
            if (i == points.Length)// check if the platform was on the point after the index increased
            {
                i = 0;
            }
        }

        // Move the platform to the next point
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
        collision.transform.localScale = new Vector3(Mathf.Sign(collision.transform.localScale.x) * 1, 1, 1);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        collision.transform.localScale = new Vector3(Mathf.Sign(collision.transform.localScale.x) * 1, 1, 1);
    }
}
