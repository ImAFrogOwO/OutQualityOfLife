using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;



namespace Pickblock
{
    public class Core : MelonMod
    {

        public override void OnUpdate()
        {
            
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                MelonLogger.Msg("Holding...");
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
                RaycastHit hit;
                float distance = 100f;
                if (Physics.Raycast(ray, out hit, distance))
                {
                    MelonLogger.Msg(hit.collider.gameObject.name);
                }

            }
        }

    }
}
