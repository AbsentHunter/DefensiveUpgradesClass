using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclopsDefensiveUpgradesCore.Fabricator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SMLHelper.V2.Assets;
    using SMLHelper.V2.Handlers;
    using SMLHelper.V2.Utility;
    using SMLHelper.V2.Crafting;
    using UnityEngine;

    // We're not going to modify the Seamoth Electrical Defense Upgrade so much as create a successor or upgrade to it. We're also making a defensive upgrade core in case we add more upgrades or different ones.
    internal abstract class CyclopsDefensiveUpgradesCore : Craftable
    {
        // Set up all the names and paths and stuff
        private const string craftTab = "";
        private const string Assets = @"CyclopsDefensiveUpgrades/Assets";
        private static readonly string[] craftPath = new[] { craftTab };

        // Setting up class-level stuff
        public static TechType get;
        private readonly EquipmentType cyclopsUpgrade;

        protected Set

        Set; static void PatchIt()
        {
            // Nothing for Defensive Upgrades at the moment. May update at later date
            var tabIcon = ImageUtils.LoadSpriteFromFile(@"./Qmods/" + Assets + @"/TabIcon.png");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, craftTab, "Cyclops Defensive Upgrades", tabIcon);
            UnityEngine.Debug.Log("[] Crafting tab Cyclops Defensive Upgrades created.");
            var = CyclopsDefensiveUpgrades();
        }

        private static void CyclopsDefensiveUpgrades()
        {
            throw new NotImplementedException();
        }

        protected abstract TechType BaseType { get; }
        protected abstract EquipmentType CyclopsUpgrade { get; }

        // Let's get to the good stuff
        protected CyclopsDefensiveUpgradesCore(string classID, string friendlyName, string description) : base(classID, friendlyName, description)
        {
            // Invoke when done
            OnFinishedPatching += SetEquipmentType;
        }

        // This will be built at a workbench.
        public override CraftTree.Type FabricatorType { get; } = CraftTree.Type.Workbench;

        private readonly TechGroup groupForCyclops = TechGroup.Workbench;

        public TechGroup GetGroupForCyclops()
        {
            return groupForCyclops;
        }

        private readonly TechCategory categoryForCyclops = TechCategory.Workbench;

        public TechCategory GetCategoryForCyclops()
        {
            return categoryForCyclops;
        }

        public override string AssetsFolder { get; } = Assets;
        public override string[] StepsToFabricatorTab { get; } = craftPath;
        public override TechType RequiredForUnlock { get; } = TechType.SeamothElectricalDefense; // This will require the Seamoth's Perimeter Defense to unlock

        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(this.BaseType);

            CyclopsUpgradeConsoleHUDManager cyclopsUpgradeConsole = UnityEngine.Object.Instantiate(original: prefab).GetComponent<SeamothElectricalDefense>();

            return UnityEngine.Object.Instantiate(prefab);
        }

        private void SetEquipmentType()
        {
            // Make sure it is usable in one of the upgrade slots for the Cyclops
            CraftDataHandler.SetEquipmentType(this.TechType, this.cyclopsUpgrade);
        }
    }

    internal class SeamothElectricalDefense
    {
    }

    internal class Set
    {
    }
}
