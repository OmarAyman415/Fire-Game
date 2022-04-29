using UnityEngine;

public class ScoreData : ScriptableObject
{
    [SerializeField]
    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

}
