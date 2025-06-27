using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SuikaGameManager : MonoBehaviour
{
    public static SuikaGameManager instance;

    public int CurrentScore { get; set; }

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverPanel;

    public float TimeTillGameOver = 1.5f;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _scoreText.text = CurrentScore.ToString("0");
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        _scoreText.text = CurrentScore.ToString("0");
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        //Invoke(nameof(ReloadScene), TimeTillGameOver);
    }

    //private void ReloadScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameOverPanel.SetActive(false);
    }
}
