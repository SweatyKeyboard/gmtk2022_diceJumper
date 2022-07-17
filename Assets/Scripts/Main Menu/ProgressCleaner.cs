using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
internal class ProgressCleaner : MonoBehaviour
{
    public void ClearProgress()
    {
        for (int i = 1; i <= 6; i++)
        {
            PlayerPrefs.SetInt("gold"+i,0);
        }
        FindObjectOfType<GoldenCubes>().CheckHighlight();
    }
}
