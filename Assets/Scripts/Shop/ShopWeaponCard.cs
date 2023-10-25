using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponCard : MonoBehaviour
{
    public WeaponClass thisWeapon;
    public Image weaponImage;
    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_description;
    public TextMeshProUGUI text_button;
    public Image image_button_background;
    public TextMeshProUGUI text_total_money;
    public GameObject shopManager;

    void Start()
    {

    }

    
    void Update()
    {
        
    }
    public void UpdateCard()
    {
        text_name.SetText(thisWeapon.name);
        weaponImage.sprite = Resources.Load<Sprite>(thisWeapon.sprite);
        text_description.SetText((int)thisWeapon.damage + "\n" + (int)thisWeapon.range + "\n" + (int)thisWeapon.fireRate + "\n" + (int)thisWeapon.speed);
    }
    public void UpdateButtonText()
    {
        if (!thisWeapon.isBought)
        {
            text_button.SetText("BUY $" + thisWeapon.cost);
        }
        else
        {
            if (thisWeapon.equals(DataManager.equipedWeapon))
            {
                text_button.SetText("EQUIPED");
                image_button_background.color = new Color(0.502f, 0.765f, 0.518f, 1.0f);
            }
            else
            {
                text_button.SetText("EQUIP");
                image_button_background.color = new Color(0.749f, 0.961f, 0.322f, 1.0f);
            }
        }
    }
    public void ClickButton()
    {
        if (!thisWeapon.isBought)
        {
            if (DataManager.totalMoney >= thisWeapon.cost)
            {
                thisWeapon.isBought = true;
                DataManager.totalMoney -= thisWeapon.cost;
                text_total_money.SetText("$ " + DataManager.totalMoney);

                DataManager.equipedWeapon = thisWeapon;
                UpdateCard();
                UpdateButtonText();
            }

        }
        else
        {
            if (!thisWeapon.equals(DataManager.equipedWeapon))
            {
                DataManager.equipedWeapon = thisWeapon;
                UpdateCard();
                UpdateButtonText();
            }
        }
        shopManager.GetComponent<ShopManager>().UpdateAllCards();
    }

}
