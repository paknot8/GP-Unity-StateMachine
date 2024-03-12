using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Basic Variables
        public float healthPoints = 2;
        public float cooldownTimer = 1;
        public float pushForce = 3;
        public float pushFriction = 2;
        public float maxKnockbackHeight = 5;
        public float collisionCooldown = 0.5f;
        protected bool isKnockedBack = false;
        protected bool isCollisionCooldown = false;
    #endregion

    protected virtual void Update()
    {
        if (isKnockedBack) KnockBack();
        MaxHeightAfterCollisionWithWeapon();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !isCollisionCooldown)
        {
            ApplyForce();
            switch (healthPoints)
            {
                case 2: UpdateHit(new Color32(170, 0, 0, 200), 0.8f); break;
                case 1: UpdateHit(new Color32(70, 0, 0, 200), 0.6f); break;
                case 0: UpdateHit(new Color32(10, 0, 0, 200), 0.2f); Invoke(nameof(DestroyObject), cooldownTimer); break;
            }
            // StartCooldown(nameof(isCollisionCooldown)); // Old Code
            StartCoroutine(StartCooldown(collisionCooldown, nameof(isCollisionCooldown)));
        }
    }

    protected void UpdateHit(Color32 color, float scaleMultiplier)
    {
        GetComponent<MeshRenderer>().material.color = color;
        transform.localScale *= scaleMultiplier;
        print("Damage taken Enemy HP = " + healthPoints--);
    }

    protected IEnumerator StartCooldown(float cooldownTime, string cooldownType)
    {
        yield return new WaitForSeconds(cooldownTime);
        EndCooldown(cooldownType);
    }

    protected void EndCooldown(string cooldownType)
    {
        if (cooldownType == nameof(isCollisionCooldown))
            isCollisionCooldown = false;
    }

    protected void ApplyForce()
    {
        Vector3 pushDirection = transform.forward;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);
        isKnockedBack = true;
    }

    protected void DestroyObject() => Destroy(gameObject);

    protected void KnockBack()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity -= pushFriction * Time.deltaTime * rb.velocity;

        if (rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;
            isKnockedBack = false;
        }
    }

    protected void MaxHeightAfterCollisionWithWeapon()
    {
        if (transform.position.y > maxKnockbackHeight)
            transform.position = new Vector3(transform.position.x, maxKnockbackHeight, transform.position.z);
    }

    protected virtual void OnTriggerStay(Collider other){}
    protected virtual void OnTriggerExit(Collider other){}
}