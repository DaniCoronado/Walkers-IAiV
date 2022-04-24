using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  ARTIFICIAL INTELLIGENCE  player Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must call to the "public void moveOn(Vector3 directionForce, float movUnits)" in "ScPlayerControl" to move the player 
///     - You must Change it to define the artiicial intelligence of this player
/// </summary>
[ExecuteInEditMode]
public class ScPlayerAI_Near : MonoBehaviour {


    GameObject Pepe;

    DateTime date_lastChamge;
    protected double periodMilisec;

    protected Vector3 movement;  // Direction of the force that will be exerted on the gameobject
    protected float playersMovUnits;  //  Amount of force that will be exerted on the gameobject


    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Start()
    {
        date_lastChamge = DateTime.Now; // We initialize the date value
        periodMilisec = 1000f;  // We change each "periodoMiliseg"/1000 seconds

        movement = new Vector3(0.0f, 0.0f, 0.0f); // We initialize the date value
        playersMovUnits = 1f; // We initialize the date value

        Pepe = GameObject.Find("Player_Near");
    }  // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Update()
    {
        
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
        CalculaMinimo();

        //    Every "timeWhitoutChange_ms" milliseconds we modify the value of "movement" and "minionsMovUnits"
        //DateTime dateNow = DateTime.Now;
        //    TimeSpan timeWhitoutChange = dateNow - date_lastChamge;

        //    double timeWhitoutChange_ms = timeWhitoutChange.TotalMilliseconds;

        //    if (ScGameGlobalData.Team_Near_Control == "manual")
        //    {
        //        float moveHorizontal = Input.GetAxis("Horizontal");
        //        float moveVertical = Input.GetAxis("Vertical");

        //        float moveHorizontal = 0;
        //        float moveVertical = 0;
        //        if (Input.GetKeyDown("i")) { moveVertical = 1f; }
        //        if (Input.GetKeyDown("k")) { moveVertical = -1f; }
        //        if (Input.GetKeyDown("j")) { moveHorizontal = -1f; }
        //        if (Input.GetKeyDown("l")) { moveHorizontal = 1f; }

        //        We calculate the direction and quantity of movement
        //        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //        playersMovUnits = 25f;
        //    } // Fin de - if (ScGameGlobalData.Team_Near_Control == "manual")
        //    else if (ScGameGlobalData.Team_Near_Control == "randon")
        //    {
        //        if (timeWhitoutChange_ms > periodMilisec)
        //        {
        //            We calculate the direction and quantity of movement
        //             We obtain "movement" and "minionsMovUnits" randonly
        //            float move_X = Random.Range(-1.0f, 1f);
        //            float move_Z = Random.Range(-1f, 1f);
        //            playersMovUnits = Random.Range(0.0f, 1f);

        //            playersMovUnits = playersMovUnits * ScGameGlobalData.maxPlayersMovUnits;
        //            movement = new Vector3(move_X, 0.0f, move_Z);

        //            date_lastChamge = dateNow;  // We actualizate date_lastChamge
        //        }
        //    } // Fin de - else if (ScGameGlobalData.Team_Near_Control == "randon")
        //    else if (ScGameGlobalData.Team_Near_Control == "randon")
        //    {
        //        Debug.Log("From ScPlayerAI_Near => FixedUpdate => AI is not programated");
        //    }// Fin de - else if (ScGameGlobalData.Team_Near_Control == "randon")
        //    else { Debug.Log("From ScPlayerAI_Near => FixedUpdate => Error 001"); }

        //    CALlING TO THIS FUNCTION YOU CAN MANAGE THE ELEMENT WITH THE ARTIFICIAL INTELLIGENCE THAT YOU MUST DEVELOP
        //    GetComponent<ScPlayerControl>().moveOn(movement, playersMovUnits);
        //}  // Fin de - void FixedUpdate()
    }


    void CalculaMinimo()
    {
        //metemos a el player a la layer de ignore raycast para que no se detecte a si misma en las colisiones
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        Pepe.layer = LayerIgnoreRaycast;
        Debug.Log("Current layer: " + gameObject.layer);
        //iniciamos el closest pick up infinito para ir comparando cual esta mas cerca
        //tambien inicializamos un array con todos los profits que se pueden coger
        float distanceToClosestPickUp = Mathf.Infinity;
        float distanceToPickup;
        GameObject closestProfit = null;
        GameObject[] alltargets = GameObject.FindGameObjectsWithTag("Profit");
        //recorremos el array de proffits 
        foreach (GameObject currentProfit in alltargets)
        {   
            //metemos al proffit en la layer que no detecta colisiones para luego
            currentProfit.layer = LayerIgnoreRaycast;
            if (currentProfit.activeInHierarchy)
            {
                //hacemos la comparacion para poder comparar cual esta mas cerca
                distanceToPickup = (currentProfit.transform.position - this.transform.position).sqrMagnitude;
                //si el que esta mas cerca notiene ningun minion en medio comprobando las colisiones con las layers lo guardamos como objetivo
                if (distanceToPickup < distanceToClosestPickUp && !Physics.Linecast(this.transform.position, currentProfit.transform.position))
                {
                    distanceToClosestPickUp = distanceToPickup;
                    closestProfit = currentProfit;
                }
            }
        }
        // si ningun target esta libre de minions por el medio vamos al primer target del array de profits para que no se quede quieto 
        if((alltargets[0].transform.position - this.transform.position).sqrMagnitude== Mathf.Infinity)
        {
            distanceToPickup = (alltargets[0].transform.position - this.transform.position).sqrMagnitude;
            distanceToClosestPickUp = distanceToPickup;
            closestProfit = alltargets[0];
        }

        Debug.DrawLine(this.transform.position, closestProfit.transform.position);


        playersMovUnits = playersMovUnits * ScGameGlobalData.maxPlayersMovUnits;


        GetComponent<ScPlayerControl>().moveOn((closestProfit.transform.position - this.transform.position), playersMovUnits);
        
        
            
        
    }

}  // Fin de - public class ScPlayerAI_Near : MonoBehaviour {
