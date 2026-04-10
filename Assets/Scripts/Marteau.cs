using UnityEngine;

public class Marteau : MonoBehaviour
{
    public GameController controller;

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Taupe"))
        {
            controller.AjouterNbFrappes();
            Destroy(other.gameObject);
        }
    }

}
