using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayerWeapon"))
        {
            GetComponent<Material>().color = Color.white;
        }
    }
}
