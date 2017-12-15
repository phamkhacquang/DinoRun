using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour {
    [HideInInspector]
    public List<GameObject> listEnableEnemy = new List<GameObject>();
    public List<GameObject> listDisableEnemy = new List<GameObject>();
    public Vector2 randomTimeMinMax;
    private float randomTime = 0;
    private void Start() {
        foreach (var enemy in listDisableEnemy) {
            enemy.SetActive(false);
        }
    }
    private void Update() {
        if (GameManager.isStarted) {
            if (GameManager.isPlaying) {
                if (randomTime > 0) {
                    randomTime -= Time.deltaTime;
                } else {
                    randomTime = Random.Range(randomTimeMinMax.x, randomTimeMinMax.y);
                    GameObject enemy = listDisableEnemy[Random.Range(0, listDisableEnemy.Count)];
                    if (!enemy.activeInHierarchy) {
                        enemy.transform.position = new Vector3(9, enemy.transform.position.y);
                        enemy.SetActive(true);
                        listEnableEnemy.Add(enemy);
                        listDisableEnemy.Remove(enemy);
                    }
                }
                for (int i = listEnableEnemy.Count - 1; i >= 0; i--) {
                    var enemy = listEnableEnemy[i];//TODO
                    if (enemy.activeInHierarchy) {
                        if (enemy.transform.position.x < -9) {
                            enemy.SetActive(false);
                            listEnableEnemy.Remove(enemy);
                            listDisableEnemy.Add(enemy);
                        }
                    }
                }
            }
        }
    }
}
