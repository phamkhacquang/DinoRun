using System;
using UnityEngine;
using DG.Tweening;
public class Player {
    public const string playerTag = "Player";
    private static GameObject _playerGameObject;
    /// <summary>
    /// Gameobject của player được tìm bằng tag "Player"
    /// </summary>
    public static GameObject gameObject {
        get {
            if (_playerGameObject == null) {
#if UNITY_EDITOR
                var allPlayerTag = GameObject.FindGameObjectsWithTag(playerTag);
                if (allPlayerTag.Length == 0) {
                    Debug.LogError("Không thấy GameObject có tag " + playerTag);
                } else if (allPlayerTag.Length > 1) {
                    Debug.LogError("Có nhiều hơn 1 GameObject có tag " + playerTag);
                }
#endif
                _playerGameObject = GameObject.FindWithTag(playerTag);
            }
            return _playerGameObject;
        }
    }

    public static Transform transform {
        get {
            if (gameObject == null) return null;
            else return gameObject.transform;
        }
    }

    private static PlayerController _controller;
    public static PlayerController Controller {
        get {
            if (_controller == null) {
                _controller = GetPlayerComponent<PlayerController>();
            }
            return _controller;
        }
    }
    private static PlayerState _state;
    public static PlayerState State {
        get {
            if (_state == null) {
                _state = GetPlayerComponent<PlayerState>();
            }
            return _state;
        }
    }
    private static PlayerHealth _health;
    public static PlayerHealth Health {
        get {
            if (_health == null) {
                _health = GetPlayerComponent<PlayerHealth>();
            }
            return _health;
        }
    }
    /// <summary>
    /// Lấy Component của player hoặc con dưới 1 lớp của player
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetPlayerComponent<T>() {
        if (gameObject == null) return default(T);
        T component = gameObject.GetComponent<T>();
        if (component == null) {
            component = gameObject.GetComponentInChildren<T>();
        }
        return component;
    }
}

