using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class gameElement 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - Let you access to all the information you need about element in the game
/// </summary>
public class gameElement : MonoBehaviour
{

    public GameObject element; // 
    public int elementId; // If elementId=0, it is player - If elementId > 0, it is minion
    public int elementTeam; // if elementTeam = 1 it is "Team_Far"; else it is "Team_Near"

    public int giveToMeId()
    {
       return elementId;
    }
    public int giveToMeTeam()
    {
        return elementTeam;
    }
    public Vector3 giveToMePosition()
    {
        Vector3 elementPosition = element.transform.localPosition;
        return elementPosition;
    }
    public string giveToMeTag()
    {
        string elementTag = element.transform.tag;
        return elementTag;
    }
    public string giveToMeLabel()
    {
        string elementName = element.transform.name;
        return elementName;
    }

}  // Fin de - public class gameElement {
