using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    public Text scoreText;
    public Text highscoreText;


    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Delete the duplicate gameObjects
        else if (instance != null && instance != this)
        {
            DestroyObject(gameObject);
        }

        instance.highscore = PlayerPrefs.GetInt("highscore", 0);
        instance.score = PlayerPrefs.GetInt("score", 0);
    }



    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString() + " POINTS";
        PlayerPrefs.SetInt("score", score);
        if (score > highscore)
            PlayerPrefs.SetInt("highscore", score);
    }
}
