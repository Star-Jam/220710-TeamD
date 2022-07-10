using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : SingletonMonoBehavior<GameManeger>
{
    [SerializeField]
    [Header("êßå¿éûä‘")]
    float _timer;

    bool _first;

    protected override void Awake()
    {
        base.Awake();
        _first = true;
        UIManager.Instance.AddTextValue(0, TextType.Level);
    }

    private void Update()
    {
        if (_timer <= 0 && _first)
        {
            _timer = 0;
            UIManager.Instance.AddTextValue(_timer, TextType.Timer);
            StartCoroutine(UIManager.Instance.ResultPanelSetActive());
            _first = false;
        }
        else if(_timer > 0)
        {
            _timer -= Time.deltaTime;
            UIManager.Instance.AddTextValue(_timer, TextType.Timer);
        }
    }
}
