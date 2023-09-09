using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpaceship : Spaceship
{
    [SerializeField]
    private float fireRate = .8f;

    private bool canFire = true;
    private float currentFireRate;

    void Update()
    {
        Move();
        UpdateFireRate();
        Shoot();
    }

    private void UpdateFireRate()
    {
        if (!canFire)
        {
            currentFireRate += Time.deltaTime;

            if (currentFireRate >= fireRate)
            {
                currentFireRate = 0f;
                canFire = true;
            }
        }
    }

    public override void Move()
    {
        if (transform.position.x < boundaryX && Input.GetKey(KeyCode.D))
        {
            transform.Translate(GetTranslation());
        }
        else if (transform.position.x > -boundaryX && Input.GetKey(KeyCode.A))
        {
            transform.Translate(-GetTranslation());
        }
    }

    public override void Shoot()
    {
        if (canFire && Input.GetKeyDown(KeyCode.Space))
        {
            base.Shoot();
            canFire = false;
        }
    }

    private Vector3 GetTranslation() => speed * Time.deltaTime * Vector3.right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
