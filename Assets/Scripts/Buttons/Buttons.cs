using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : Sounds
{
    [Header("Анимации магазинов Улучшений и Бонусов")]
    [SerializeField] private GameObject _shopPanelAnimation;
    [SerializeField] private GameObject _bonusesPanelAnimation;
    [SerializeField] private bool _shopOpened;
    [SerializeField] private bool _bonusesOpened;

    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;

    [Header("Панели магазинов Улучшений и Бонусов")]
    [SerializeField] private GameObject _shopPan;
    [SerializeField] private GameObject _bonusPan;

    [Header("Кнопки настроек")]
    [SerializeField] private GameObject _settingsPan;
    [SerializeField] private GameObject _soundsBttn;
    [SerializeField] private GameObject _languageChange;
    [SerializeField] private GameObject _vkBttn;

    [Header("Спрайты EN/RU")]
    [SerializeField] private Sprite _languageEN;
    [SerializeField] private Sprite _languageRU;

    [Header("Диалоговое окно смены языка")]
    [SerializeField] private GameObject _attentionLanguageChangeDialogBox;
    [SerializeField] private GameObject _attentionLanguageChangeDialogBoxPrefab;

    [SerializeField] private int language;

    public void InitLanguageFlag()
    {
        language = PlayerPrefs.GetInt("language", language);

        if (language != 0)
        {
            _languageChange.GetComponent<Image>().sprite = _languageEN;
        }
        else if (language != 1)
        {
            _languageChange.GetComponent<Image>().sprite = _languageRU;
        }
    }

    public void OpenAndCloseShop()
    {
        if (!_shopOpened)
        {
            _shopOpened = true;
            _bonusPan.SetActive(false);
            _settingsPan.SetActive(false);
            _shopPan.SetActive(true);
            if (!_shopPanelAnimation.GetComponent<Animator>().enabled)
            {
                _shopPanelAnimation.GetComponent<Animator>().enabled = true;
            }
            else
            {
                _shopPanelAnimation.GetComponent<Animator>().SetTrigger("Enter");
            }
        }
        else if(_shopOpened)
        {
            _shopPanelAnimation.GetComponent<Animator>().SetTrigger("Out");
            _settingsPan.SetActive(true);
            _shopOpened = false;
        }

        PlaySound(sounds[0]);
    }

    public void OpenAndCloseBonusShop()
    {
        if (!_bonusesOpened)
        {
            _bonusesOpened = true;
            _shopPan.SetActive(false);
            _settingsPan.SetActive(false);
            _bonusPan.SetActive(true);
            if (!_bonusesPanelAnimation.GetComponent<Animator>().enabled)
            {
                _bonusesPanelAnimation.GetComponent<Animator>().enabled = true;
            }
            else
            {
                _bonusesPanelAnimation.GetComponent<Animator>().SetTrigger("Enter");
            }
        }
        else if (_bonusesOpened)
        {
            _bonusesPanelAnimation.GetComponent<Animator>().SetTrigger("Out");
            _settingsPan.SetActive(true);
            _bonusesOpened = false;
        }

        PlaySound(sounds[0]);
    }

    public void OpenAndCloseSettings()
    {
        _soundsBttn.SetActive(!_soundsBttn.activeSelf);
        _languageChange.SetActive(!_languageChange.activeSelf);
        _vkBttn.SetActive(!_vkBttn.activeSelf);
        PlaySound(sounds[0]);
    }

    public void LangChangeDialogBox()
    {
        _attentionLanguageChangeDialogBox = Instantiate(_attentionLanguageChangeDialogBoxPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        _attentionLanguageChangeDialogBox.transform.SetParent(_canvas.transform, false);

        if (_attentionLanguageChangeDialogBox.activeSelf)
        {
            _soundsBttn.SetActive(false);
            _languageChange.SetActive(false);
            _vkBttn.SetActive(false);
        }
    }
}
