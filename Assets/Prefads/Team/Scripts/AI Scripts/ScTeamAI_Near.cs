using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must implement the necessary algorithm
///     - You must Change it to define the artiicial intelligence of this Team
/// </summary>
public class ScTeamAI_Near : MonoBehaviour {

    public GameObject Game;  // To access to the general object "Game"

    // Use this for initialization
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Start () {

        // We access to the general object "Game"
        Game = GameObject.FindWithTag("Game");

    }  // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// /////  void Update () {
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - Here we show how you can access the the information regarding the elements in game
    /// </summary>
    void Update () {

        // You can access to the information of all elementes in the game usinr sentences lake the following
    /*
        foreach (gameElement elementNear in Game.GetComponent<ScGameGlobalData>().listTeam_Near)
        {
            Vector3 posicion = elementNear.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In team Near : " +
                " - element Near - label : " + elementNear.giveToMeTag() +
                " - element Near - id : " + elementNear.giveToMeId() +
                " - element Near - Team : " + elementNear.giveToMeTeam() +
                " - element Near position x : " + posicion.x +
                " - element Near position z : " + posicion.z +
                " - element Near position y : " + posicion.y);
        }

        foreach (gameElement elementFar in Game.GetComponent<ScGameGlobalData>().listTeam_Far)
        {
            Vector3 posicion = elementFar.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In team Far : " +
                " - element Far - label : " + elementFar.giveToMeTag() +
                " - element Far - id : " + elementFar.giveToMeId() +
                " - element Far - Team : " + elementFar.giveToMeTeam() +
                " - element Far posicion x : " + posicion.x +
                " - element Far posicion z : " + posicion.z +
                " - element Far posicion y : " + posicion.y);
        }

        foreach (gameElement elementProfit in Game.GetComponent<ScGameGlobalData>().listProfits)
        {
            Vector3 posicion = elementProfit.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In profits : " +
                " - element profit - label : " + elementProfit.giveToMeTag() +
                " - element profit - id : " + elementProfit.giveToMeId() +
                " - element profit - Team : " + elementProfit.giveToMeTeam() +
                " - element profit posicion x : " + posicion.x +
                " - element profit posicion z : " + posicion.z +
                " - element profit posicion y : " + posicion.y);
        }
        */

    }  // FIn de - void Update()

}  // Fin de - public class ScTeamAI_Near : MonoBehaviour {
