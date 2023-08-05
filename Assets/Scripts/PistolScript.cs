using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolScript : MonoBehaviour
{
    public PlayerClass thisPlayer;
    public Transform aimTransform;
    public Camera cam;
    public GameObject playerArrow;
    public float aimAngle;
    public float shootTimer;
    public Vector3 mousePos;
    public GameObject playerObject;
    public Transform firePoint;
    void Start()
    {
        
    }

    void Update()
    {
        AimDirection();
        if(firePoint.transform.position.x < playerObject.transform.position.x)
        {
            playerObject.GetComponent<Animator>().SetFloat("Horizontal", 1);
        }
        if(firePoint.transform.position.x >= playerObject.transform.position.x)
        {
            playerObject.GetComponent<Animator>().SetFloat("Horizontal", -1);
        }

    }
    public void AimDirection()
    {
        mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);

        Vector3 localScale = Vector3.one;
        if(aimAngle >= 90 || aimAngle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }
        aimTransform.localScale = localScale;
    }
    public void Shoot()
    {
        if (shootTimer <= 0 && Input.GetMouseButton(0))
        {
            GameObject arrow = Instantiate(playerArrow, firePoint.position, Quaternion.identity);

            arrow.transform.eulerAngles = new Vector3(0, 0, aimAngle);
            arrow.GetComponent<Rigidbody2D>().AddForce(firePoint.right * 50f, ForceMode2D.Impulse);

            arrow.GetComponent<PlayerProjectileScript>().thisPlayer = thisPlayer;
            arrow.GetComponent<PlayerProjectileScript>().range = DataManager.equipedWeapon.range;
            arrow.GetComponent<PlayerProjectileScript>().playerObject = playerObject;
            shootTimer = 1 / DataManager.equipedWeapon.fireRate;
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }
    
}
