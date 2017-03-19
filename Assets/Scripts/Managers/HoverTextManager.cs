using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTextManager : Singleton<HoverTextManager>
{
    public string DisplayedText;

    public StringUnityEvent OnTextChange = new StringUnityEvent();

    public void DisplayText(string text)
    {
        DisplayedText = text;

        OnTextChange.Invoke(text);
    }

    public void ClearText()
    {
        DisplayedText = "";

        OnTextChange.Invoke("");
    }
}