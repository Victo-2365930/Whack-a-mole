using UnityEngine;

public class VRPlacement : MonoBehaviour
{
    /*
     * Changer GetMouseButton pour le controle de main
     * 
     * 
     */

    public GameController controller;
    private bool marteauEnMain = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Marteau"))
                {
                    marteauEnMain = true;
                    //CaseData donnees = hit.collider.GetComponent<CaseData>();
                    //controller.JouerTour(donnees.indexCase, hit.collider);
                }
                else
                {
                    marteauEnMain=false;
                }
                
            }
        }
    }
}
