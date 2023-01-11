using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace F4Save
{
    public class Core : MelonMod
    {

        public override void OnApplicationQuit()
        {
            PlayerGardenInventory.instance.ReturnBuildItemsToPlayer();
            UpgradesData.instance.AddPointsToGlobal();
            SaveDataGarden.instance.SaveData();

            MelonLogger.Msg("Saved?");

        }

    }
}
