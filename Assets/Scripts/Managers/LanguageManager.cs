using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    public int language;
    public string[] text;

    public Text textLine;

    private void Awake()
    {
        Instance = this;

        language = PlayerPrefs.GetInt("language", language); //Загружаем язык
        textLine = GetComponent<Text>(); //Получаем компонент "Текст"
        textLine.text = "" + text[language]; //Указыавем какой текст будет отображаться
    }
}
