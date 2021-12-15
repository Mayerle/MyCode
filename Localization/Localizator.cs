using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Localizator : MonoBehaviour
{
    public LocalizationsDictionary _dictionary;
    [SerializeField] private WinPresenter _presenter;
    private LocalizedText[] _textFields;
    [SerializeField] private LevelChoisePresenter _choise;
    public void Init()
    {


        var language = FindLanguage(Application.systemLanguage);
        _textFields = FindFields();
        foreach (var text in _textFields)
        {
            text.Init(language);
        }
        if(_presenter!=null)
        _presenter.Init(language.LanguageDictionary);
        _choise.Init(language.LanguageDictionary);
    }
    private void Start()
    {
        Init ();
    }
    private Localization FindLanguage(SystemLanguage language)
    {
        var dictionary = _dictionary.Where(x => x.Key == language).FirstOrDefault();
        if (dictionary.Value.IsNull())
            return FindLanguage(SystemLanguage.English);
        else
            return dictionary.Value;
    }
    private LocalizedText[] FindFields()
    {
        return (LocalizedText[])GameObject.FindObjectsOfTypeAll(typeof(LocalizedText));
    }
}
