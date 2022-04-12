using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class ScTeamControl
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - If you ned a random position in X and Z only. You mast to overwrite the Y coordinate of Vector3 returned
/// </summary>
public class ScTeamControl : MonoBehaviour {

    public GameObject Game;  // To access to the general object "Game"

    public GameObject Player; // For the player of this team
    public GameObject Minion; // For the minions of this team

    // Depending on the nuemroTeam value we are in team Near  (nuemroTeam = 1) or in team Far (nuemroTeam = 2)
    // See "ScGameControl => void Start ()"
    public int nuemroTeam;  

    // Use this for initialization
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  giveToMeRandomPosition()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - If you ned a random position in X and Z only. You mast to overwrite the Y coordinate of Vector3 returned
    /// Inputs :
    /// Outputs:
    /// </summary>
    void Start () {

        // We access to the general object "Game"
        Game = GameObject.FindWithTag("Game");

        // Data of the team
        Vector3 Team_init_localPosition = ScGameGlobalData.Team_Near_init_position; // Initial position (team Near)
        float incrementoPositonMinion = ScGameGlobalData.MinionScale.z *2f; // To locate the minion element
        string team = ScGameGlobalData.idTeam_Near; // To identify team Near

        if (nuemroTeam == 1)
        {
            Team_init_localPosition = ScGameGlobalData.Team_Far_init_position; // Initial position (team Far)
            incrementoPositonMinion = (-1f) * incrementoPositonMinion; // To locate the minion element
            team = ScGameGlobalData.idTeam_Far; // To identify team Far
        }  // Fin de - if (nuemroTeam == 2)

        // We generate the player element of this team
        GameObject objectPlayer = Instantiate(Player);  // Object generation
        objectPlayer.transform.localScale = ScGameGlobalData.PlayerScale;
        Team_init_localPosition.y = (1f / 2f) * ScGameGlobalData.PlayerScale.y; // we raise the player so that it is right on the ground
        objectPlayer.transform.localPosition = Team_init_localPosition;
        objectPlayer.name = "Player_" + team;
        objectPlayer.GetComponent<ScPlayerControl>().Team = team;

        // Now we add the player to the Team element list
        gameElement elementPlayer = new gameElement();
        elementPlayer.element = objectPlayer;

        elementPlayer.elementId = 0;  // If elementId=0, it is player - If elementId > 0, it is minion (except profits)
        elementPlayer.elementTeam = nuemroTeam;

        if (nuemroTeam == 1){Game.GetComponent<ScGameGlobalData>().listTeam_Near.Add(elementPlayer);}
        else if (nuemroTeam == 2){Game.GetComponent<ScGameGlobalData>().listTeam_Far.Add(elementPlayer);}
        else { Debug.Log("Error 001 in ScTeamControl "); }

        // Now we generate the minions of this team
        for (int i = 1; i< ScGameGlobalData.numOfMinions; i++)
        {   // We generate the minion element
            GameObject objectMinion = Instantiate(Minion);
            objectMinion.transform.localScale = ScGameGlobalData.MinionScale;
            float posicion_Z = Team_init_localPosition.z + i * incrementoPositonMinion;
            Vector3 Minion_init_position = new Vector3(0, (1f/2f) * ScGameGlobalData.MinionScale.y, posicion_Z);
            objectMinion.transform.localPosition = Minion_init_position;
            objectMinion.name = "minion_"+ team + "_"+i;
            objectMinion.GetComponent<ScMinionControl>().Team = team;
            // Now we add the player to the Team element list
            gameElement elementMinion = new gameElement();
            elementMinion.element = objectMinion;

            elementMinion.elementId = i;  // If elementId=0, it is player - If elementId > 0, it is minion
            elementMinion.elementTeam = nuemroTeam;

            if (nuemroTeam == 1) { Game.GetComponent<ScGameGlobalData>().listTeam_Near.Add(elementMinion); }
            else if (nuemroTeam == 2) { Game.GetComponent<ScGameGlobalData>().listTeam_Far.Add(elementMinion); }
            else { Debug.Log("Error 002 in ScTeamControl "); }

        }  // Fin de - for (int i = 1; i< ScGameGlobalData.numOfMinions; i++)

    }  // Fin de - void Start () {

    // Update is called once per frame
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  void Update ()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - Here we show how you can access the the information regarding the elements in game
    /// Inputs :
    /// Outputs:
    /// </summary>
    void Update () {

    }  // Fin de - void Update () {
}  // Fin de - public class ScTeamControl : MonoBehaviour {
