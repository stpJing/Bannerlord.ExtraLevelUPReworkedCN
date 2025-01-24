using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TOR_Core.AbilitySystem;
namespace Bannerlord.TorSub.NoGreyLordLimit.patches;

[HarmonyPatch]
public class AbilityPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(Ability), nameof(Ability.ActivateAbility))]
    public static IEnumerable<CodeInstruction> ActivateAbilityPatch(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var codes = new List<CodeInstruction>(instructions);
        Label continueLabel = generator.DefineLabel();
        codes[63].labels.Add(continueLabel);
        codes[62] = new CodeInstruction(OpCodes.Bge_Un_S, continueLabel);
        return codes.AsEnumerable();

    }
    
    
}