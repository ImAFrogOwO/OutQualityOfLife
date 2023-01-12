using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using TMPro;
using UnityEngine;

namespace ClassLibrary1.Notifiers
{
    public class Build_Teller
    {

        private static Build_Spreader[] Speaders;
        private static Build_Collector[] Collectors;
        private static Build_Breaker[] Breakers;

        public static bool CanRotate()
        {
            return true;
        }

        public static void StartSpreader()
        {
            Speaders = GameObject.FindObjectsOfType<Build_Spreader>();

            foreach (var Spreader in Speaders)
            {


                if (Spreader.gameObject.GetComponentInChildren<TextMeshPro>())
                {
                    continue;
                }
                else
                {

                    if (Spreader.GetComponentInChildren<SpriteRenderer>() == false)
                    {

                        Rigidbody a = Spreader.gameObject.GetComponentInChildren<Rigidbody>(true);
                        TextMeshPro bb = a.gameObject.AddComponent<TextMeshPro>();

                        bb.text = "Range: " + Spreader.range.ToString() + "\nTime " + Spreader.timeToPlant.ToString();
                        bb.alignment = TextAlignmentOptions.Center;
                        bb.isOverlay = true;
                        bb.fontSize = 3;
                        bb.outlineColor = new Color32(255, 128, 0, 255);
                        bb.transform.position += new Vector3(0, 2, 0);

                    }
                    CanRotate();
                }

            }
        }

        public static void StartCollecter()
        {
            Collectors = GameObject.FindObjectsOfType<Build_Collector>();

            foreach (var Spreader in Collectors)
            {


                if (Spreader.gameObject.GetComponentInChildren<TextMeshPro>())
                {
                    continue;


                }
                else
                {

                    TextMeshPro bb = null;


                    if (Spreader.GetComponentInChildren<SpriteRenderer>() == false)
                    {
                        Rigidbody a = Spreader.gameObject.GetComponentInChildren<Rigidbody>();
                        bb = a.gameObject.AddComponent<TextMeshPro>();
                        bb.text = "Range: " + Spreader.radius.ToString() + "\nTime " + Spreader.timeToCollect.ToString();
                        bb.alignment = TextAlignmentOptions.Center;
                        bb.isOverlay = true;
                        bb.fontSize = 3;
                        bb.transform.position += new Vector3(0, 2, 0);
                    }
                    CanRotate();
                }

            }
        }

        public static void StartBreaker()
        {
            Breakers = GameObject.FindObjectsOfType<Build_Breaker>();

            foreach (var Spreader in Breakers)
            {


                if (Spreader.gameObject.GetComponentInChildren<TextMeshPro>())
                {

                    continue;

                }
                else
                {

                    TextMeshPro bb = null;


                    if (bb == null && Spreader.GetComponentInChildren<SpriteRenderer>() == false)
                    {
                        Rigidbody a = Spreader.gameObject.GetComponentInChildren<Rigidbody>();
                        bb = a.gameObject.AddComponent<TextMeshPro>();
                        bb.text = "Range: " + Spreader.radius.ToString() + "\nTime: " + Spreader.timeToBreak.ToString() + "\nDamage: " + Spreader.minDamage.ToString();
                        bb.alignment = TextAlignmentOptions.Center;
                        bb.isOverlay = true;
                        bb.fontSize = 3;
                        bb.transform.position += new Vector3(0, 2, 0);
                    }
                    CanRotate();
                }

            }
        }

    }
}
