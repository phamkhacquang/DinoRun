using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    [SpineAnimation]
    public string run;
    [SpineAnimation]
    public string jumpUp;
    [SpineAnimation]
    public string jumpDown;
    [SpineAnimation]
    public string dash;

    public SkeletonAnimation skeletonAnimation;

    public Spine.AnimationState spineAnimationState;
    [HideInInspector]
    public Vector3 startPosition;
    [HideInInspector]
    public Rigidbody2D myRB;
    [HideInInspector]
    public bool onGround = true;
    [HideInInspector]
    public string currentState;
    private void Start() {
        spineAnimationState = skeletonAnimation.AnimationState;
        startPosition = transform.position;
        myRB = Player.GetPlayerComponent<Rigidbody2D>();
        currentState = run;
    }

    public void DoubleJump() {
        myRB.velocity = Vector2.zero;
        myRB.AddForce(new Vector2(0, 0.8f * jumpForce));
    }

    public void Die() {
        print("Die");
    }

    private float jumpForce = 1000f;
    public void Jump() {
        if (onGround) {
            myRB.AddForce(new Vector2(0, jumpForce));
            onGround = false;
        }
    }

    private void Update() {
        if (onGround) {
            SetState(run);
        } else if (myRB.velocity.y > 1f) {
            SetState(jumpUp);
        } else if (myRB.velocity.y < 1f) {
            SetState(jumpDown);
        }
    }

    public void SetState(string state) {
        if (currentState != state) {
            spineAnimationState.SetAnimation(0, state, state == run);
            currentState = state;
        }
    }
}
