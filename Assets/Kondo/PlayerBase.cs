using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float A => a;
    /// <summary>/// プレイヤーのレベル/// </summary>
    public int PlayerLevel => _playerLevel;

    [SerializeField]
    [Header("プレイヤーのスピード")]
    float _speed;

    [SerializeField]
    [Header("プレイヤーのレベル")]
    int _playerLevel = 5;

    [SerializeField]
    [Header("エネミーのタグ")]
    string _enemy;

    [Header("プレイヤーの大きさ")]
    Vector3 _playerScale = new Vector3(0.5f,0.5f,0);

    [SerializeField]
    [Header("エネミーを食べたときどれだけ大きくなるか")]
    float _getBigger;

    [Header("前回のポジション")]
    Vector3 latestPos;
    float a;
    Camera _camera;

    private void Awake()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
    }
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = Vector3.Lerp(transform.position, pos, _speed * Time.deltaTime);
        }
        if(Input.GetMouseButton(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = Vector3.Lerp(transform.position, pos, _speed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _enemy)
        {
            var a = collision.gameObject.GetComponent<EnemyBase>();
            if (a.EnemyLevel < _playerLevel)Eat();
            else if(a.EnemyLevel >= _playerLevel)Eaten();
        }
    }

    private void Eat()
    {
        _playerLevel++;
        _playerScale = transform.localScale;
        _playerScale.x += _getBigger;
        _playerScale.y += _getBigger;
        transform.localScale = _playerScale;
        if(_speed <= 1)_speed -= 0.05f;
        _camera.orthographicSize += 0.5f;
        ScoreManager.Instance.AddScore(_playerLevel);
        UIManager.Instance.AddTextValue(_playerLevel,TextType.Level);
        a += _getBigger;
    }

    private void Eaten()
    {
        _playerScale.x /= 2;
        _playerScale.y /= 2;
    }
}
