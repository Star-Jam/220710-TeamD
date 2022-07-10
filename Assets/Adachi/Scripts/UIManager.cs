using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField]
    [Header("UIのテキスト")]
    List<UIText> _uiTexts = new();

    [SerializeField]
    [Header("ポーズ画面のパネル")]
    Image _pausePanel;

    [SerializeField]
    [Header("リザルト画面のパネル")]
    Image _resultPanel;

    [SerializeField]
    [Header("リザルト画面のテキスト")]
    List<ResultText> _resultTexts = new();

    PlayerBase _playerBase;

    const float WAIT_SECONDS = 3;

    protected override void Awake()
    {
        base.Awake();
        _playerBase = GameObject.FindObjectOfType<PlayerBase>();
    }

    /// <summary>残り時間や大きさのテキストを書き換える(残り時間はUpdateで大きさは敵に触れるたびに呼び出す)</summary>
    public void AddTextValue(float value, TextType textType)
    {
        switch (textType)
        {
            case TextType.Timer:
                _uiTexts.First(x => x.TextName == "残り時間").ChangeText((int)value);
                break;
            case TextType.Level:
                _uiTexts.First(x => x.TextName == "レベル").ChangeText((int)value);
                break;
        }
    }

    /// <summary>左上のボタンで呼び出す</summary>
    public void PausePanelSetActive()
    {
        if (!_pausePanel.gameObject.activeSelf) _pausePanel.gameObject.SetActive(true);
        else _pausePanel.gameObject.SetActive(false);

    }

    /// <summary>ゲームが終了したら呼び出す</summary>
    public IEnumerator ResultPanelSetActive()
    {
        _uiTexts.First(x => x.TextName == "ゲーム終了").TextSetActive(true);
        _resultTexts.First(x => x.TextName == "スコア").ChangeText(_playerBase.PlayerLevel * 13);
        _resultTexts.First(x => x.TextName == "魚のレベル").ChangeText(_playerBase.PlayerLevel);
        yield return new WaitForSeconds(WAIT_SECONDS);
        _resultPanel.gameObject.SetActive(true);
    }

    [System.Serializable]
    public class UIText
    {
        public string TextName => _textName;
        public Text Text => _text;

        [SerializeField]
        [Header("名前")]
        string _textName;

        [SerializeField]
        [Header("テキスト")]
        Text _text;

        public void ChangeText(int value)
        {
            _text.text = _textName + value.ToString();
        }

        public void TextSetActive(bool activeSelf)
        {
            _text.gameObject.SetActive(activeSelf);
        }
    }

    [System.Serializable]
    public class ResultText
    {
        public string TextName => _textName;
        public Text Text => _text;

        [SerializeField]
        [Header("名前")]
        string _textName;

        [SerializeField]
        [Header("テキスト")]
        Text _text;

        public void ChangeText(int value)
        {
            _text.text = _textName + value.ToString();
        }
    }
}
public enum TextType
{
    Timer,
    Level,
    GameEnd,
}

public enum UIType
{
    PausePanel,
    GameEndText
}

