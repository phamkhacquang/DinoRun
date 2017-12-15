using DG.Tweening;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!Player.State.onGround) {
            if (collision.gameObject.CompareTag("Terrain")) {
                Player.State.onGround = true;
            }
        }
        if (collision.gameObject.CompareTag("Enemy")) {
            if (Mathf.Abs(transform.position.y - Player.State.startPosition.y) > 1f) {
                Player.State.DoubleJump();
            } else {
                GameManager.isPlaying = false;
                Camera.main.DOShakeRotation(0.3f, 2);
                Player.State.Die();
            }
        }
    }
}
