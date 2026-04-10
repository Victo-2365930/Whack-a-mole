using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Pour mettre les feedback haptics sur la Marteau
/// À partir des notes de cours de Frédérik Taleb
/// https://envimmersif-cegepvicto.github.io/exercice_feedback_vr/
/// </summary>
[RequireComponent(typeof(XRGrabInteractable))]
public class FeedbackHaptics : MonoBehaviour
{
    [Header("Haptique")]
    [SerializeField, Tooltip("Amplitude de la vibration")] private float amplitudeGrab = 0.5f;
    [SerializeField, Tooltip("Temps de vibration")] private float dureeGrab = 0.1f;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabEntered);
        grabInteractable.selectExited.AddListener(OnGrabExited);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabEntered);
        grabInteractable.selectExited.RemoveListener(OnGrabExited);
    }

    private void OnGrabEntered(SelectEnterEventArgs args)
    {
        // Récupérer le contrôleur depuis l'interactor
        var controller = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        controller.SendHapticImpulse(amplitudeGrab, dureeGrab);
    }

    public void OnFrappeTaupe(SelectEnterEventArgs args)
    {
        // Récupérer le contrôleur depuis l'interactor
        var controller = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        controller.SendHapticImpulse(amplitudeGrab, dureeGrab);
    }

    private void OnGrabExited(SelectExitEventArgs args)
    {
        // Vibration plus courte et moins forte au relâchement
        var controller = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        controller.SendHapticImpulse(amplitudeGrab * 0.3f, dureeGrab * 0.5f);
    }

}
