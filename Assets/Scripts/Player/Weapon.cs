using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public Transform Player;
    public GameObject Bullet;


    public float fireRate = 0.2f;
    private float timeSinceLastShot = 0.0f;

    private int bulletShot;
    private bool isReloading = false;
    private float reloadTime;

    Vector3 oldPostion;

    private void Update()
    {
        // Vector3 mousePosition = Input.mousePosition;
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10.0f));
        // Vector3 direction = worldPosition - Player.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // shootPoint.position = Player.position + direction.normalized * 0.5f;

        if (bulletShot == 6)
        {
            isReloading = true;
            reloadTime += Time.deltaTime;
            if (reloadTime > Mathf.PI / 4)
            {
                bulletShot = 0;
                isReloading = false;
                reloadTime = 0;
            }
            Debug.Log("Reload Phase");
            return;
        }


        timeSinceLastShot += Time.deltaTime;
        // // Check if the shoot button has been pressed
        // if (Input.GetMouseButton(0) && timeSinceLastShot >= fireRate && !isReloading)
        // {
        //     Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        //     bulletShot += 1;
        //     timeSinceLastShot = 0.0f;
        // }

        // if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= fireRate && !isReloading)
        // {
        //     Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        //     bulletShot += 1;
        //     timeSinceLastShot = 0.0f;
        // }
    }

    public void LookMouse(InputAction.CallbackContext context)
    {

        // Vector2 position = Mouse.current.position.ReadValue();

        Vector2 position = context.ReadValue<Vector2>();
        // Debug.Log(position);
        Vector3 pos = new Vector3(position.x, position.y, 0);
        // Convert the mouse position to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10.0f));

        // Calculate the direction vector between the player and the mouse
        Vector3 direction = worldPosition - shootPoint.position;

        // Calculate the angle between the direction vector and the positive x-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angle2 = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;


        shootPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shootPoint.position = Player.position + direction.normalized;// * 0.5f;
    }
    public void LookController(InputAction.CallbackContext context)
    {

        // Vector2 position = Mouse.current.position.ReadValue();

        Vector2 position = context.ReadValue<Vector2>();
        Debug.Log(position);
        Vector3 pos = new Vector3(position.x, position.y, 0);
        // // Convert the mouse position to world coordinates
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10.0f));

        // // Calculate the direction vector between the player and the mouse
        // Vector3 direction = worldPosition - shootPoint.position;

        // // Calculate the angle between the direction vector and the positive x-axis
        float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        // float angle2 = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;


        // shootPoint.rotation = Quaternion.AngleAxis(angle1, Vector3.forward);
        shootPoint.position = Player.position + pos * 0.5f;
        shootPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // shootPoint.position = Player.position + direction.normalized * 0.5f;
    }
    public void Fire(InputAction.CallbackContext context)
    {

        // click 
        if (context.performed && timeSinceLastShot >= fireRate && !isReloading)
        {
            Debug.Log("press");
            Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
            bulletShot += 1;
            timeSinceLastShot = 0.0f;
        }
        // should be hold 
        // TODO: FIX HOLD TO SHOOT
        // if (context.ReadValueAsButton() && timeSinceLastShot >= fireRate && !isReloading)
        // {
        //     Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        //     bulletShot += 1;
        //     timeSinceLastShot = 0.0f;
        // }
    }
}
