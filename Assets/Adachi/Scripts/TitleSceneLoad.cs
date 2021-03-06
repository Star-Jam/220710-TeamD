using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneLoad : MonoBehaviour
{
    [SerializeField]
    [Header("読み込みたいシーン名")]
    string _sceneName;

    bool _firstPush;
    Touch _touch;

    void Awake()
    {
        _firstPush = true;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
        }

        if (_touch.phase == TouchPhase.Ended && _firstPush)
        {
            _firstPush = false;
            SceneLoader.Instance.LoadScene(_sceneName);
        }
    }
}
