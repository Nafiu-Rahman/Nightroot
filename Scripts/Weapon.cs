using StarterAssets;
using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public class Weapon : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;

    [SerializeField] float zoomedFOV = 30f;
    float defaultFOV;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    //[SerializeField] GameObject zoomVignette;

    [SerializeField] AudioClip Shoot;
    AudioSource audioSource;

    StarterAssetsInputs starterAssetsInputs;

    [SerializeField] Ammo ammoSlot;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

        defaultFOV = virtualCamera.m_Lens.FieldOfView;
    }
    private void Start() {
        DisplayAmmo();
        audioSource = GetComponent<AudioSource>();
    }

    void DisplayAmmo()
    {
        if (ammoText != null)
        {
            //ammoText.text = ammoSlot.GetCurrentAmmo().ToString();
        }
    }
    void Update()
    {
        //if (starterAssetsInputs.shoot)
        HandleShoot();
        HandleZoom();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;


        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            muzzleFlash.Play();

            audioSource.PlayOneShot(Shoot);


            animator.Play("BistolAnimation", 0, 0f);

            starterAssetsInputs.ShootInput(false);
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {

                Debug.Log(hit.collider.name);
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                enemyHealth?.TakeDamage(damageAmount);


            }
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    void HandleZoom()
    {
        if (starterAssetsInputs.zoom)
        {
            //zoomVignette.SetActive(true);
            virtualCamera.m_Lens.FieldOfView = zoomedFOV;

            // Slow motion
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; // Keep physics smooth
            audioSource.pitch = 0.5f;
        }
        else
        {
            //zoomVignette.SetActive(false);
            virtualCamera.m_Lens.FieldOfView = defaultFOV;

            // Return to normal speed
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f; // Reset physics timing
            audioSource.pitch = 1f;
        }
    }

}




