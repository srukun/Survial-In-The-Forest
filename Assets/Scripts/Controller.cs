using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public PlayerClass thisPlayer;

    public Animator animator;
    Vector3 movement;
    public Animator bowAnimator;
    public Transform aimTransform;
    public Camera cam;
    public GameObject playerArrow;
    public float aimAngle;
    public float shootTimer;
    public Vector3 mousePos;
    public Transform firePoint;

    public Slider healthBar;
    public Slider experienceBar;
    public TextMeshProUGUI[] experienceBarTextValues;
    public GameObject arenaManager;
    #region "StartUpdate"
    //guns
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rifle;
    //bows
    public GameObject Weapon_Bow;
    public GameObject Weapon_LongBow;
    public GameObject Weapon_CrossBow;
    void Start()
    {
        thisPlayer = DataManager.thisPlayer;
        thisPlayer.health = thisPlayer.maxHealth;
        healthBar.maxValue = thisPlayer.maxHealth;
        healthBar.value = thisPlayer.health;
        //weapons
        pistol.GetComponent<PistolScript>().thisPlayer = thisPlayer;
        shotgun.GetComponent<ShotgunScript>().thisPlayer = thisPlayer;
        rifle.GetComponent<RifleScript>().thisPlayer = thisPlayer;
        //bows
        Weapon_Bow.GetComponent<WeaponScript_Bow>().thisPlayer = thisPlayer;
        Weapon_LongBow.GetComponent<WeaponScript_LongBow>().thisPlayer = thisPlayer;
        Weapon_CrossBow.GetComponent<WeaponScript_CrossBow>().thisPlayer = thisPlayer;


        if(DataManager.equipedWeapon.name != "Pistol")
        {
            pistol.SetActive(false);
        }
        if(DataManager.equipedWeapon.name != "Shotgun")
        {
            shotgun.SetActive(false);
        }
        if (DataManager.equipedWeapon.name != "Rifle")
        {
            rifle.SetActive(false);
        }
        if (DataManager.equipedWeapon.name != "Bow")
        {
            Weapon_Bow.SetActive(false);
        }
        if (DataManager.equipedWeapon.name != "Long Bow")
        {
            Weapon_LongBow.SetActive(false);
        }
        if (DataManager.equipedWeapon.name != "Crossbow")
        {
            Weapon_CrossBow.SetActive(false);
        }


        shootTimer = 1f;
        UpdateHealthAndExp();
    }
    void Update()
    {

    }
    public void FixedUpdate()
    {
        Move();
        FireWeapon();
    }
    #endregion

    public void FireWeapon()
    {
        if (Input.GetButton("Fire1") && pistol.activeInHierarchy)
        {
            pistol.GetComponent<PistolScript>().Shoot();
        }
        else if (Input.GetButton("Fire1") && shotgun.activeInHierarchy)
        {
            shotgun.GetComponent<ShotgunScript>().Shoot();
        }
        else if (Input.GetButton("Fire1") && rifle.activeInHierarchy)
        {
            rifle.GetComponent<RifleScript>().Shoot();
        }
        else if (Input.GetButton("Fire1") && Weapon_Bow.activeInHierarchy)
        {
            Weapon_Bow.GetComponent<WeaponScript_Bow>().Shoot();
        }
        else if (Input.GetButton("Fire1") && Weapon_LongBow.activeInHierarchy)
        {
            Weapon_LongBow.GetComponent<WeaponScript_LongBow>().Shoot();
        }
        else if (Input.GetButton("Fire1") && Weapon_CrossBow.activeInHierarchy)
        {
            Weapon_CrossBow.GetComponent<WeaponScript_CrossBow>().Shoot();
        }
    }



    #region "Movement"
    public void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        transform.position += movement.normalized * Time.deltaTime * thisPlayer.speed;


        animator.SetFloat("Horizontal", mousePos.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    #endregion
    public void UpdateHealthAndExp()
    {
        healthBar.maxValue = thisPlayer.maxHealth;
        healthBar.value = thisPlayer.health;

    }

    public void RewardMoney(int money)
    {
        DataManager.totalMoney += money;
        arenaManager.GetComponent<ArenaManager>().totalCashEarned += money;
        arenaManager.GetComponent<ArenaManager>().UpdatePlayerCash();
    }

}
