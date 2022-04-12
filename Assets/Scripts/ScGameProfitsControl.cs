using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class ScGameProfitsControl
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - Profits control
/// </summary>
public class ScGameProfitsControl : MonoBehaviour {

    public GameObject Game;  // To access the general object "Game"

    public GameObject profit;  // To access the "Profit" asset

    // Use this for initialization
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  void Start ()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - We generate initial profits 
    /// Inputs :
    /// Outputs:
    /// </summary>
    void Start () {

        // We assign the game objects
        Game = GameObject.FindWithTag("Game");

        // /////////////////////////////////////
        // /////////////////////////////////////
        // /////////////////////////////////////
        // We generate the initial profits

        for (int i=0; i < ScGameGlobalData.numProfits; i++)
        {
            generateNewProfit();

        }  // Fin de - for (int i=0; i < ScGameGlobalData.numProfits; i++)

    }  // Fin de - void Start () {

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  generateNewProfit() 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - we generate new profits 
    /// Inputs :
    /// Outputs:
    /// </summary>
    public void generateNewProfit()
    {

        Game.GetComponent<ScGameGlobalData>().numGenerateProfits++;

        // We generate the gameObject profit 
        GameObject otherProfit = Instantiate(profit);
        // We generate its scale
        otherProfit.transform.localScale = ScGameGlobalData.ProfitScale;
        // We generate its position randomly
        otherProfit.GetComponent<ScProfitControl>().relocateProfit();

        // Now we add the profit to the profit element list
        gameElement elementProfit = new gameElement();
        elementProfit.element = otherProfit;

        elementProfit.elementId = Game.GetComponent<ScGameGlobalData>().numGenerateProfits;  // If elementId=0, it is player - If elementId > 0, it is minion
        elementProfit.elementTeam = 0;  // In profits nuemroTeam = 0;

        Game.GetComponent<ScGameGlobalData>().listProfits.Add(elementProfit);
    }  // Fin de - public void moveOn(Vector3 directionForce, float movUnits)

}  // Fin de - public class ScGameProfitsControl : MonoBehaviour {
