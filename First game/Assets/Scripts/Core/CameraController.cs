using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] float speed;
    private float currentPosX;//camera's X-axis position
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;// player's position

    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     // Delete the duplicate gameObjects
    //     else if (instance != null && instance != this)
    //     {
    //         DestroyObject(gameObject);
    //     }
    // }
    private void Update()
    {
        // Camera moves From room to room
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),ref velocity,speed);

        //Make the Camera always follow the player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currentPosX = newRoom.position.x;
    }
}
