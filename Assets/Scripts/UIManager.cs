using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText;
    public Text healthText;
    public Text armorText;
    public Text bullText;
    public Text shellText;

    public void ArmorEdit(int armor)
    {
        armorText.text = armor.ToString();
    }
    public void HealthEdit(int health)
    {
        healthText.text = health.ToString();
    }

    public void WhichWeapon() //maybe: string weapon
                                    //if(weapon == "Pistol"){
                                    // weapon# = 0}
    {
        //tracks which weapon is currently being used so that the correct ammo can be displayed
        //then sends the number gotten to AmmoText
    }
    public void AmmoText()
    {
        //
    }
}
