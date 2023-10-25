using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject guns;
    public GameObject bows;
    public GameObject[] weaponCards;
    public TextMeshProUGUI text_total_money;
    void Start()
    {
        text_total_money.SetText("$ " + DataManager.totalMoney);
        for(int i = 0; i < DataManager.thisPlayer.weapons.Count; i++)
        {
            weaponCards[i].GetComponent<ShopWeaponCard>().thisWeapon = DataManager.thisPlayer.weapons[i];
            weaponCards[i].GetComponent<ShopWeaponCard>().UpdateCard();
            weaponCards[i].GetComponent<ShopWeaponCard>().UpdateButtonText();
        }
        ShowGuns();
    }

    
    void Update()
    {
        
    }
    public void ShowGuns()
    {
        guns.SetActive(true);
        bows.SetActive(false);
    }
    public void ShowBows()
    {
        guns.SetActive(false);
        bows.SetActive(true);
    }
    public void UpdateAllCards()
    {
        for (int i = 0; i < weaponCards.Length; i++)
        {
            weaponCards[i].GetComponent<ShopWeaponCard>().UpdateCard();
            weaponCards[i].GetComponent<ShopWeaponCard>().UpdateButtonText();
        }
    }
}
