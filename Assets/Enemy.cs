using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoints = 2;
    bool hit;

    void Start(){

    }

    void Update(){
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(GameObject.Find("Player/Weapon")){
            hit = true;
            if(healthPoints > 0)
            {
                healthPoints =- 1;
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
            }   
            else if (healthPoints == 0)
            {
                healthPoints = 0;
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (GameObject.Find("Player/Weapon"))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            hit = false;
        }

    }
}