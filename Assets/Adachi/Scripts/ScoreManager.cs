using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehavior<ScoreManager>
{
    public int Score => _score;

    int _score;
    int _enemyCount;

    protected override void Awake()
    {
        base.Awake();
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    public int AddScore(int score) => _score += score;
    public int AddEnemyCount(int enemyCount) => _enemyCount += enemyCount;
}
