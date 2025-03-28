using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] private string _localeCode; // "en", "ru", "es" и т.д.

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var locale = LocalizationSettings.AvailableLocales.GetLocale(_localeCode);
            LocalizationSettings.SelectedLocale = locale;
        });
    }
}