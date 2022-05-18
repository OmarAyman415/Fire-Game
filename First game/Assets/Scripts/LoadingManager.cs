
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    [Header("Scene Number")]
    [SerializeField] private int sceneNumber;
    [Header("Next Level Sound")]
    [SerializeField] private AudioClip nextLevelSound;

    private Health playerHealth;
    private GameObject player;
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<Health>();
            
            Debug.Log("Entered new scene");
            SceneManager.LoadScene(sceneNumber);
            SoundManager.instance.PlaySound(nextLevelSound);

        }
    }
}
