using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using TOR_Core.CharacterDevelopment.CareerSystem.Choices;
namespace Bannerlord.TorSub.NoGreyLordLimit.patches;

[HarmonyPatch]
public class GreyLordCareerChoicesPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(GreyLordCareerChoices), "InitializePassives", null)]
    public static IEnumerable<CodeInstruction> InitializePassivesPatch(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        codes[432] = new CodeInstruction(OpCodes.Ldc_R4, float.MaxValue);
        return codes.AsEnumerable();
    }
    
}