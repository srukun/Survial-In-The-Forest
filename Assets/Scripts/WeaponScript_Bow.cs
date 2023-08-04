using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponScript_Bow : MonoBehaviour
{
    public PlayerClass thisPlayer;
    public Transform aimTransform;
    public Camera cam;
    public GameObject Prefab_Arrow;
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

    }
    public void Shoot()
    {
        if (shootTimer <= 0 && Input.GetMouseButton(0))
        {
            GameObject SceneObject_Arrow = Instantiate(Prefab_Arrow, firePoint.position, Quaternion.Euler(0, 0, aimAngle));

            SceneObject_Arrow.GetComponent<Rigidbody2D>().AddForce(SceneObject_Arrow.transform.right * 18f, ForceMode2D.Impulse);
            SceneObject_Arrow.transform.eulerAngles += new Vector3(0, 0,- 45);

            AssignProjectileInformation(SceneObject_Arrow);

            shootTimer = 1 / thisPlayer.weapons[0].fireRate;
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }
    public void AssignProjectileInformation(GameObject SceneObject_Arrow)
    {
        SceneObject_Arrow.GetComponent<PlayerProjectileScript>().thisPlayer = thisPlayer;
        SceneObject_Arrow.GetComponent<PlayerProjectileScript>().range = thisPlayer.weapons[2].range;
        SceneObject_Arrow.GetComponent<PlayerProjectileScript>().playerObject = playerObject;
    }
}