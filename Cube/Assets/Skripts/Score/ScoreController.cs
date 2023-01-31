using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highscore;
    [SerializeField] private float _scoreTraveled;
    [SerializeField] private int _score;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            if (_score < 0)
            {
                _score = 0;
            }
        }
    }

    public float ScoreTraveled
    {
        get
        {
            return _scoreTraveled;
        }
        set
        {
            if (_scoreTraveled < 0)
            {
                _scoreTraveled = 0;
            }
        }
    }

    public const string prefScore = "prefScore";

    private void Start()
    {
        _highscore.text += PlayerPrefs.GetInt(prefScore);
    }

    private void Update()
    {
        ToScore();
    }

    public void ToScore()
    {
        _scoreTraveled += Time.deltaTime * 5;
        _scoreText.text = (int)_scoreTraveled + "";
    }

    public void CheckNewHigscore()
    {
        if ((int)_scoreTraveled > PlayerPrefs.GetInt(prefScore))
        {
            //new Highscore
            PlayerPrefs.SetInt(prefScore, (int)_scoreTraveled);

            Debug.Log("new Highscore: " + (int)_scoreTraveled);
        }
        else
        {
            //no new Highscore
            Debug.Log("NO new Hoghscore");
        }
    }
}
