using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject arm;
    [SerializeField] float offset = 90f; // Adjust this value if the default arm orientation isn't aligned.

    public PlayerStateMachine stateMachine { get; private set; }
    
    #region States
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion


    [SerializeField] GameObject bulletSpawnPoint;


    [SerializeField] GameObject bulletPrefab;

    public bool facingRight = true;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        arm = GameObject.FindGameObjectWithTag("Arm");
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update() 
    {
        stateMachine.currentState.Update();

        RotateArm();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        Quaternion bulletRotation = arm.transform.rotation * Quaternion.Euler(0, 0, -90); // Adjust the offset as needed.
        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletRotation);
    }

    private void RotateArm()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - arm.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        arm.transform.rotation = Quaternion.Euler(0, 0, angle + offset);

        if (mousePos.x < transform.position.x && facingRight)
            Flip();
        else if (mousePos.x > transform.position.x && !facingRight)
            Flip();
    }

    public void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

}
