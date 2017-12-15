using UnityEngine;

public class PlayerController : MonoBehaviour {

    private void Update() {
        if (GameManager.isPlaying) {
            if (GameManager.isStarted) {
                if (Input.GetMouseButtonDown(0)) {
                    Player.State.Jump();
                }
            }
        }
    }
}

