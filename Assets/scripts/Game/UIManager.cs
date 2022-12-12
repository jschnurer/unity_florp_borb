using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public GameObject GameOver;
    public Borb PlayerScript;
    int _score = 0;
    public RandomAudioPlayer _scoreSounds;

    private void Start()
    {
        _scoreSounds = GetComponent<RandomAudioPlayer>();
    }

    private void OnEnable()
    {
        ScoreZone.OnScoreZoneEntered += IncrementScore;
        Borb.OnPlayerDied += ShowGameOver;
    }

    private void OnDisable()
    {
        ScoreZone.OnScoreZoneEntered -= IncrementScore;
        Borb.OnPlayerDied -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void IncrementScore(int scoreValue)
    {
        if (!PlayerScript.IsDead)
        {
            _scoreSounds.PlayRandomSound();
            _score += scoreValue;
            ScoreText.text = _score.ToString();
        }
    }
}
