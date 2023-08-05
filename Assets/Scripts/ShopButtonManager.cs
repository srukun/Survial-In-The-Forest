using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonManager : MonoBehaviour
{
    public GameObject buyShotgunButton;
    public GameObject buyRifleButton;
    public GameObject buyBowButton;
    public GameObject buyLongBowButton;
    public GameObject buyCrossBowButton;

    public GameObject equipPistolButton;
    public GameObject equipShotgunButton;
    public GameObject equipRifleButton;
    public GameObject equipBowButton;
    public GameObject equipLongBowButton;
    public GameObject equipCrossBowButton;
    public List<WeaponClass> weapons;
    public GameObject TMProText_totalMoney;


    public GameObject SceneObject_Guns;
    public GameObject SceneObject_Bows;

    public ShopManager shopManager;
    void Start()
    {
        weapons = DataManager.thisPlayer.weapons;
        UpdateTotalCashText();
        EquipButtonManager();
        HideBuyButton();
    }


    void Update()
    {
        
    }
    public void HideBuyButton()
    {
        if (weapons[1].isBought)
        {
            buyShotgunButton.SetActive(false);
        }
        if (weapons[2].isBought)
        {
            buyRifleButton.SetActive(false);
        }
        if (weapons[3].isBought)
        {
            buyBowButton.SetActive(false);
        }
        if (weapons[4].isBought)
        {
            buyLongBowButton.SetActive(false);
        }
        if (weapons[5].isBought)
        {
            buyCrossBowButton.SetActive(false);
        }
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
    public void BuyBow()
    {
        if (!weapons[3].isBought && DataManager.totalMoney >= weapons[3].cost)
        {
            DataManager.totalMoney -= weapons[3].cost;
            weapons[3].isBought = true;
            buyBowButton.SetActive(false);
            UpdateTotalCashText();
        }
    }
    public void BuyLongBow()
    {
        if (!weapons[4].isBought && DataManager.totalMoney >= weapons[4].cost)
        {
            DataManager.totalMoney -= weapons[4].cost;
            weapons[4].isBought = true;
            buyLongBowButton.SetActive(false);
            UpdateTotalCashText();
        }
    }
    public void BuyCrossBow()
    {
        if (!weapons[5].isBought && DataManager.totalMoney >= weapons[5].cost)
        {
            DataManager.totalMoney -= weapons[5].cost;
            weapons[5].isBought = true;
            buyCrossBowButton.SetActive(false);
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
    public void EquipBow()
    {
        if (weapons[3].isBought && DataManager.equipedWeapon.name != weapons[3].name)
        {
            DataManager.equipedWeapon = weapons[3];
            EquipButtonManager();
        }
    }
    public void EquipLongBow()
    {
        if (weapons[4].isBought && DataManager.equipedWeapon.name != weapons[4].name)
        {
            DataManager.equipedWeapon = weapons[4];
            EquipButtonManager();
        }
    }
    public void EquipCrossBow()
    {
        if (weapons[5].isBought && DataManager.equipedWeapon.name != weapons[5].name)
        {
            DataManager.equipedWeapon = weapons[5];
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
        //BOW
        if (DataManager.equipedWeapon.name != weapons[3].name)
        {
            equipBowButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if (DataManager.equipedWeapon.name == weapons[3].name)
        {
            equipBowButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
        //LONGBOW
        if (DataManager.equipedWeapon.name != weapons[4].name)
        {
            equipLongBowButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipLongBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if (DataManager.equipedWeapon.name == weapons[4].name)
        {
            equipLongBowButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipLongBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
        //CROSSBOW
        if (DataManager.equipedWeapon.name != weapons[5].name)
        {
            equipCrossBowButton.GetComponent<Image>().color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            equipCrossBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIP");
        }
        else if (DataManager.equipedWeapon.name == weapons[5].name)
        {
            equipCrossBowButton.GetComponent<Image>().color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            equipCrossBowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("EQUIPED");
        }
    }
    public void UpdateTotalCashText()
    {
        TMProText_totalMoney.GetComponent<TextMeshProUGUI>().SetText("$" + DataManager.totalMoney);
    }
    public void SeeGuns()
    {
        if (!SceneObject_Guns.activeInHierarchy)
        {
            SceneObject_Guns.SetActive(true);
            SceneObject_Bows.SetActive(false);
            shopManager.UpdateTitleText();
            shopManager.UpdateWeaponInfo();
            EquipButtonManager();
            HideBuyButton();
        }
    }
    public void SeeBows()
    {
        if (!SceneObject_Bows.activeInHierarchy)
        {
            SceneObject_Bows.SetActive(true);
            SceneObject_Guns.SetActive(false);
            shopManager.UpdateTitleText();
            shopManager.UpdateWeaponInfo();
            EquipButtonManager();
            HideBuyButton();
        }
    }
}
