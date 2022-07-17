using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GoldD6 : DiceD6
{
    private void Awake()
    {
        base.Awake();

        _actionsList[0] = value =>
        {
            PlayerPrefs.SetInt("gold1", 1);
            _description = !AreAllCollected() ?
                        "Golden \"one\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };

        _actionsList[1] = value =>
        {
            PlayerPrefs.SetInt("gold2", 1);
            _description = !AreAllCollected() ?
                        "Golden \"two\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };

        _actionsList[2] = value =>
        {
            PlayerPrefs.SetInt("gold3", 1);
            _description = !AreAllCollected() ?
                        "Golden \"three\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };

        _actionsList[3] = value =>
        {
            PlayerPrefs.SetInt("gold4", 1);
            _description = !AreAllCollected() ?
                        "Golden \"four\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };

        _actionsList[4] = value =>
        {
            PlayerPrefs.SetInt("gold5", 1);
            _description = !AreAllCollected() ?
                        "Golden \"five\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };

        _actionsList[5] = value =>
        {
            PlayerPrefs.SetInt("gold6", 1);
            _description = !AreAllCollected() ?
                        "Golden \"six\" is collected" :
                        "All golden dices are collected. Keep moving forward";
        };
    }

    private bool AreAllCollected()
    {
        int sum = 0;
        for (int i = 1; i <= 6; i++)
        {
            sum += PlayerPrefs.GetInt("gold" + i);
        }

        if (sum == 6)
            FindObjectOfType<ChunkSpawner>().IsReadyToFinal = true;

        return sum == 6;
    }
}
