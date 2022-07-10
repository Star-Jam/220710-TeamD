using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField]
    [Header("UI�̃e�L�X�g")]
    List<UIText> _uiTexts = new();

    [SerializeField]
    [Header("�|�[�Y��ʂ̃p�l��")]
    Image _pausePanel;

    [SerializeField]
    [Header("���U���g��ʂ̃p�l��")]
    Image _resultPanel;

    [SerializeField]
    [Header("���U���g��ʂ̃e�L�X�g")]
    List<ResultText> _resultTexts = new();

    const float WAIT_SECONDS = 3;

    private void Start()
    {
        AddTextValue(0, TextType.Timer);
        AddTextValue(0, TextType.Size);
    }

    /// <summary>�c�莞�Ԃ�傫���̃e�L�X�g������������(�c�莞�Ԃ�Update�ő傫���͓G�ɐG��邽�тɌĂяo��)</summary>
    public void AddTextValue(int value, TextType textType)
    {
        switch (textType)
        {
            case TextType.Timer:
                _uiTexts.First(x => x.TextName == "�c�莞��").ChangeText(value);
                break;
            case TextType.Size:
                _uiTexts.First(x => x.TextName == "���x��").ChangeText(value);
                break;
        }
    }

    /// <summary>����̃{�^���ŌĂяo��</summary>
    public void PausePanelSetActive()
    {
        if (!_pausePanel.gameObject.activeSelf) _pausePanel.gameObject.SetActive(true);
        else _pausePanel.gameObject.SetActive(false);

    }

    /// <summary>�Q�[�����I��������Ăяo��</summary>
    public IEnumerator ResultPanelSetActive()
    {
        _uiTexts.First(x => x.TextName == "�Q�[���I��").TextSetActive(true);
        //_resultTexts.First(x => x.TextName == "�X�R�A").ChangeText(Score);
        //_resultTexts.First(x => x.TextName == "���̃��x��").ChangeText(PlayerLevel);
        yield return new WaitForSeconds(WAIT_SECONDS);
        _resultPanel.gameObject.SetActive(true);
    }

    [System.Serializable]
    public class UIText
    {
        public string TextName => _textName;
        public Text Text => _text;

        [SerializeField]
        [Header("���O")]
        string _textName;

        [SerializeField]
        [Header("�e�L�X�g")]
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
        [Header("���O")]
        string _textName;

        [SerializeField]
        [Header("�e�L�X�g")]
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
    Size,
    GameEnd,
}

public enum UIType
{
    PausePanel,
    GameEndText
}

