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
            tapButtonText.text = "Tap to restart";//Đổi chữ start thành restart
            tapButton.gameObject.SetActive(false);
        }
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);//Đọc điểm từ bộ nhớ
    }
    private void Update() {
        if (GameManager.isPlaying) {
            string scoreTextTmp = "";
            if (highScore > 0) scoreTextTmp = "HI: " + highScore.ToString("000000");//Hiện điểm cao nhất nếu có
            scoreTextTmp += "  " + Mathf.RoundToInt(score).ToString("000000");//Hiện điểm hiện tại
            scoreText.text = scoreTextTmp;
        } else {
            if (GameManager.isStarted) {
                tapButton.gameObject.SetActive(true);//Ẩn chữ tap to start đi
            }
        }
    }
    private void FixedUpdate() {
        if (GameManager.isStarted && GameManager.isPlaying) {
            score += Time.fixedDeltaTime * 30;//Tăng điểm theo thời gian
        }
    }

    public void TapButtonClick() {//Khi chữ Tap to start được nhấn vào
        if (GameManager.isStarted) {
            GameManager.isStarted = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Load lại từ đầu khi chết            
        } else {
            GameManager.isStarted = true;
            tapButton.gameObject.SetActive(false);//Ẩn chữ tap to start đi
        }
    }

    private void OnDisable() {
        if (score > highScore) {//Lưu điểm cao
            PlayerPrefs.SetInt(highScoreKey, (int)score);
            PlayerPrefs.Save();
        }
    }
}
