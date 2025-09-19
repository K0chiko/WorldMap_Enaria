using System;

[Serializable]
public class ButtonData
{
    public string id;    
    public string title;
    public string file;
}

[Serializable]
public class ButtonCollection
{
    public ButtonData[] buttons;
}

[Serializable]
public class TextData
{
    public string text;
}
