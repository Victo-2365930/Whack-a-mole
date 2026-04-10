using UnityEngine;

/// <summary>
/// Pour controller la taupe
/// </summary>
public class Taupe : MonoBehaviour
{

    /// <summary>
    /// Pour détruire la taupe
    ///     Sera activé à la fin de l'animation
    /// </summary>
    public void DetruireTaupe()
    {
        Destroy(transform.parent.gameObject);
    }

}
