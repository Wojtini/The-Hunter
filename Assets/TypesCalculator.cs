public static class TypesCalculator
{
    public static float getModifier(DamageTypes damageType, ArmorTypes armorType)
    {
        switch (damageType)
        {
            case DamageTypes.AP:
                switch (armorType)
                {
                    case ArmorTypes.NoArmor:
                        return 0.75f;
                    case ArmorTypes.Kevlar:
                        return 1.0f;
                    case ArmorTypes.Psionic:
                        return 1.0f;
                    case ArmorTypes.Shield:
                        return 0.75f;
                    case ArmorTypes.GodArmor:
                        return 0.0f;
                }
                break;
            case DamageTypes.HE:
                switch (armorType)
                {
                    case ArmorTypes.NoArmor:
                        return 1.25f;
                    case ArmorTypes.Kevlar:
                        return 0.75f;
                    case ArmorTypes.Psionic:
                        return 1.0f;
                    case ArmorTypes.Shield:
                        return 0.50f;
                    case ArmorTypes.GodArmor:
                        return 0.0f;
                }
                break;
            case DamageTypes.Energetic:
                switch (armorType)
                {
                    case ArmorTypes.NoArmor:
                        return 0.75f;
                    case ArmorTypes.Kevlar:
                        return 0.5f;
                    case ArmorTypes.Psionic:
                        return 1.0f;
                    case ArmorTypes.Shield:
                        return 1.25f;
                    case ArmorTypes.GodArmor:
                        return 0.0f;
                }
                break;
            case DamageTypes.Psionic:
                switch (armorType)
                {
                    case ArmorTypes.NoArmor:
                        return 1.0f;
                    case ArmorTypes.Kevlar:
                        return 1.0f;
                    case ArmorTypes.Psionic:
                        return 1.0f;
                    case ArmorTypes.Shield:
                        return 1.0f;
                    case ArmorTypes.GodArmor:
                        return 0.0f;
                }
                break;
        }
        return 100.0f;
    }
}
