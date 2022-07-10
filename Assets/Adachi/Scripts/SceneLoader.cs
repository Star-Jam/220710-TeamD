using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehavior<SceneLoader>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
}
