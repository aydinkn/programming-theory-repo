using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemySpaceship : EnemySpaceship
{
    [SerializeField]
    private LayerMask projectileLayer;

    [SerializeField]
    private float dodgeDistance = 3.0f;

    private bool dodging;
    private bool canDodge = true;

    [SerializeField]
    private float dodgeRate = 3.0f;

    private float currentDodgeRate;

    protected override void Update()
    {
        UpdateDodgeRate();

        base.Update();
    }

    private void UpdateDodgeRate()
    {
        if (!canDodge)
        {
            currentDodgeRate += Time.deltaTime;

            if (currentDodgeRate >= dodgeRate)
            {
                currentDodgeRate = 0f;
                dodging = false;
                canDodge = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Dodge();
    }

    private void Dodge()
    {
        if (!canDodge || dodging) return;

        Vector3 center = transform.position + (-transform.localScale.z * Vector3.forward);
        Vector3 halfExtents = transform.localScale / 2;

        Collider[] colliders = Physics.OverlapBox(center, halfExtents, Quaternion.identity, projectileLayer);

        if (colliders.Length > 0 && colliders[0].gameObject.CompareTag("PlayerProjectile"))
        {
            dodging = true;
        }
    }

    public override void Move()
    {
        if (canDodge && dodging)
        {
            DodgeMove();
            canDodge = false;
            dodging = false;
            ResetInitialPosX();
            return;
        }

        base.Move();
    }

    private void DodgeMove()
    {
        if (transform.position.x + dodgeDistance < boundaryX)
        {
            transform.Translate(-dodgeDistance, 0, 0);
        }
        else
        {
            transform.Translate(dodgeDistance, 0, 0);
        }
    }
}
