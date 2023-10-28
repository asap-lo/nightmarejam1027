using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Properties")]
    public int maxHealth = 100;

    [Header("KnockBack Settings")]
    public float delay = 0.15f;

    [Header("Damage Flash Settings")]
    public FlashEffect flashEffect;

    [Header("Camera Shake")]
    public float shake_Duration = 0.1f;
    public float shake_Magnitude = .05f;
    protected Camera_Shake camShake;

    [Header("Debug")]
    public int currentHealth;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        flashEffect = GetComponent<FlashEffect>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Shake>();
    }

    #region Public Methods
    public virtual void TakeDamange(int amount, Transform damageSource, float knockback)
    {

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();

        }

        flashEffect.Flash(); // Flash Sprite
        //Knockback_FeedBack(damageSource, knockback);
        if (camShake != null)
        {
            StartCoroutine(camShake.Shake(shake_Duration, shake_Magnitude));
        }

    }
    public virtual void HealByAmount(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            //maybe play full health sound!
        }
    }

   


    #endregion


    #region Helper Methods


    protected virtual void Die()
    {
      //  GameObject particle = Instantiate(deathParticlesPrefab, this.transform.position, Quaternion.identity);
        //Destroy(particle, 2);
        Debug.Log("Enemy Died!");
        //GameEventSystem.current.EnemyDeath();

        Destroy(this.gameObject);
    }
    #endregion
}
