using UnityEngine;

/// <summary>
/// Pour controller la taupe
/// </summary>
public class Taupe : MonoBehaviour
{
    #region Variables

    private Renderer rendererCouleur;
    private Color couleurApresCoup = Color.green;
    public bool estFrappe = false;

    #endregion

    void Start()
    {
        rendererCouleur = GetComponent<Renderer>();
    }

    /// <summary>
    /// Pour changer la couleur de la taupe lorsque frappée
    ///     Sera activé par le marteau;
    /// </summary>
    public void TaupeFrappee()
    {
        if (!estFrappe)
        {
            estFrappe = true;
            rendererCouleur.material.color = couleurApresCoup;
        }       
    }

    /// <summary>
    /// Pour détruire la taupe
    ///     Sera activé à la fin de l'animation
    /// </summary>
    public void DetruireTaupe()
    {
        Destroy(transform.parent.gameObject);
    }


}
