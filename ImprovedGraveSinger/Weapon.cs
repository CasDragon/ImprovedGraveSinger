using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedGraveSinger
{
    internal class Weapon
    {
        public static void Configure()
        {
            ItemWeaponConfigurator.For(ItemWeaponRefs.RovagugRelicSteppeHandaxeItem.Reference.Get())
                .AddToEnchantments(WeaponEnchantmentRefs.ViciousEnchantment.Reference.Get())
                .Configure();
            ItemWeaponConfigurator.For(ItemWeaponRefs.RovagugRelicSteppeGreataxeItem.Reference.Get())
                .AddToEnchantments(WeaponEnchantmentRefs.ViciousEnchantment.Reference.Get())
                .Configure();
            ItemWeaponConfigurator.For(ItemWeaponRefs.RovagugRelicSteppeBattlaxeItem.Reference.Get())
                .AddToEnchantments(WeaponEnchantmentRefs.ViciousEnchantment.Reference.Get())
                .Configure();
            WeaponEnchantmentRefs.RovagugRelicSteppeEnchantment.Reference.Get().GetComponent<WeaponCriticalEdgeStackable>().Bonus = 10;
        }
    }
}
