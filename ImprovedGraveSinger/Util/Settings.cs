using Kingmaker.Localization;
using ModMenu.Settings;
using System;
using System.Collections.Generic;

namespace ImprovedGraveSinger.Util
{
    internal class Settings
    {
        private static readonly string RootKey = "dragonfixes";

        public static void InitializeSettings()
        {
            ModMenu.ModMenu.AddSettings(
                SettingsBuilder.New(RootKey, CreateString(GetKey("title"), "Improved Grave Singer"))
                    .SetMod(Main.entry)
                    .AddToggle(
                        Toggle.New(GetKey("viciousenchant"), defaultValue: true, CreateString("viciousenchant-toggle", "Adds the Vicious enchantment to Grave Singer")))
                    .AddSliderInt(
                        SliderInt.New(GetKey("gsbonus"), defaultValue: 10, CreateString("gsbonus-slider", "Set the bonus for Grave Singer"), minValue: 1, maxValue: 20)));
        }
        public static T GetSetting<T>(string key)
        {
            try
            {
                return ModMenu.ModMenu.GetSettingValue<T>(GetKey(key));
            }
            catch (Exception ex)
            {
                Main.logger.Error(ex.ToString());
                return default(T);
            }
        }
        private static LocalizedString CreateString(string partialkey, string text)
        {
            return Helpers.CreateString(GetKey(partialkey), text);
        }
        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }

    }
    public static class Helpers
    {
        private static Dictionary<string, LocalizedString> textToLocalizedString = new Dictionary<string, LocalizedString>();
        public static LocalizedString CreateString(string key, string value)
        {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            if (textToLocalizedString.TryGetValue(value, out LocalizedString localized))
            {
                return localized;
            }
            var strings = LocalizationManager.CurrentPack?.m_Strings;
            if (strings!.TryGetValue(key, out var oldValue) && value != oldValue.Text)
            {
                Main.logger.Info($"Info: duplicate localized string `{key}`, different text.");
            }
            var sE = new Kingmaker.Localization.LocalizationPack.StringEntry();
            sE.Text = value;
            strings[key] = sE;
            localized = new LocalizedString
            {
                m_Key = key
            };
            textToLocalizedString[value] = localized;
            return localized;
        }
    }
}


