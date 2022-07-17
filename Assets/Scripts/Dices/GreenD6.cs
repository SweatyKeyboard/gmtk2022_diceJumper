using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenD6 : DiceD6
{
    private void Awake()
    {
        base.Awake();

        _actionsList[0] = value =>
        {
            FindObjectOfType<PlayerMovement>().SpeedUp();
            _description = "Movement speed up";
        };

        _actionsList[1] = value =>
        {
            FindObjectOfType<PlayerMovement>().JumpUp();
            _description = "Jump strength up";
        };

        _actionsList[2] = value =>
        {
            FindObjectOfType<GunShooting>().BulletSpeedUp();
            _description = "Bullet speed up";
        };

        _actionsList[3] = value =>
        {
            FindObjectOfType<ChasingCam>().FieldOfViewUp();
            _description = "Field of view is expanded";
        };

        _actionsList[4] = value =>
        {
            FindObjectOfType<GunShooting>().RateOfFireUp();
            _description = "Rate of fire up";
        };

        _actionsList[5] = value =>
        {
            FindObjectOfType<GunShooting>().BulletRangeUp();
            _description = "Bullet range up";
        };
    }
}
