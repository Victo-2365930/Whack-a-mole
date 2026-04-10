using UnityEngine;

/// <summary>
/// Pour controller la taupe
/// Sons à partir des notes de cours de Frédérik Taleb
/// https://envimmersif-cegepvicto.github.io/exercice_feedback_vr/
/// </summary>
public class Taupe : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField, Tooltip("Son lors de l'apparition de la taupe")] 
    private AudioClip sonDebut;
    [SerializeField, Tooltip("Son lors de la sortie de la taupe")]
    private AudioClip sonSortie;
    public bool aDetruire = false;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1f; // 100% 3D
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 5f;
    }

    private void Start()
    {
        audioSource.PlayOneShot(sonDebut);
    }

    /// <summary>
    /// Pour rendre le booléen à true
    /// </summary>
    public void MarquerCommeFrappee()
    {
        aDetruire = true;
    }

    /// <summary>
    /// Pour lancer le célèbre son de Franck Leboeuf
    /// </summary>
    public void FranckLeboeuf()
    {
        audioSource.PlayOneShot(sonSortie);
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
