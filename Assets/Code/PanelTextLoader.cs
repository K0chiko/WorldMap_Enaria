using UnityEngine;
using TMPro;

public class PanelTextLoader : MonoBehaviour
{
    public TMP_Text textField;

    public void LoadText(string buttonId)
    {
        // Загружаем основной JSON
        TextAsset jsonFile = Resources.Load<TextAsset>("buttons");
        if (jsonFile == null)
        {
            Debug.LogError("Файл buttons.json не найден в Resources!");
            return;
        }

        ButtonCollection data = JsonUtility.FromJson<ButtonCollection>(jsonFile.text);

        if (data == null || data.buttons == null)
        {
            Debug.LogError("JSON не распарсился!");
            return;
        }

        // Ищем по id
        foreach (var btn in data.buttons)
        {
            if (btn.id == buttonId)
            {
                // Загружаем файл с текстом для этой кнопки
                TextAsset textJson = Resources.Load<TextAsset>(btn.file);
                if (textJson == null)
                {
                    Debug.LogError($"Файл {btn.file}.json не найден!");
                    textField.text = "Текст не найден!";
                    return;
                }

                TextData textData = JsonUtility.FromJson<TextData>(textJson.text);
                textField.text = textData.text;
                return;
            }
        }

        textField.text = "Текст не найден!";
    }

}
