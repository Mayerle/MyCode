using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System;

[CreateAssetMenu(fileName = "localization", menuName = "ScriptableObjects/Localization", order = 2)]
public class Localization : ScriptableObject
{
    public LocalizationDictionary LanguageDictionary;

}


[System.Serializable]
public class LocalizationDictionary : SerializableDictionaryBase<LocalizationTags, string> { }

[System.Serializable]
public class LocalizationsDictionary : SerializableDictionaryBase<SystemLanguage, Localization> { }

[Serializable]
public enum LocalizationTags
{
    popup_pause_heading,
    popup_pause,
    popup_win_heading,
    popup_win,
    popup_lose_heading,
    popup_lose,
    popup_morelife_heading,
    popup_morelife_top,
    popup_morelife_bottom,
    popup_booster_revard_cancel_heading,
    popup_booster_revard_help_heading,
    popup_booster_revard_shuffle_heading,
    popup_booster_reward,
    popup_buffer_reward_heading,
    popup_buffer_reward,
    popup_daily_bonus_heading,
    popup_daily_bonus,
    popup_sorry_heading,
    popup_sorry,
    popop_loading,
    autumn_lvlchoose,
    mountain_lvlchoose,
    start_screen,
    booster_cancel,
    booster_help,
    booster_shuffle,
    button_proceed,
    button_again,
    button_watch,
    tutorial_popup_1,
    tutorial_popup_2,
    tutorial_popup_3,
    tutorial_popup_4,
    tutorial_popup_5,
    tutorial_popup_6,
    tutorial_popup_7,
    tutorial_popup_8,
    tutorial_popup_9,
    tutorial_popup_10,
    tutorial_popup_11,
    tutorial_popup_12,
    autumn_lvlchoose_title,
    mountain_lvlchoose_title
}