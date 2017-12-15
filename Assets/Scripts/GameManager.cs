using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool isStarted = false;
    public static bool isPlaying;
    private void Start() {
        isPlaying = true;
    }
}
