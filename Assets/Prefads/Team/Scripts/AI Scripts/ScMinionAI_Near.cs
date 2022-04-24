using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must call to the "public void moveOn(Vector3 directionForce, float movUnits)" in "ScMinionControl" to move the minion
///     - You must Change it to define the artiicial intelligence of this minion
/// </summary>
public class ScMinionAI_Near : MonoBehaviour {

    protected DateTime date_lastChamge;  // 
    protected double periodMilisec;

    protected Vector3 movement;  // Direction of the force that will be exerted on the gameobject
    protected float minionsMovUnits;  //  Amount of force that will be exerted on the gameobject


    // Use this for initialization
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Start () {

        date_lastChamge = DateTime.Now; // We initialize the date value
        periodMilisec = 1000f;  // We change each "periodoMiliseg"/1000 seconds

        movement = new Vector3(0.0f, 0.0f, 0.0f); // We initialize the date value
        minionsMovUnits = 1f; // We initialize the date value
    }  // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Update () {

    }  // FIn de - void Update()

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  FixedUpdate()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - You must Change it to define the artiicial intelligence of this player
    ///     - This one is only an example to manage the player
    /// </summary>
    void FixedUpdate()
    {
        custiodarProfit();
    }// Fin de - void FixedUpdate()

    void custiodarProfit(){

        float distanceToClosestPickUp = Mathf.Infinity;
        GameObject closestPickup = null;
        GameObject[] alltargets = GameObject.FindGameObjectsWithTag("Profit");
        GameObject[] allminions = GameObject.FindGameObjectsWithTag("Minion");
        bool near = true;

        //Calcula el Profit mas cercano y compruba si hay algun minion cerca de ese Profit
        foreach (GameObject currentPickup in alltargets)
        {
            if (currentPickup.activeInHierarchy)
            {
                float distanceToPickup = (currentPickup.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToPickup < distanceToClosestPickUp)
                {
                    foreach (GameObject currentMinion in allminions){
                        float distanceMinionPickup = (currentPickup.transform.position - currentMinion.transform.position).sqrMagnitude;
                        if (distanceMinionPickup < distanceToPickup)
                        {
                            near = false;
                            break;
                        }
                    }
                    if(near){
                        distanceToClosestPickUp = distanceToPickup;
                        closestPickup = currentPickup;
                    }
                    near = true;
                }
            }
        }

        if (closestPickup == null){
            //Perseguir player
        }else{
            //Custiodar Profit
            var lookPos = closestPickup.transform.position - this.transform.position;
            lookPos.y = 0;

            movement = lookPos;
            minionsMovUnits = ScGameGlobalData.maxMinionsMovUnits;
            GetComponent<ScMinionControl>().moveOn(movement, minionsMovUnits);
        }
    }// Fin   
    

}  // Fin de - public class ScMinionAI_Near : MonoBehaviour {
