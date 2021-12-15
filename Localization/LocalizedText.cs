using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof (TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private LocalizationTags _tag;
    private TextMeshProUGUI _text;
    private Localization _language;
    private Action _onEnabled;

    public void Init(Localization language)
    {
        _language = language;
        if (IsActive())
        {
            ChangeText();
        }
        else{
            _onEnabled += ChangeText;
        }
    }
    private bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }
    private void ChangeText()
    {
        _text = GetComponent<TextMeshProUGUI>();
        var text = _language.LanguageDictionary[_tag];
        text = text.Replace("\n", "<br>");
        _text.richText = true;
        _text.SetText(text);
        
    }
    private void OnEnable()
    {
        _onEnabled?.Invoke();
    }
}
