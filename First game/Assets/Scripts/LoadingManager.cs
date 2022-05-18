
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    [Header("Scene Number")]
    [SerializeField] private int sceneNumber;
    [Header("Next Level Sound")]
    [SerializeField] private AudioClip nextLevelSound;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Entered new scene");
            sceneNumber++;
            SceneManager.LoadScene(sceneNumber);
            SoundManager.instance.PlaySound(nextLevelSound);


        }
    }


}
