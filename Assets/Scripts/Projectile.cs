using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private float deadZone;

    public float Speed
    {
        get { return speed; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Projectile speed cannot be negative");
                return;
            }

            speed = value;
        }
    }

    void Update()
    {
        if (IsInDeadZone())
        {
            Destroy(gameObject);
            return;
        }

        Move();
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private bool IsInDeadZone() => (transform.position.z * Mathf.Sign(deadZone)) > Mathf.Abs(deadZone);

    public void SetDeadZone(float zone) => deadZone = zone;
}
