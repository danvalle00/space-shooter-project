using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Basic Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float baseFireRate = 0.2f;
    [SerializeField] private float projectileLifetime = 3f;


    [Header("AI Shooting Settings")]
    [SerializeField] private bool useAI;
    [SerializeField] private float fireRateVariance = 0f;
    [SerializeField] private float minimumFireRate = 0.2f;

    [HideInInspector] public bool IsFiring;

    private Coroutine fireCoroutine;


    private void Start()
    {
        if (useAI)
        {
            IsFiring = true;
            baseFireRate = Random.Range(0.2f, 1f);
        }

    }

    private void Update()
    {
        Fire();
    }
    private void Fire()
    {
        if (IsFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireCoroutine());
        }
        else if (!IsFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            Destroy(projectile, projectileLifetime);

            float waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime, minimumFireRate, float.MaxValue);
            yield return new WaitForSeconds(waitTime);
        }
    }

}