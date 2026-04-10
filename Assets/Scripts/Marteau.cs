using UnityEngine;

public class Marteau : MonoBehaviour
{
    public GameController controller;
    public FeedbackHaptics haptics;

    /// <summary>
    /// Pour gérer l'intéraction du marteau avec les autres gameobjects
    /// </summary>
    /// <param name="other">Le gameObject touché par le marteau</param>
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Taupe"))
        {
            Taupe taupe = other.GetComponent<Taupe>();

            if (!taupe.aDetruire)
            {
                taupe.MarquerCommeFrappee();
                controller.AjouterNbFrappes();
            }

            Destroy(other.gameObject);
        }
    }

}
