using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity;
using TMPro;
using ClassLibrary1.Notifiers;

namespace ClassLibrary1
{
    public class Core : MelonMod
    {
        public override void OnUpdate()
        {
            string activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == "Scene_Game")
            {

                Build_Teller.StartSpreader();
                Build_Teller.StartCollecter();
                Build_Teller.StartBreaker();

            }
            if (Build_Teller.CanRotate())
            {

                TextMeshPro[] AllText = GameObject.FindObjectsOfType<TextMeshPro>();

                foreach (var b in AllText)
                {
                    Rotater(b);
                }

            }
        }

        public override void OnGUI()
        {
            
            // NO TOUCH **ESP**

            /*foreach(Creature_Animal Animal in GameObject.FindObjectsOfType(typeof(Creature_Animal)) as Creature_Animal[])
            {
                Vector3 pivotPos = Animal.transform.position; //Pivot point NOT at the feet, at the center
                Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f; //At the feet
                Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

                Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                DrawBoxESP(w2s_footpos, w2s_headpos, Color.red);

            }*/

        }
        public void DrawBoxESP(Vector3 footpos, Vector3 headpos, Color color) //Rendering the ESP
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            //ESP BOX
            Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);

            //Snapline
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 2f);
        }

        private static void Rotater(TextMeshPro Textt)
        {
            Vector3 origRot = Textt.transform.eulerAngles;
            Textt.transform.LookAt(PlayerGarden.instance.transform);
            origRot.x = 0f;
            origRot.y = Textt.transform.eulerAngles.y + 180f;
            Textt.transform.eulerAngles = origRot;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }


    /* TODO: 
    RangeCircle = GameObject.Instantiate(new GameObject("SpreaderObject"), Spreader.gameObject.transform);
    RangeCircle.AddComponent<MeshFilter>();
    RangeCircle.AddComponent<BoxCollider>();
    RangeCircle.AddComponent<MeshRenderer>();

    RangeCircle.GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));

    RangeCircle.transform.localScale = new Vector3(Spreader.range, Spreader.range, Spreader.range);
    */

}
