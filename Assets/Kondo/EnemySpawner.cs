using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    [Header("沸くエネミー")]
    GameObject[] _enemies;
    
    [Header("敵が湧く周期")]
    [SerializeField] float _minDistance;
    [SerializeField] float _maxDistance;

    IEnumerator _spawn;

    void Start()
    {
        _spawn = Spawn();
        StartSpawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) EndSpawn();
    }

    // 敵のスポーン開始
    public void StartSpawn() => StartCoroutine(_spawn);
    // 敵のスポーン終了
    public void EndSpawn() => StopCoroutine(_spawn);

    // 敵をスポーンさせる
    IEnumerator Spawn()
    {
        while (true)
        {
            float distance = Random.Range(_minDistance, _maxDistance + 1);
            yield return new WaitForSecondsRealtime(distance);
            int r = Random.Range(0, _enemies.Length);
            Instantiate(_enemies[r], transform.position, Quaternion.identity);
        }
    }
}
