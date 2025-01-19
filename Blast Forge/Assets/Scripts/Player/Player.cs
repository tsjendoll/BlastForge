using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Rendering;

public enum Guntype
{
    Pistol,
    RapidFire,
    Shotgun
}

public class Player : Entity
{

    public Guntype gunType = Guntype.Pistol;
    
    #region Prefabs
    [Header("Prefabs")]
    [SerializeField, Tooltip("Spawn point for the bullets")] GameObject bulletSpawnPoint;
    [SerializeField, Tooltip("Prefab for the bullets")] GameObject bulletPrefab;
    [SerializeField, Tooltip("Prefab of the arm and gun")] GameObject arm;
    #endregion

    [Space]
    [SerializeField, Tooltip("Offset for the arm rotation")] float offset = 90f;

    public SkillManager skill { get; private set; }

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion


    public float shootCooldown = 0.5f; // Time in seconds between shots
    private float lastShootTime;       // Tracks the time when the last shot occurred


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
    }

    protected override void Start()
    {
        stateMachine.Initialize(idleState);
    }

    protected override void Update() 
    {
        stateMachine.currentState.Update();

        RotateArm();

        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= lastShootTime + shootCooldown)
            ShootGun();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // TODO - JEN SHOCKWAVE
        }
                        
    }

    private void FixedUpdate()
    {
        
    }

    private void ShootGun()
    {
        if (gunType == Guntype.Pistol)
            shootCooldown = .3f;
        else if (gunType == Guntype.RapidFire)
            shootCooldown = .1f;
            
        lastShootTime = Time.time;

        if (gunType == Guntype.Pistol || gunType == Guntype.RapidFire)
        {
            Quaternion bulletRotation = arm.transform.rotation * Quaternion.Euler(0, 0, -90); // Adjust the offset as needed.
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletRotation);
        }
        else if(gunType == Guntype.Shotgun)
        {
            //TODO MARY or JEN Create SpreadFire
            // Instantiate 3 bullet prebafs with three differecnt rotations
        }

    }

    private void RotateArm()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight)
            Flip();
        else if (mousePos.x > transform.position.x && !facingRight)
            Flip();

        Vector3 lookDir = mousePos - arm.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        if (facingRight)
            arm.transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        else
            arm.transform.rotation = Quaternion.Euler(180, 0, -angle + offset);
    }


}
