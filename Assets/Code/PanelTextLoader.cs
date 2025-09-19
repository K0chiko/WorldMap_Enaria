using UnityEngine;
using TMPro;

public class PanelTextLoader : MonoBehaviour
{
    public TMP_Text textField;

    public void LoadText(string buttonId)
    {
        // ��������� �������� JSON
        TextAsset jsonFile = Resources.Load<TextAsset>("buttons");
        if (jsonFile == null)
        {
            Debug.LogError("���� buttons.json �� ������ � Resources!");
            return;
        }

        ButtonCollection data = JsonUtility.FromJson<ButtonCollection>(jsonFile.text);

        if (data == null || data.buttons == null)
        {
            Debug.LogError("JSON �� �����������!");
            return;
        }

        // ���� �� id
        foreach (var btn in data.buttons)
        {
            if (btn.id == buttonId)
            {
                // ��������� ���� � ������� ��� ���� ������
                TextAsset textJson = Resources.Load<TextAsset>(btn.file);
                if (textJson == null)
                {
                    Debug.LogError($"���� {btn.file}.json �� ������!");
                    textField.text = "����� �� ������!";
                    return;
                }

                TextData textData = JsonUtility.FromJson<TextData>(textJson.text);
                textField.text = textData.text;
                return;
            }
        }

        textField.text = "����� �� ������!";
    }

}
