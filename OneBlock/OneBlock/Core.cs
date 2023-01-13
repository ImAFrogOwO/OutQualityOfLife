using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(Hardcore.Core),"OneBlock","0.0.1","RSM")]

namespace Hardcore
{
    public class Core : MelonMod
    {
        Button[] PlayButton;
        TextMeshProUGUI Text;
        private static bool StartedGame = true;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Scene_MainMenu")
            {

                if (StartedGame)
                {
                    MelonLogger.Msg("Game was started. Not dying");
                    StartedGame = false;
                }
                else
                {
                    MelonLogger.Msg("Bro died");

                    PlayButton = GameObject.FindObjectsOfType<Button>();

                    foreach (Button button in PlayButton)
                    {

                        Melon<Core>.Logger.Msg(button.name);

                        if (button.name.Contains("Play"))
                        {

                            Task.Run(
                                 () => {

                                    MelonLogger.Msg("Waiting...");

                                    MelonLogger.Msg("Found");

                                    Text = button.GetComponentInChildren<TextMeshProUGUI>();

                                    if (Text)
                                    {
                                         System.Threading.Thread.Sleep(2000);

                                        Text.color = Color.red;
                                        Text.SetText("YOU DIED.. SAVE HAS BEEN DELETED",true);

                                        System.Threading.Thread.Sleep(5000);

                                        Text.SetText("Play",true);
                                        Text.color = Color.white;

                                     }

                                });

                        }

                    }
                }

            }
        }

        public override void OnApplicationStart()
        {

            var Pre2 = typeof(Core).GetMethod(nameof(Core.EnableHardcore), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var Or2 = typeof(PlayerGarden).GetMethod(nameof(PlayerGarden.instance.GetDrown), AccessTools.all);

            HarmonyInstance.Patch(Or2,new HarmonyMethod(Pre2));

        }

        private static bool EnableHardcore()
        {

            SceneManager.LoadScene("Scene_MainMenu");

            ES3.DeleteFile("SaveFile1.es3");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            return false;
        }

    }
}
