using System;
using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;


namespace Bannerlord.TorSub.NoGreyLordLimit
{
    public class SubModule : MBSubModuleBase
    {
        public bool _shouldLoadPatches = true;
        public static Harmony? HarmonyInstance { get; private set; }
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            HarmonyInstance = new Harmony("com.ae.tornogreylordlimit");
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
            if (HarmonyInstance != null)
            {
                HarmonyInstance.UnpatchAll("com.ae.tornogreylordlimit");
                HarmonyInstance = null;
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            InformationManager.DisplayMessage(new InformationMessage("TOR No Grey Lord Limit loaded successfully.", Colors.Green));
            if (_shouldLoadPatches && HarmonyInstance != null)
            {
                try
                {
                    HarmonyInstance.PatchAll();
                    _shouldLoadPatches = false;
                }
                catch (Exception ex)
                {
                    InformationManager.DisplayMessage(new InformationMessage("Patch Application Failed: " + ex.Message + "\n" + ex.StackTrace, Colors.Red));
                }
            }
        }
    }
}