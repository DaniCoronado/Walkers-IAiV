using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  Control Minion Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must call to the "public void moveOn(Vector3 directionForce, float movUnits)" to move the minion from 
///     the "ScMinionAI" script
/// </summary>
public class ScMinionControl : MonoBehaviour {

    private Rigidbody rb;  // To acceses to the rigid body of the player

    public string Team = "";  // team to which it belongs "team_1" or "team_2" 

    // Use this for initialization
    void Start()
    {
        // We acceses to the rigid body of the player
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  moveOn(Vector3 directionForce, float movUnits)
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - You must call to this method from the "ScMinionAI" script to move the minion from 
    /// Inputs :
    ///     - Vector3 directionForce - The direction of the force that will be applied
    ///     - movUnits - The quantity  of the force that will be applied
    /// Outputs:
    ///     - No outputs
    /// </summary>
    public void moveOn(Vector3 directionForce, float movUnits)
    {
        // Tu limit the maximun of playersMovUnits
        if (movUnits > ScGameGlobalData.maxPlayersMovUnits) { movUnits = ScGameGlobalData.maxMinionsMovUnits; }
        if (movUnits < (-1f) * ScGameGlobalData.maxPlayersMovUnits) { movUnits = (-1f) * ScGameGlobalData.maxMinionsMovUnits; }
        // We normalize the direction vector
        Vector3 normalized_directionForce = directionForce.normalized;
        // We applied the force
        rb.AddForce(normalized_directionForce * movUnits);
    }  // Fin de - public void moveOn(Vector3 directionForce, float movUnits)

}  // Fin de - public class ScMinionControl : MonoBehaviour {
