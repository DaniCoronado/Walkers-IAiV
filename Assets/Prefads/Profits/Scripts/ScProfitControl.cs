using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class ScProfitControl
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - Management of the Profits
/// </summary>
public class ScProfitControl : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  generateNewProfit() 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - We rotate the profits in the space
    /// Inputs :
    /// Outputs:
    /// </summary>
    void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }  // Fin de - void Update () {

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  generateNewProfit() 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    /// Inputs :
    ///     
    /// Outputs:
    ///     - No outputs
    /// </summary>
    public void relocateProfit()
    {
        Vector3 profitLocalPosition = ScGameControl.giveToMeRandomPosition();
        profitLocalPosition.y = ScGameGlobalData.profitLocalPosition_y; // Y coordinate is not random
        transform.localPosition = profitLocalPosition;
    }  // Fin de - public void relocateProfit()

}  // Fin de - public class ScProfitControl : MonoBehaviour {
