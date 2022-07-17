using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedD6 : DiceD6
{
    private void Awake()
    {
        base.Awake();
        _actionsList[0] = value =>
        {
            PlayerLife playerLife = FindObjectOfType<PlayerLife>();
            if (playerLife.RedDices < 6)
            {
                playerLife.RedDices++;
            }
        };

        _actionsList[1] = value =>
        {
            
            PlayerLife playerLife = FindObjectOfType<PlayerLife>();
            if (value+1 <= playerLife.RedDices)
            {
                FindObjectOfType<PlayerMovement>().IsImmovable = false;
                FindObjectOfType<GunRotation>().IsImmovable = false;
                FindObjectOfType<GunShooting>().IsImmovable = false;
                playerLife.AddHP();
                playerLife.ResetRedDices();
                _description = "The another chance for you";
            }
            else
            {
                playerLife.FinallyDie();
                _description = "Not this time...";
            }
        };
    }
}
