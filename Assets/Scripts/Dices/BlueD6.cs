using UnityEngine;
public class BlueD6 : DiceD6
{
    [SerializeField] private AbstractSuperPower[] _powersList;
    private void Awake()
    {
        base.Awake();

        _actionsList[0] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[0]);
            _description = "Jetpack\nHold to fly";
        };

        _actionsList[1] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[1]);
            _description = "Air jump\nClick in air to make an another one";
        };

        _actionsList[2] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[2]);
            _description = "Moon Gravity\nClick to change gravity for a few sec";
        };

        _actionsList[3] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[3]);
            _description = "Timeslower\nClick to slow the time for a game second";
        };

        _actionsList[4] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[4]);
            _description = "Teleporter\nClick to shot teleporting bullet";
        };

        _actionsList[5] = value =>
        {
            FindObjectOfType<SuperPowerUser>().NewSuperPower(_powersList[5]);
            _description = "Gravigun\nClick to shot pushing bullet";
        };
    }
}
