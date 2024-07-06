using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private string sceneName;

    private int score;
    public int Score => score;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

        player.SetOffset();
    }

    public void GameOver()
    {
        
        gameOver.SetActive(true);
        // 数フレーム待つ
        StartCoroutine(WaitForFrames(60));
    }

    IEnumerator WaitForFrames(int frameCount)
    {
        // 指定されたフレーム数だけ待つ
        for (int i = 0; i < frameCount; i++)
        {
            yield return null;  // 1フレーム待つ
        }

        // フレーム待ちが終わった後の処理
        Debug.Log("Waited for " + frameCount + " frames.");
        AfterWait();
    }

    void AfterWait()
    {
        playButton.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ToPlayScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
