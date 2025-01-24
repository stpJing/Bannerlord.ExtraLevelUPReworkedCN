using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using TOR_Core.Models;

namespace Bannerlord.TorSub.NoGreyLordLimit.patches;

[HarmonyPatch]
public class TORAbilityModelPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(TORAbilityModel), nameof(TORAbilityModel.GetPerkEffectsOnAbilityDuration))]
    public static IEnumerable<CodeInstruction> GetPerkEffectsOnAbilityDurationPatch(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var continulabel1 = generator.DefineLabel();
        var continulabel2 = generator.DefineLabel();
        var continulabel3 = generator.DefineLabel();
        var code = instructions.ToList();
        code[55].labels.Add(continulabel1);
        code[54] = new CodeInstruction(OpCodes.Brtrue_S, continulabel1);
        code[81].labels.Add(continulabel2);
        code[80] = new CodeInstruction(OpCodes.Brfalse_S, continulabel2);
        code[111].labels.Add(continulabel3);
        code[110] = new CodeInstruction(OpCodes.Brfalse_S, continulabel3);
        return code.AsEnumerable();
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(TORAbilityModel), nameof(TORAbilityModel.CalculateRadiusForAbility))]
    public static IEnumerable<CodeInstruction> GetCalculateRadiusForAbilityPatch(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var continuelabel = generator.DefineLabel();
        var code = instructions.ToList();
        code[34].labels.Add(continuelabel);
        code[33] = new CodeInstruction(OpCodes.Brfalse_S, continuelabel);
        return code.AsEnumerable();
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(TORAbilityModel), nameof(TORAbilityModel.GetSkillEffectivenessForAbilityDamage))]
    public static IEnumerable<CodeInstruction> GetSkillEffectivenessForAbilityDamagePatch(
        IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var continuelabel = generator.DefineLabel();
        var code = instructions.ToList();
        code[55].labels.Add(continuelabel);
        code[54] = new CodeInstruction(OpCodes.Brfalse_S, continuelabel);
        return code.AsEnumerable();
    }
    
}