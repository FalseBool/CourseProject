using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Stats:")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    //public float speedOfBullet = 15f;

    [Header("Recoil:")]
    public RecoilGun RecoilObject;

    [Header("Pointers:")]
    public Camera Cam;
    [SerializeField]
    private GameObject Player = null;
    [SerializeField]
    private ParticleSystem muzzleflash = null;
    [SerializeField]
    private ParticleSystem ImpactParticle = null;

    public GameObject bullet = null;
    public GameObject bulletPoint = null;

    public LayerMask m_LayerMask;
    private float nextTimeToFire = 0f;

    [Header("Ammo Parameters")]
    public float ammoReloadDelay = 2f;
    public float ammoReloadSpeed = 2f;
    public float maxAmmo = 8;
    public float currentAmmo { get; private set; }
    private float lastTimeShot;
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAmmo();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo >= 1)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Debug.DrawLine(Cam.transform.position, Cam.transform.position + Cam.transform.forward * range, Color.red,1f);
            Shoot();
        }
    }
    void UpdateAmmo()
    {
        if (currentAmmo < maxAmmo && lastTimeShot + ammoReloadDelay < Time.time)
        {
            currentAmmo += ammoReloadSpeed * Time.deltaTime;

            currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        }

    }
    void Shoot()
    {
        muzzleflash.Play();
        RecoilObject.resetTimer();
        lastTimeShot = Time.time;
        currentAmmo -= 1;
        RaycastHit hit;
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range, m_LayerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Trace hit " + hit.transform.name);
            Health target = hit.transform.GetComponent<Health>();
            if (target != null )
            {
                target.TakeDamage(damage);
            }
            Instantiate(ImpactParticle, hit.point, Quaternion.LookRotation(hit.normal));
        }
        //GameObject bulletClone = Instantiate(bullet, bulletPoint.transform.position, Quaternion.LookRotation(dirToFace));
        //bulletClone.GetComponent<BulletScript>().speed = speedOfBullet;
        //bulletClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speedOfBullet));
    }
}
