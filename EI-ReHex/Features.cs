using System.Windows.Forms;

namespace EIReHex
{
    public partial class MainForm : Form
    {
        private static class Feature
        {
            public const string GameSpeedVillage = "GameSpeedVillage";
            public const string GameSpeedVillageDialog1 = "GameSpeedVillageDialog1";
            public const string GameSpeedVillageDialog2 = "GameSpeedVillageDialog2";
            public const string GameSpeedVillageDialog3 = "GameSpeedVillageDialog3";
            public const string GameSpeedNormalHK = "GameSpeedNormalHK";
            public const string GameSpeedNormalUI = "GameSpeedNormalUI";
            public const string GameSpeedFastHK = "GameSpeedFastHK";
            public const string GameSpeedFastUI = "GameSpeedFastUI";
            public const string GameSpeedRestore = "GameSpeedRestore";

            public const string RunAmountDouble = "RunAmountDouble";
            public const string RunAmountRedirectBattle = "RunAmountInjectionBattle";
            public const string RunAmountRedirectMana = "RunAmountInjectionMana";
            public const string RunAmountLogicBattleOrMana = "RunAmountLogicBattle";
            public const string RunAmountLogicBattleAndMana = "RunAmountLogicBattleMana";

            public const string SpellConstructor1 = "SpellConstructor1";
            public const string SpellConstructor2 = "SpellConstructor2";
            public const string SpellConstructor3 = "SpellConstructor3";
            public const string PartyExp = "PartyExp";
            public const string SecondarySkillsCost1 = "SecondarySkillsCost1";
            public const string SecondarySkillsCost2 = "SecondarySkillsCost2";
        }

