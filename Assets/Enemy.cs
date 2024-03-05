using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoints = 2;
    public int hit;

    // On hit, change color.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            switch (healthPoints)
            {
                case 2:
                    healthPoints -= 1;
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(170, 0, 0, 200);
                    transform.localScale *= 0.7f; // Make object smaller
                    print("Hit " + healthPoints);
                    break;
                case 1:
                    healthPoints -= 1;
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(70, 0, 0, 200);
                    transform.localScale *= 0.5f;
                    print("Hit " + healthPoints);
                    break;
                case 0:
                    healthPoints = 2;
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(10, 0, 0, 200);
                    transform.localScale *= 0.3f;
                    print("Hit " + healthPoints);
                    break;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        // TODO
    }


    void OnTriggerExit(Collider other)
    {
        // TODO
    }
}