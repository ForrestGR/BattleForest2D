using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{

    private Transform aimTransform;
    private Animator aimAnimator;


    private void Awake()
    {       
        aimTransform = transform.Find("Aim");
        aimAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }


    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aimAnimator.SetTrigger("Shoot");
        }
    }
}





//test est est








//public Transform player; // Setze dies auf deinen Spieler im Inspector

//public float orbitDistance = .43f; // Wie weit die Waffe vom Spieler entfernt ist
//public float rotationSpeed = 100.0f; // Geschwindigkeit der Eigenrotation der Waffe

//private Quaternion initialRotation;

//void Start()
//{
//    // Speichere die anfängliche Rotation der Waffe
//    initialRotation = transform.localRotation;
//}

//void Update()
//{
//    // Position der Maus im Weltkoordinatensystem ermitteln
//    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
//    mousePosition.z = 0; // Stelle sicher, dass die Z-Position nicht die Ausrichtung beeinflusst

//    // Richtung von der Waffe zum Mauszeiger berechnen
//    Vector3 direction = mousePosition - player.position;

//    // Die Waffe in die Richtung der Maus ausrichten
//    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//    transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Ausrichtung zur Maus

//    // Die Position der Waffe aktualisieren, damit sie um den Spieler kreist
//    direction.Normalize(); // Normalisiere die Richtung
//    transform.position = player.position + direction * orbitDistance;

//    // Zusätzliche Rotation um die eigene Achse
//    transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
//}
