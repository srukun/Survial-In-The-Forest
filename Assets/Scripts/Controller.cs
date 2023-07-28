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
    #region "StartUpdate"
    void Start()
    {
        healthBar.maxValue = thisPlayer.maxHealth;
        healthBar.value = thisPlayer.health;
        //experienceBar.maxValue = thisPlayer.maxExperience;
        //experienceBar.value = thisPlayer.experience;
        shootTimer = 1f;
        UpdateHealthAndExp();
    }
    void Update()
    {
        AimDirection();
        
        WeaponFireAnimation();
        Shoot();

    }
    public void FixedUpdate()
    {
        Move();
    }
    #endregion


    #region "Shooting"
    public void WeaponFireAnimation()
    {
        if (Input.GetMouseButton(0))
        {
            bowAnimator.SetFloat("IsShooting", 1);
        }
        else
        {
            bowAnimator.SetFloat("IsShooting", 0);
        }
    }

    public void AimDirection()
    {
        mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle - 90);
    }
    public void Shoot()
    {
        if (shootTimer <= 0 && Input.GetMouseButton(0))
        {
            GameObject arrow = Instantiate(playerArrow, firePoint.position, firePoint.rotation);
            
            arrow.transform.eulerAngles = new Vector3(0, 0, aimAngle - 45);
            arrow.GetComponent<Rigidbody2D>().AddForce( aimTransform.up * 20f, ForceMode2D.Impulse);

            arrow.GetComponent<PlayerProjectileScript>().thisPlayer = thisPlayer;
            arrow.GetComponent<PlayerProjectileScript>().range = thisPlayer.weapons[0].range;
            arrow.GetComponent<PlayerProjectileScript>().playerObject = gameObject;
            shootTimer = 1 / thisPlayer.weapons[0].fireRate;
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }
    void ShootArrow()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instantiate the arrow prefab
        GameObject arrow = Instantiate(playerArrow, transform.position, Quaternion.identity);
        arrow.transform.eulerAngles = new Vector3(0, 0, aimAngle - 45);

        // Get the arrow's Rigidbody2D component
        Rigidbody2D rb2D = arrow.GetComponent<Rigidbody2D>();

        // Set the arrow's velocity towards the mouse position
        rb2D.velocity = direction * 20f;

        // Rotate the arrow sprite to face the shooting direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Destroy the arrow after some time to avoid cluttering the scene
        Destroy(arrow, 2f);
    }
    #endregion

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
        //experienceBar.maxValue = thisPlayer.experience;
        //experienceBar.value = thisPlayer.experience;
    }
    public void GainExperience(float experience)
    {
        //thisPlayer.experience += experience;
    }

}
