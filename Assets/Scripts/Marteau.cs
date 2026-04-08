using UnityEngine;

public class Marteau : MonoBehaviour
{
    #region Variables

    public GameController controller;

    #endregion

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Taupe"))
        {
            Taupe scriptTaupe = other.GetComponent<Taupe>();
            if (scriptTaupe) scriptTaupe.TaupeFrappee();
        }
    }

}
