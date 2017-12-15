using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public Button tapButton;
    public Text tapButtonText;
    public Text scoreText;
    public int highScore = 0;
    private const string highScoreKey = "HighScore";
    [HideInInspector]
    public float score;
    private void Start() {
        if (GameManager.isStarted) {
            tapButtonText.text = "Tap to restart";
            tapButton.gameObject.SetActive(false);
        }
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }
    private void Update() {
        if (GameManager.isPlaying) {
            string scoreTextTmp = "";
            if (highScore > 0) scoreTextTmp = "HI: " + highScore.ToString("000000");
            scoreTextTmp += "  " + Mathf.RoundToInt(score).ToString("000000");
            scoreText.text = scoreTextTmp;
        } else {
            if (GameManager.isStarted) {
                tapButton.gameObject.SetActive(true);
            }
        }
    }
    private void FixedUpdate() {
        if (GameManager.isStarted && GameManager.isPlaying) {
            score += Time.fixedDeltaTime * 30;
        }
    }

    public void TapButtonClick() {
        if (GameManager.isStarted) {
            GameManager.isStarted = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        } else {
            GameManager.isStarted = true;
            tapButton.gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        if (score > highScore) {
            PlayerPrefs.SetInt(highScoreKey, (int)score);
            PlayerPrefs.Save();
        }
    }
}
