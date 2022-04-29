
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom; 
    [SerializeField] private new CameraController camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")//if the Player passed through the door move the camera 
        {
            if (collision.transform.position.x < transform.position.x)// Players moves from first room to second room
            {
                camera.MoveToNewRoom(nextRoom);
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                camera.MoveToNewRoom(previousRoom);
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }

}