        private Replacement[] Replacements = new Replacement[] {
            new Replacement(Feature.RunAmountDouble,
                "70 72 55 00 4E 1B E8 B4 81 4E 7B 3F 00 00 70 42",
                "70 72 55 00 11 EF E6 B4 81 4E 6B 3F 00 00 70 42"),
            new Replacement(Feature.RunAmountRedirectBattle,
                "00 6A 06 EB 75 D9 47 14 D9 47 18 DC 0D 88 F0 73 00 DE E9 D9 57 14 D8 1D 58 B8 73 00 DF E0 F6 C4",
                "00 6A 06 EB 75 D9 47 14 D9 47 18 E9 60 23 1F 00 90 DE E9 D9 57 14 D8 1D 58 B8 73 00 DF E0 F6 C4"),
            new Replacement(Feature.RunAmountRedirectMana,
                "00 6A 06 EB 75 D9 47 14 D9 47 18 DC 0D 88 F0 73 00 DE E9 D9 57 14 D8 1D 58 B8 73 00 DF E0 F6 C4",
                "00 6A 06 EB 75 D9 47 14 D9 47 18 E9 8C 23 1F 00 90 DE E9 D9 57 14 D8 1D 58 B8 73 00 DF E0 F6 C4"),
            new Replacement(Feature.RunAmountLogicBattleOrMana,
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00",
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 8B 15 60 F7 7A 00 83 7A 40 01 74 10 D8 0D DC 12 79 00 BA 00 00 00 00 E9 85 DC E0 FF DC 0D 88 F0 73 00 BA 00 00 00 00 E9 75 DC E0 FF 8B 57 18 DD D8 C7 47 18 7B 14 6E 3F D9 47 18 89 57 18 BA 00 00 00 00 E9 59 DC E0 FF"),
            new Replacement(Feature.RunAmountLogicBattleAndMana,
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00",
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 8B 15 60 F7 7A 00 83 7A 40 01 74 10 D8 0D DC 12 79 00 BA 00 00 00 00 E9 85 DC E0 FF 90 90 90 90 90 90 BA 00 00 00 00 E9 75 DC E0 FF 8B 57 18 DD D8 C7 47 18 7B 14 6E 3F D9 47 18 89 57 18 BA 00 00 00 00 EB BB 00 00 00"),


            new Replacement(Feature.SpellConstructor1,
                "8B CE FF 92 B4 00 00 00 D9 47 18 E8 FC 81 0D 00 39 45 08 0F 8C AA 05 00 00 8B 4D 0C 8B 47 44 3B C8 5F 5E 5B 0F 9D C0 8B E5 5D C2 08 00 57 8B CE",
                "8B CE FF 92 B4 00 00 00 D9 47 18 E8 FC 81 0D 00 39 C0 90 0F 85 AA 05 00 00 8B 4D 0C 8B 47 44 39 C9 5F 5E 5B 0F 94 C0 8B E5 5D C2 08 00 57 8B CE"),
            new Replacement(Feature.SpellConstructor2,
                "FF 92 B4 00 00 00 39 7D 08 0F 8C 7C 03 00 00 D9 45 FC E8 BD 7F 0D 00 8B 4D 0C 5F 3B C8 5E 0F 9D C0 5B 8B E5 5D C2 08 00 8B 45 0C 83 F8 01 74 19",
                "FF 92 B4 00 00 00 39 FF 90 0F 85 7C 03 00 00 D9 45 FC E8 BD 7F 0D 00 8B 4D 0C 5F 39 C9 5E 0F 94 C0 5B 8B E5 5D C2 08 00 8B 45 0C 83 F8 01 74 19"),
            new Replacement(Feature.SpellConstructor3,
                "D9 43 40 E8 62 60 0D 00 39 44 24 24 7D 0A 5F 5E 5D 32 C0 5B 83 C4 40 C3 8B 54 24 28 8B 43 50 5F 3B D0 5E 5D 0F 9D C0 5B 83 C4 40 C3 90 90 53 55",
                "D9 43 40 E8 62 60 0D 00 39 C0 90 90 74 0A 5F 5E 5D 32 C0 5B 83 C4 40 C3 8B 54 24 28 8B 43 50 5F 39 D2 5E 5D 0F 94 C0 5B 83 C4 40 C3 90 90 53 55"),
            new Replacement(Feature.PartyExp,
                "00 DB 45 E8 33 F6 3B C7 89 75 EC D8 7D 0C D9 5D 0C 7E 72 EB 02 33 FF 8B 45 C0 8B 0C B0 51 8B 4D",
                "00 DB 45 E8 33 F6 3B C7 89 75 EC 90 90 90 90 90 90 7E 72 EB 02 33 FF 8B 45 C0 8B 0C B0 51 8B 4D"),
            new Replacement(Feature.SecondarySkillsCost1,
                "F7 06 00 00 32 C9 3B C2 88 4C 24 10 74 0D 8A 18 02 CB 40 3B C2 75 F7 88 4C 24 10 8B 44 24 10 D9",
                "F7 06 00 00 32 C9 3B C2 88 4C 24 10 74 0D E9 45 25 21 00 90 90 90 90 88 4C 24 10 8B 44 24 10 D9"),
            new Replacement(Feature.SecondarySkillsCost2,
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF",
                "50 8B 85 C4 00 00 00 83 F8 03 58 75 09 02 4D 58 2A 8D C8 00 00 00 8A 18 02 CB 40 3B C2 75 F7 E9 9B DA DE FF", 120),

            new Replacement(Feature.GameSpeedVillage,
                "4C 24 08 5E 64 89 0D 00 00 00 00 83 C4 10 C3 90 56 8B F1 8B 0D B0 B2 79 00 6A 00 83 C9 40 C7 05 34 FF 78 00 XX 00 00 00 89 0D B0 B2 79 00 B9 D8", null),
            new Replacement(Feature.GameSpeedVillageDialog1,
                "01 00 00 02 00 00 00 89 81 58 01 00 00 89 81 50 01 00 00 8B 15 E4 40 74 00 89 91 50 01 00 00 89 81 5C 01 00 00 C3 90 90 90 90 90 90 90 90 90 90 90 8B 91 98 08 00 00 33 C0 3B D0 74 28 C7 81 54 01 00 00 01 00 00 00 89 81 58 01 00 00 89 81 50",
                "01 00 00 02 00 00 00 E9 31 F7 07 00 90 89 81 50 01 00 00 8B 15 E4 40 74 00 89 91 50 01 00 00 89 81 5C 01 00 00 C3 90 90 90 90 90 90 90 90 90 90 90 8B 91 98 08 00 00 33 C0 3B D0 74 28 C7 81 54 01 00 00 01 00 00 00 E9 06 F7 07 00 90 89 81 50"),
            new Replacement(Feature.GameSpeedVillageDialog2, // do not check with IsFeatureActive()
                "E0 01 85 C0 0F 84 0B 00 00 00 8B 4D EC 83 C1 08 E9 77 28 FC FF C3 B8 38 FC 77 00 E9 1C CE FA FF",
                "89 81 58 01 00 00 C7 05 34 FF 78 00 37 00 00 00 E9 BB 08 F8 FF 89 81 58 01 00 00 C7 05 34 FF 78 00 XX 00 00 00 E9 E6 08 F8 FF", 156),
            new Replacement(Feature.GameSpeedVillageDialog3, // do not check with IsFeatureApplicable()
                "89 81 58 01 00 00 C7 05 34 FF 78 00 37 00 00 00 E9 BB 08 F8 FF 89 81 58 01 00 00 C7 05 34 FF 78 00 XX 00 00 00 E9 E6 08 F8 FF", null),
            new Replacement(Feature.GameSpeedNormalHK,
                "8B 8E 98 00 00 00 55 68 7C 44 79 00 E8 0F D7 FB FF 89 AE 54 01 00 00 C7 05 34 FF 78 00 XX 00 00 00 8B 96 98 00 00 00 8B 86 54 01 00 00 89 82 94", null),
            new Replacement(Feature.GameSpeedNormalUI,
                "74 0C 6A 00 B9 A4 FE 7A 00 E8 12 FF F2 FF C7 86 C0 00 00 00 00 00 00 00 C7 05 34 FF 78 00 XX 00 00 00 8B 46 04 8B 8E C0 00 00 00 6A 00 68 7C 44", null),
            new Replacement(Feature.GameSpeedFastHK,
                "55 68 7C 44 79 00 E8 75 D7 FB FF C7 86 54 01 00 00 01 00 00 00 C7 05 34 FF 78 00 XX 00 00 00 8B 86 98 00 00 00 8B 8E 54 01 00 00 89 88 94 00 00", null),
            new Replacement(Feature.GameSpeedFastUI,
                "FF C7 86 C0 00 00 00 01 00 00 00 C7 05 34 FF 78 00 XX 00 00 00 8B 56 04 8B 86 C0 00 00 00 6A 00 68 7C 44 79 00 89 82 94 00 00 00 8B 4E 04 E8 AD", null),
            new Replacement(Feature.GameSpeedRestore,
                "FB FF 8B 44 24 1C 33 C9  89 86 54 01 00 00 89 8E 4C 01 00 00 F7 D8 1B C0 5F 24 XX 83 C0 XX A3 34 FF 78 00 8B 86 98 00 00 00 8B 96 54 01 00 00 89", null),
        };
    }
}
