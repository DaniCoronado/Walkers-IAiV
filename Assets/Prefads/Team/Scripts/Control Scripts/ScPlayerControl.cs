using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  Control player Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must call to the "public void moveOn(Vector3 directionForce, float movUnits)" to move the player from 
///     the "ScPlayerAI_xx" script
/// </summary>
public class ScPlayerControl : MonoBehaviour
{
    public GameObject Game;
    private Rigidbody rb;  // To acceses to the rigid body of the player

    public string Team;  // team to which it belongs "team_1" or "team_2" 

    // Use this for initialization
    void Start()
    {
        // Asignamos objetos
        Game = GameObject.FindWithTag("Game");

        // We acceses to the rigid body of the player
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  moveOn(Vector3 directionForce, float movUnits)
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - You must call to this method from the "ScPlayerAI_xx" script to move the player from 
    /// Inputs :
    ///     - Vector3 directionForce - The direction of the force that will be applied
    ///     - movUnits - The quantity  of the force that will be applied
    /// Outputs:
    ///     - No outputs
    /// </summary>
    public void moveOn(Vector3 directionForce, float movUnits)
    {
        // Tu limit the maximun of playersMovUnits
        if (movUnits > ScGameGlobalData.maxPlayersMovUnits) { movUnits = ScGameGlobalData.maxPlayersMovUnits; }
        if (movUnits < (-1f) * ScGameGlobalData.maxPlayersMovUnits) { movUnits = (-1f) * ScGameGlobalData.maxPlayersMovUnits; }
        // We normalize the direction vector
        Vector3 normalized_directionForce = directionForce.normalized;
        // We applied the force
        rb.AddForce(normalized_directionForce * movUnits);
    }  // Fin de - public void moveOn(Vector3 directionForce, float movUnits)

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  OnTriggerEnter(Collider other)
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - This script is executed automatically when another object (Collider other) collides with this one 
    ///     - You don't need to call to this function. You only need to program it and when there is a collision, the system
    ///         call to the function
    /// Inputs :
    ///     - Collider other : It is the object that collides with this one
    /// Outputs:
    ///     - No outputs
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // When "other" is a Profit
        if (other.gameObject.CompareTag("Profit"))
        {
            // We manage the set of active profits
            other.GetComponent<ScProfitControl>().relocateProfit();
            Game.GetComponent<ScGameGlobalData>().numGenerateProfits++;
            // We manage the score
            if (Team == ScGameGlobalData.idTeam_Near){Game.GetComponent<ScGameGlobalData>().profitsPlayer_Near++;}
            else if (Team == ScGameGlobalData.idTeam_Far) { Game.GetComponent<ScGameGlobalData>().profitsPlayer_Far++; }
            else { Debug.Log(" Error 001 en ScPlayerControl"); }
        }
        // When "other" is a Minion
        else if (other.gameObject.CompareTag("Minion"))
        {
            // We manage the lives
            if (Team != other.GetComponent<ScMinionControl>().Team)
            {
                Debug.Log(" desde triger con team = " + Team +" - y el otro = " + other.GetComponent<ScMinionControl>().Team);
                if (Team == ScGameGlobalData.idTeam_Near) { Game.GetComponent<ScGameGlobalData>().livesPlayer_Near--; }
                else if (Team == ScGameGlobalData.idTeam_Far) { Game.GetComponent<ScGameGlobalData>().livesPlayer_Far--; }
                else { Debug.Log(" Error 002 en ScPlayerControl"); }
            }
        }
        else { Debug.Log(" Error 003 en ScPlayerControl"); }
    }  // Fin de -  private void OnTriggerEnter(Collider other)

}  // Fin de - public class ScPlayerControl : MonoBehaviour
