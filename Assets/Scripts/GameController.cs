using System;
using System.Collections;
using TMPro;
using UnityEngine;

/*
 * TO-DO
 * Descriptions
 * 
 * L'Utilisation du VR
 *  Logique de Marteau (XR Interaction Toolkit)
 *  Intéraction entre marteau et taupe
 *  
 * Faire le UI en world space
 *  Créer dans Unity (Boutons, recommencer, etc)
 *  Faire les liens entre le text et le jeu
 *  
 * Fin de jeu
 * 
 * Son
 * 
 * Murs autour
 * 
 * Faire le build!
 */

/// <summary>
/// Pour gérer la logique de jeu de Whack-a-mole
/// </summary>
public class GameController : MonoBehaviour
{
    #region Variables
    //Gestion de jeu
    public bool partieEnCours = false;
    private int indexTaupe = 0;
    private int nombreFrappes = 0;
    private float chrono = 60.0f;
    private float tempsEntreTaupe = 1.6f;
    private int[] sequenceTaupe = { 2, 5, 8, 1, 0, 4, 7, 3, 6, 2, 8, 0, 1, 4, 5, 7,
        3, 6, 0, 2, 8, 4, 1, 5, 7, 3, 6, 0, 4, 2, 8, 1, 5, 7, 3, 0, 6, 4, 2, 1, 8,
        5, 7, 0, 3, 6, 4, 1, 2, 8, 5, 0, 7, 3, 6, 4, 2, 1, 8, 5, 0, 7, 3, 4, 6, 2,
        1, 0, 8, 5, 7, 3, 4, 6, 1, 2, 0, 8, 5, 7, 4, 3, 6, 1, 0, 2, 8, 5, 4, 7, 3,
        6, 1, 0, 5, 2, 8, 4, 7, 3, 6, 0, 1, 5, 2, 8, 4, 7, 0, 3, 6, 1, 5, 2, 4, 8,
        7, 0, 3, 6
    };


    //Prefab cases d'appartition
    [SerializeField, Tooltip("Liste des cases d'apparition de mole (0 à 8)")]
    public GameObject[] groupeCase;

    //Gestion du UI
    [Tooltip("Texte qui définie le temps")]
    public TextMeshProUGUI texteChrono;

    [Tooltip("Texte qui montre le nombre de mole touchés")]
    public TextMeshProUGUI nombreTaupesTouchees;
    /*
    [Tooltip("Texte d'instruction")]
    public TextMeshProUGUI instruction;
    [Tooltip("Texte d'instruction")]
    public TextMeshProUGUI endGameText;
    */
    //Gestion des Prefabs
    [Tooltip("Prefab du marteau")]
    public GameObject Prefab_marteau;
    [Tooltip("Prefab de la mole")]
    public GameObject Prefab_taupe;

    #endregion

    void Start()
    {
        CommencerPartie();
    }

    void Update()
    {
        //MAJChrono();
    }

    /// <summary>
    /// Pour mettre à jour le chronomètre et la difficulté avec le temps
    /// </IA>ToString("f0") par Gemini
    /// </summary>
    private void MAJChrono()
    {
        if (partieEnCours)
        {
            if (chrono > 0) chrono -= Time.deltaTime;
            if (chrono <= 0)
            {
                chrono = 0;
                partieEnCours = false;
            }

            if (chrono <= 15.0f) tempsEntreTaupe = 0.8f;
            else if (chrono <= 30.0f) tempsEntreTaupe = 1.2f;    
            
        }
        texteChrono.text = chrono.ToString("f0");
    }

    /// <summary>
    /// Pour commencer la partie
    /// </summary>
    public void CommencerPartie()
    {
        partieEnCours = true;
        StartCoroutine(GestionnaireDeTaupe());
    }

    /// <summary>
    /// Coroutine de création de taupe
    /// Crée une taupe à chaque [tempsEntreTaupe] secondes
    ///     à l'endroit déterminé par la [SéquenceTaupe]
    /// </summary>
    private IEnumerator GestionnaireDeTaupe()
    {
        while(partieEnCours && indexTaupe < sequenceTaupe.Length)
        {
            nouvelleTaupe();
            yield return new WaitForSeconds(tempsEntreTaupe);
        }
    }

    public void RecommencerPartie()
    {
        indexTaupe = 0;
        nombreFrappes = 0;
        tempsEntreTaupe = 1.0f;
        chrono = 60.0f;
        MAJChrono();

    }

    private void nouvelleTaupe()
    {
        int numeroCase= sequenceTaupe[indexTaupe];
        Vector3 positionCase = groupeCase[numeroCase].transform.position;
        GameObject taupe = Instantiate(Prefab_taupe, positionCase, Quaternion.identity);

        indexTaupe++;
    }

    public void AjouterNbFrappes()
    {
        nombreFrappes++;
        nombreTaupesTouchees.text = nombreFrappes.ToString();
    }
}
