using UnityEngine;

public class PlayerController : MonoBehaviour {

    private void Update() {
        if (GameManager.isPlaying) {
            if (GameManager.isStarted) {
                if (Input.GetMouseButtonDown(0)) {//Sự kiện nhấn chuột hoặc tap vào màn hình
                    Player.State.Jump();
                }
            }
        }
    }
}

