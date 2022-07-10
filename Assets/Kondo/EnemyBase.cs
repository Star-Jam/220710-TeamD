using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyLevel => _enemyLebel;

    [SerializeField]
    [Header("エネミーのレベル")]
    int _enemyLebel = 1;

    [SerializeField]
    [Header("プレイヤーのタグ")]
    string _playerTag = "Player";

    [SerializeField]
    [Header("生成されてから消えるまで")]
    float _deleteSpeed = 60;

    [SerializeField]
    [Header("Enemyのスピード")]
    float _enemySpeed = 0f;

    [SerializeField]
    [Header("下に動く速度")]
    float _moveUnder;

    Transform _myTransform = default;


    private void Start()
    {
        Transform _mytransform = this.transform;
        Invoke(nameof(Delete), _deleteSpeed);
    }

    private void Update()
    {
        EnemyMove();
        EnemyRotate();
    }

    void EnemyMove()
    {
        var tr = gameObject.transform.position;
        tr.x += _enemySpeed / 100;
        tr.y += _moveUnder / 100;
        gameObject.transform.position = tr;
    }

    private void EnemyRotate()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _playerTag)
        {
            var a = collision.gameObject.GetComponent<PlayerBase>();
            if(a.PlayerLevel > _enemyLebel)
            {
                Delete();
            }
        }
    }
}
