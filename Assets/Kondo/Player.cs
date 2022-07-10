using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーのスピード")]
    float _speed;

    [SerializeField]
    [Header("プレイヤーの食べた量")]
    int _mealAmount;

    [SerializeField]
    [Header("エネミーのタグ")]
    string _enemy;

    void Update()
    {
        Move();  
    }
    private void Move()
    {
        if(Input.touchCount > 0)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _enemy)
        {
            _mealAmount++;
        }
    }
}
