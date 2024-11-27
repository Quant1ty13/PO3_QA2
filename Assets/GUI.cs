using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] Swordsman swordsman;
    [SerializeField] Archer archer;
    [SerializeField] Mage mage;
    [SerializeField] CompanionKnight knight;
    [SerializeField] DemonKing king;

    private string PlayerLabel = "Choose your Character";
    private string CompanionLabel = "Your Companion is Here";
    private string BossLabel = "The Demon King is Ahead";
    private string Battle = "Battle";
    private PlayerStats Player;

    private void OnGUI()
    {
        var FontSize = 30;

        UnityEngine.GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "2nd Quarterly Assessment for PO3");
        UnityEngine.GUI.Label(new Rect(250, 75, 1000, 1000), PlayerLabel);
        UnityEngine.GUI.Label(new Rect(250, 500, 1000, 1000), CompanionLabel);
        UnityEngine.GUI.Label(new Rect(1000, 200, 1000, 1000), BossLabel);
        UnityEngine.GUI.Label(new Rect(690, 350, 100, 100), Battle);
        UnityEngine.GUI.skin.label.fontSize = FontSize;

        if (UnityEngine.GUI.Button(new Rect(25, 25, 150, 50), "Swordsman"))
        {
            Player = swordsman;
            PlayerLabel = "Player: " + "\nHealth: " + swordsman.Health + "\nAttack: " + swordsman.Attack + "\nDefences: " + swordsman.Defences;
        }

        if (UnityEngine.GUI.Button(new Rect(25, 100, 150, 50), "Archer"))
        {
            Player = archer;
            PlayerLabel = "Player: " + "\nHealth: " + archer.Health + "\nAttack: " + archer.Attack + "\nDefences: " + archer.Defences;
        }

        if (UnityEngine.GUI.Button(new Rect(25, 175, 150, 50), "Mage"))
        {
            Player = mage;
            PlayerLabel = "Player: " + "\nHealth: " + mage.Health + "\nAttack: " + mage.Attack + "\nDefences: " + mage.Defences;
        }

        if (UnityEngine.GUI.Button(new Rect(25, 500, 150, 50), "Companion Knight"))
        {
            CompanionLabel = "Companion Knight: " + "\nHealth: " + knight.Health + "\nAttack: " + knight.Attack + "\nDefences: " + knight.Defences;
        }

        if (UnityEngine.GUI.Button(new Rect(1250, 350, 150, 50), "Demon King"))
        {
            BossLabel = "Demon King: " + "\nHealth: " + king.Health + "\nAttack: " + king.Attack + "\nDefences: " + king.Defences;
        }

        if (UnityEngine.GUI.Button(new Rect(1050, 500, 150, 50), "CLASH!"))
        {
            if (king != null)
            {
                king.Health -= Player.Attack;
            }
            if (Player != null)
            {
                Player.Health -= king.Attack;
            }
            if (knight != null)
            {
                knight.Health -= king.Attack;
            }
            AttackDamage();

            if (king.Health <= 0)
            {
                PlayerLabel = "";
                CompanionLabel = "";
                BossLabel = "";
                Battle = "Player Wins!";
            }

            if (Player.Health <= 0)
            {
                PlayerLabel = "";
                CompanionLabel = "";
                BossLabel = "";
                Battle = "Demon King Wins!";
            }

            if (knight.Health <= 0)
            {
                knight.Health = 0;
            }
        }
    }

    private void AttackDamage()
    {
        BossLabel = "Demon King: " + "\nHealth: " + king.Health + "\nAttack: " + king.Attack + "\nDefences: " + king.Defences;
        PlayerLabel = "Player: " + "\nHealth: " + Player.Health + "\nAttack: " + Player.Attack + "\nDefences: " + Player.Defences;
        CompanionLabel = "Companion Knight: " + "\nHealth: " + knight.Health + "\nAttack: " + knight.Attack + "\nDefences: " + knight.Defences;
    }
}
