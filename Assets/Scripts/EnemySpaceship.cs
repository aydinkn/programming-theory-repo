using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : Spaceship
{
    [SerializeField]
    protected float moveDistance = 1.0f;

    [SerializeField]
    protected float fireRate = 2.0f;

    private float initialPosX;
    private bool moveLeft;

    private void Start()
    {
        ResetInitialPosX();
        moveLeft = true;

        InvokeRepeating("Shoot", 3f, fireRate);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected void ResetInitialPosX()
    {
        initialPosX = transform.position.x;
    }

    public override void Move()
    {
        if (moveLeft)
        {
            transform.Translate(GetTranslation());

            if (transform.position.x >= initialPosX + moveDistance)
            {
                moveLeft = false;
            }
        }
        else
        {
            transform.Translate(-GetTranslation());

            if (transform.position.x <= initialPosX - moveDistance)
            {
                moveLeft = true;
            }
        }
    }

    private Vector3 GetTranslation() => speed * Time.deltaTime * Vector3.left;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
