using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class CanvasController : MonoBehaviour
    {
        public void OpenSubMenu(GameObject button)
        {
            for (int i = 0; i < button.transform.childCount; i++)
            {
                button.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        public void CloseSubMenu(GameObject button)
        {
            for (int i = 0; i < button.transform.childCount; i++)
            {
                button.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
