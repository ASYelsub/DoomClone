using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager me;

    [Header("UI Text Assign")]
    public Text ammoText;
    public Text healthText;
    public Text armorText;
    public Text bullText;
    public Text shellText;
    public Text rocketText;
    public Text cellText;

    public Text[] gunText;

    public void Awake()
    {
        if (me != null)
        {
            Destroy(gameObject);
            return;
        }
        me = this;
    }

    public void UnlockPistol()
    {
        gunText[0].color = Color.yellow;
    }

    public void UnlockShotgun()
    {
        gunText[1].color = Color.yellow;
    }

    public void BullEdit(int bull)
    {
        bullText.text = bull.ToString() + "/200";
    }

    public void ShellEdit(int shell)
    {
        shellText.text = shell.ToString() + "/50";
    }

    public void RocketEdit(int rckt)
    {
        rocketText.text = rckt.ToString() + "/50";
    }

    public void CellEdit(int cell)
    {
        cellText.text = cell.ToString() + "/50";
    }

    public void CurrentAmmoEdit(int ammo)
    {
        ammoText.text = ammo.ToString();
    }

    public void ArmorEdit(int armor)
    {
        armorText.text = armor.ToString() + "%";
    }
    public void HealthEdit(int health)
    {
        healthText.text = health.ToString() + "%";
    }

    public void PickUpPisol() 
    {
        gunText[0].color = Color.yellow;
    }

    public void PickUpShotgun()
    {
        gunText[1].color = Color.yellow;
    }
}
