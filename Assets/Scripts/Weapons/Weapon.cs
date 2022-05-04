using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] bool canShoot = true;
    [SerializeField] float timeBetweenShot = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    AudioManager audioManager;


    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        DisplayAmmo();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        } 
    }

    private void DisplayAmmo()
    {

        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();

    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleEffect();
        ProcessRaycast();
        ammoSlot.ReduceAmmo(ammoType);
        audioManager.PlayGunAudio();
        DisplayAmmo();
        yield return new WaitForSeconds(timeBetweenShot);
        canShoot = true;
    }

  
   
    private void PlayMuzzleEffect()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (isHit)
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;

            target.TakeDamage(damage);
        }

      
    }

    

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        if (ammoType.ToString() == "Rockets")
        {
            RocketDamage(hit);
        }
        
        Destroy(effect,.5f);
        
    }

    private void RocketDamage(RaycastHit hit)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<RocketExplosion>();
        sphere.transform.position = hit.point;
    }
}
