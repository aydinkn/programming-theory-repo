using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10.0f;

    [SerializeField]
    protected float boundaryX = 22.0f;

    [SerializeField]
    protected GameObject projectilePrefab;

    [SerializeField]
    protected Transform projectileSpawnPoint;

    [SerializeField]
    protected float projectileSpeed = 25.0f;

    [SerializeField]
    protected float projectileDeadZone = 14.0f;

    public abstract void Move();
    public virtual void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript == null) return;

        projectileScript.Speed = projectileSpeed;
        projectileScript.SetDeadZone(projectileDeadZone);
    }
}
