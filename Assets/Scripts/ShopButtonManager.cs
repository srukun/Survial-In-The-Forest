using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonManager : MonoBehaviour
{
    public GameObject buyShotgunButton;
    public GameObject buyRifleButton;

    public GameObject equipPistolButton;
    public GameObject equipShotgunButton;
    public GameObject equipRifleButton;
    public List<WeaponClass> weapons;
    public GameObject TMProText_totalMoney;
    void Start()
    {
        weapons = DataManager.thisPlayer.weapons;
        UpdateTotalCashText();
        Debug.Log(equipPistolButton.GetComponent<Image>().color);
        EquipButtonManager();
    }


    void Update()
    {
        
    }
    public void BuyShotgun()
    {
        if (!weapons[1].isBought && DataManager.totalMoney >= weapons[1].cost)
        {
            DataManager.totalMoney -= weapons[1].cost;
            weapons[1].isBought = true;
            buyShotgunButton.SetActive(false);
            UpdateTotalCashText();
        }
    }
    public void BuyRifle()
    {
        if (!weapons[2].isBought && DataManager.totalMoney >= weapons[2].cost)
        {
            DataManager.totalMoney -= weapons[2].cost;
            weapons[2].isBought = true;
            buyRifleButton.SetActive(false);
            UpdateTotalCashText();
        }
    }
    public void EquipPistol()
    {
        if (weapons[0].isBought && DataManager.equipedWeapon.name != weapons[0].name)
        {
            DataManager.equipedWeapon = weapons[0];
            EquipButtonManager();
        }
    }
    public void EquipShotgun()
    {
        if (weapons[1].isBought && DataManager.equipedWeapon.name != weapons[1].name)
        {
            DataManager.equipedWeapon = weapons[1];
            EquipButtonManager();
        }
    }
    public void EquipRifle ()
    {
        if (weapons[2].isBought && DataManager.equipedWeapon.name != weapons[2].name)
        {
            DataManager.equipedWeapon = weapons[2];
            EquipButtonManager();
        }
    }
    public void EquipButtonManager()
    {
        //PISTOL
        if (DataManager.equipedWeapon.name != weapons[0].name)
        {
            equipPistolButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipPistolButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if(DataManager.equipedWeapon.name == weapons[0].name)
        {
            equipPistolButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipPistolButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
        //SHOTGUN
        if (DataManager.equipedWeapon.name != weapons[1].name)
        {
            equipShotgunButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipShotgunButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if (DataManager.equipedWeapon.name == weapons[1].name)
        {
            equipShotgunButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipShotgunButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
        //RIFLE
        if (DataManager.equipedWeapon.name != weapons[2].name)
        {
            equipRifleButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipRifleButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if (DataManager.equipedWeapon.name == weapons[2].name)
        {
            equipRifleButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipRifleButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
    }
    public void UpdateTotalCashText()
    {
        TMProText_totalMoney.GetComponent<TextMeshProUGUI>().SetText("$" + DataManager.totalMoney);
    }
}
