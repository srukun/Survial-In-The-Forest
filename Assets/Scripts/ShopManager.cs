using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerClass player;
    public List<WeaponClass> weapons;
    //cost info
    public GameObject pistolTitleCostInfo;
    public GameObject shotgunTitleCostInfo;
    public GameObject rifleTitleCostInfo;

    public GameObject bowTitleCostInfo;
    public GameObject longbowTitleCostInfo;
    public GameObject crossbowTitleCostInfo;
    //weapon info
    public GameObject pistolWeaponInfo;
    public GameObject shotgunWeaponInfo;
    public GameObject rifleWeaponInfo;

    public GameObject bowWeaponInfo;
    public GameObject longbowWeaponInfo;
    public GameObject crossbowWeaponInfo;



    void Start()
    {
        player = DataManager.thisPlayer;
        weapons = player.weapons;
        UpdateTitleText();
        UpdateWeaponInfo();
    }

    void Update()
    {
        
    }
    public void UpdateTitleText()
    {
        if (weapons[0].isBought)
        {
            pistolTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[0].name);
        }
        else if (!weapons[0].isBought)
        {
            pistolTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[0].name + " \n$" + weapons[0].cost);
        }
        if (weapons[1].isBought)
        {
            shotgunTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[1].name);
        }
        else if (!weapons[1].isBought)
        {
            shotgunTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[1].name + " \n$" + weapons[1].cost);
        }
        if (weapons[2].isBought)
        {
            rifleTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[2].name);
        }
        else if (!weapons[2].isBought)
        {
            rifleTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[2].name + " \n$" + weapons[2].cost);
        }
        if (weapons[3].isBought)
        {
            bowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[3].name);
        }
        else if (!weapons[3].isBought)
        {
            bowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[3].name + " \n$" + weapons[3].cost);
        }
        if (weapons[4].isBought)
        {
            longbowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[4].name);
        }
        else if (!weapons[4].isBought)
        {
            longbowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[4].name + " \n$" + weapons[4].cost);
        }
        if (weapons[5].isBought)
        {
            crossbowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[5].name);
        }
        else if (!weapons[5].isBought)
        {
            crossbowTitleCostInfo.GetComponent<TextMeshProUGUI>().SetText(weapons[5].name + " \n$" + weapons[5].cost);
        }
    }
    public void UpdateWeaponInfo()
    {
        pistolWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[0].damage +
            "\r\nRange: " + weapons[0].range + "\r\nFire Rate: " + weapons[0].fireRate + "/s");
        shotgunWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[1].damage +
    "\r\nRange: " + weapons[1].range + "\r\nFire Rate: " + weapons[1].fireRate + "/s");
        rifleWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[2].damage +
    "\r\nRange: " + weapons[2].range + "\r\nFire Rate: " + weapons[2].fireRate + "/s");

        bowWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[3].damage +
    "\r\nRange: " + weapons[3].range + "\r\nFire Rate: " + weapons[3].fireRate + "/s");
        longbowWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[4].damage +
    "\r\nRange: " + weapons[4].range + "\r\nFire Rate: " + weapons[4].fireRate + "/s");
        crossbowWeaponInfo.GetComponent<TextMeshProUGUI>().SetText("Damage: +" + weapons[5].damage +
    "\r\nRange: " + weapons[5].range + "\r\nFire Rate: " + weapons[5].fireRate + "/s");
    }

}
