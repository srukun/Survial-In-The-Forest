using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShotgunScript : MonoBehaviour
{
    public PlayerClass thisPlayer;
    public Transform aimTransform;
    public Camera cam;
    public GameObject playerBullet;
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

    }
    public void AimDirection()
    {
        mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);

        Vector3 localScale = Vector3.one;
        if(aimAngle > 90 || aimAngle < -90)
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
            GameObject bullet = Instantiate(playerBullet, firePoint.position, Quaternion.Euler(0, 0, aimAngle + 10));
            GameObject bullet2 = Instantiate(playerBullet, firePoint.position, Quaternion.Euler(0, 0, aimAngle));
            GameObject bullet3 = Instantiate(playerBullet, firePoint.position, Quaternion.Euler(0, 0, aimAngle + -10));

/*            bullet.transform.eulerAngles = new Vector3(0, 0, aimAngle);
            bullet2.transform.eulerAngles = new Vector3(0, 0, aimAngle );
            bullet3.transform.eulerAngles = new Vector3(0, 0, aimAngle);*/

            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 30f, ForceMode2D.Impulse);
            bullet2.GetComponent<Rigidbody2D>().AddForce(bullet2.transform.right * 30f, ForceMode2D.Impulse);
            bullet3.GetComponent<Rigidbody2D>().AddForce(bullet3.transform.right * 30f, ForceMode2D.Impulse);

            AssignBulletInfo(bullet);
            AssignBulletInfo(bullet2);
            AssignBulletInfo(bullet3);

            shootTimer = 1 / thisPlayer.weapons[0].fireRate;
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }
    public void AssignBulletInfo(GameObject bullet)
    {
        bullet.GetComponent<PlayerProjectileScript>().thisPlayer = thisPlayer;
        bullet.GetComponent<PlayerProjectileScript>().range = thisPlayer.weapons[0].range;
        bullet.GetComponent<PlayerProjectileScript>().playerObject = playerObject;
    }
}
