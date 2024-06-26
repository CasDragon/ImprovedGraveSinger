using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UI.MVVM._VM.Crusade.Recruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace ImprovedGraveSinger
{
#if DEBUG
    [EnableReloading]
#endif
    public static class Main
    {
        internal static Harmony HarmonyInstance;
        public static readonly LogWrapper logger = LogWrapper.Get("improvedgravesinger");

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
#if DEBUG
            modEntry.OnUnload = OnUnload;
#endif
            modEntry.OnGUI = OnGUI;
            HarmonyInstance = new Harmony(modEntry.Info.Id);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            return true;
        }

        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {

        }

#if DEBUG
        public static bool OnUnload(UnityModManager.ModEntry modEntry) {
            HarmonyInstance.UnpatchAll(modEntry.Info.Id);
            return true;
        }
#endif
    }
    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Postfix()
        {
            try
            {
                if (Initialized)
                {
                    Main.logger.Info("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                Main.logger.Info("Patching Grave Singer enchantment.");
                Weapon.Configure();
            }
            catch (Exception e)
            {
                Main.logger.Error("Failed to initialize." + e);
            }
        }
    }
}
