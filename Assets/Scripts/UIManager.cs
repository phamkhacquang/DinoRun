using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public Button tapButton;
    public Text tapButtonText;
    public Text scoreText;
    [HideInInspector]
    public int score;
    private void Start() {
        if (GameManager.isStarted) {
            tapButtonText.text = "Tap to restart";
            tapButton.gameObject.SetActive(false);
        }
    }
    private void Update() {
        if (GameManager.isPlaying) {
            scoreText.text = "Score: " + score.ToString("0000000");
        } else {
            if (GameManager.isStarted) {
                tapButton.gameObject.SetActive(true);
            }
        }
    }
    private void FixedUpdate() {
        if (GameManager.isPlaying) {
            score += (int)(Time.fixedDeltaTime * 100);
        }
    }

    public void TapButtonClick() {
        if (GameManager.isStarted) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            GameManager.isStarted = true;
            tapButton.gameObject.SetActive(false);
        }
    }
}
