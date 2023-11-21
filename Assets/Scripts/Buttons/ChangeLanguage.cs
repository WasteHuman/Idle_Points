using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private GameObject _attentionLanguageChangeDialogBox;

    private int language;

    private void Awake()
    {
        LanguageLoading();
    }
    public void LanguageLoading()
    {
        language = PlayerPrefs.GetInt("language", language); //Загрузка языка
    }

    public void LanguageChange()
    {
        if (language == 1)
        {
            language = 0;
            PlayerPrefs.SetInt("language", language);
            Application.Quit();
        }
        else if (language == 0)
        {
            language = 1;
            PlayerPrefs.SetInt("language", language);
            Application.Quit();
        }
    }
    public void CloseLangChangeDialogBox()
    {
        Destroy(_attentionLanguageChangeDialogBox);
    }
}
