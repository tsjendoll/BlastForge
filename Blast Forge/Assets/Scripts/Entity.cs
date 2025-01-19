using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int facingDir {get; private set; } = 1;
    protected bool facingRight = true;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        Debug.Log(rb);
    }

    protected virtual void Damage(int damageAmount)
    {

    }

    public void SetVelocity(float XVelocity, float YVelocity)
    {
        rb.velocity = new Vector2(XVelocity, YVelocity);
    }
    
    public void setZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
