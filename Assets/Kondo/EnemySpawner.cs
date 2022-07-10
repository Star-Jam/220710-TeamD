using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    [Header("�����G�l�~�[")]
    GameObject[] _enemies;
    
    [Header("�G���N������")]
    [SerializeField] float _minDistance;
    [SerializeField] float _maxDistance;

    IEnumerator _spawn;

    void Start()
    {
        StartCoroutine(Spawn());
    }



    // �G���X�|�[��������
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
