using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody projectileGO;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private float movementSpeed = 5F;

    protected float moveMultiplier = 1F;

    protected CharacterController controller;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    public Rigidbody ProjectileGO
    {
        get
        {
            return projectileGO;
        }
    }

    public Transform SpawnPosition
    {
        get
        {
            return spawnPosition;
        }
    }

    protected abstract bool Moving { get; }
    protected abstract bool Rotating { get; }
    protected abstract bool Running { get; }
    protected abstract bool Firing { get; }

    protected abstract float MovementFactor { get; }
    protected abstract float RotationFactor { get; }

    protected virtual void Fire()
    {
        Instantiate(projectileGO, spawnPosition.position, spawnPosition.rotation);
    }

    protected virtual void Move()
    {
        controller.SimpleMove(transform.forward * MovementFactor * MovementSpeed * moveMultiplier);
    }

    protected virtual void Rotate()
    {
        transform.Rotate(transform.up, movementSpeed * RotationFactor);
    }

    // Use this for initialization
    protected virtual void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();

            if (controller == null)
            {
                enabled = false;
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveMultiplier = Running ? 1.5F : 1F;

        if (Moving)
        {
            Move();
        }

        if (Rotating)
        {
            Rotate();
        }

        if (Firing)
        {
            Fire();
        }
    }
}