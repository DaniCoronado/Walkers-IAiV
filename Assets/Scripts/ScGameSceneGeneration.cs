using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class ScGameSceneGeneration
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - We generate the scene procedurally
/// </summary>
public class ScGameSceneGeneration : MonoBehaviour {

    public GameObject Game;
    public Material SceneMaterial;
    public Material SceneMatTransp;


    // Use this for initialization
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  void Start ()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - Scene generation
    /// </summary>
    void Start () {

    // Asignamos objetos
    Game = GameObject.FindWithTag("Game");


        // /////////////////////////////////////
        // /////////////////////////////////////
        // /////////////////////////////////////
        // We generate the play space

        // /////////////////////////////////////
        // /////////////////////////////////////
        // We generate the plane of the floor of the space game

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        // A plane in Unity is made up of 10x10 tiles, each one will be of the scale that is defined, so
        //  - At X the plane will measure = 10*ScGameGlobalData.GS_scale_X
        //  - At Z the plane will measure = 10*ScGameGlobalData.GS_scale_X
        //  - In Y the plane is not scaled, since it is a two-dimensional object (x,z)

        // Floor
        Vector3 planeEscale = new Vector3(ScGameGlobalData.GS_scale_X, ScGameGlobalData.GS_scale_Y, ScGameGlobalData.GS_scale_Z);
        plane.transform.localScale = planeEscale;
        plane.transform.position = new Vector3(0, 0, 0); // Plane is located on (0,0,0)
        plane.transform.SetParent(transform);  // We make "plane" child of "GameSpace", which is who is executing the script
            // We assign the material
        Renderer reprod = plane.GetComponent<Renderer>();
        reprod.material = SceneMaterial;

        // /////////////////////////////////////
        // /////////////////////////////////////
        // We generate the walls of the space game

        // wall_Near 
        GameObject wall_Near = GameObject.CreatePrimitive(PrimitiveType.Cube);  // we generate the wall
        wall_Near.transform.SetParent(plane.transform);  // We make "wall_Far" child of "plane"
//        Vector3 wall_FarLocalEscale = new Vector3(ScGameGlobalData.GS_scale_X, 5*ScGameGlobalData.GS_scale_Y, (-1f / 200f)*ScGameGlobalData.GS_scale_Z);
        Vector3 wall_FarLocalEscale = new Vector3(ScGameGlobalData.GS_scale_X, 30f * ScGameGlobalData.GS_scale_Y, (-1f / 200f) * ScGameGlobalData.GS_scale_Z);
        wall_Near.transform.localScale = wall_FarLocalEscale;
        Vector3 wall_FarLocalPosition = new Vector3(0, (30f/2f) * ScGameGlobalData.GS_scale_Y, (-1f/4f)*ScGameGlobalData.GS_scale_Z);
        wall_Near.transform.localPosition = wall_FarLocalPosition;
        wall_Near.AddComponent<Rigidbody>();
        wall_Near.GetComponent<Rigidbody>().useGravity = false;
        wall_Near.GetComponent<Rigidbody>().isKinematic = true;
        wall_Near.name = "wall_Near";
        // We assign the material (THIS IS ANOTHER NATERIAL)
        Renderer reprodTransp = wall_Near.GetComponent<Renderer>();
        reprodTransp = wall_Near.GetComponent<Renderer>();
        reprodTransp.material = SceneMatTransp;


        // wall_Right 
        GameObject wall_Right = GameObject.CreatePrimitive(PrimitiveType.Cube);  // we generate the wall
        wall_Right.transform.SetParent(plane.transform);  // We make "wall_Far" child of "plane"
        Vector3 wall_RightLocalEscale = new Vector3((-1f / 200f) * ScGameGlobalData.GS_scale_X, 30 * ScGameGlobalData.GS_scale_Y, (1f / 2f) * ScGameGlobalData.GS_scale_Z);
        wall_Right.transform.localScale = wall_RightLocalEscale;
        Vector3 wall_RightLocalPosition = new Vector3((1f/2f) * ScGameGlobalData.GS_scale_X, (30f / 2f) * ScGameGlobalData.GS_scale_Y, 0);
        wall_Right.transform.localPosition = wall_RightLocalPosition;
        wall_Right.AddComponent<Rigidbody>();
        wall_Right.GetComponent<Rigidbody>().useGravity = false;
        wall_Right.GetComponent<Rigidbody>().isKinematic = true;
        wall_Right.name = "wall_Right";
        // We assign the material
        reprod = wall_Right.GetComponent<Renderer>();
        reprod.material = SceneMaterial;

        // wall_Left 
        GameObject wall_Left = GameObject.CreatePrimitive(PrimitiveType.Cube);  // we generate the wall
        wall_Left.transform.SetParent(plane.transform);  // We make "wall_Far" child of "plane"
        Vector3 wall_LeftLocalEscale = new Vector3((-1f / 200f) * ScGameGlobalData.GS_scale_X, 30 * ScGameGlobalData.GS_scale_Y, (1f / 2f) * ScGameGlobalData.GS_scale_Z);
        wall_Left.transform.localScale = wall_LeftLocalEscale;
        Vector3 wall_LeftLocalPosition = new Vector3((-1f / 2f) * ScGameGlobalData.GS_scale_X, (30f / 2f) * ScGameGlobalData.GS_scale_Y, 0);
        wall_Left.transform.localPosition = wall_LeftLocalPosition;
        wall_Left.AddComponent<Rigidbody>();
        wall_Left.GetComponent<Rigidbody>().useGravity = false;
        wall_Left.GetComponent<Rigidbody>().isKinematic = true;
        wall_Left.name = "wall_Left";
        // We assign the material
        reprod = wall_Left.GetComponent<Renderer>();
        reprod.material = SceneMaterial;

        // wall_Far 
        GameObject wall_Far = GameObject.CreatePrimitive(PrimitiveType.Cube);  // we generate the wall
        wall_Far.transform.SetParent(plane.transform);  // We make "wall_Far" child of "plane"
        Vector3 wall_NearLocalEscale = new Vector3(ScGameGlobalData.GS_scale_X, 30 * ScGameGlobalData.GS_scale_Y, (-1f / 200f) * ScGameGlobalData.GS_scale_Z);
        wall_Far.transform.localScale = wall_NearLocalEscale;
        Vector3 wall_NearLocalPosition = new Vector3(0, (30f / 2f) * ScGameGlobalData.GS_scale_Y, (1f / 4f) * ScGameGlobalData.GS_scale_Z);
        wall_Far.transform.localPosition = wall_NearLocalPosition;
        wall_Far.AddComponent<Rigidbody>();
        wall_Far.GetComponent<Rigidbody>().useGravity = false;
        wall_Far.GetComponent<Rigidbody>().isKinematic = true;
        wall_Far.name = "wall_Far";
        // We assign the material
        reprod = wall_Far.GetComponent<Renderer>();
        reprod.material = SceneMaterial;

    }  // Fin de - void Start () {

    // Update is called once per frame
    void Update () {
		
	}

}  // Fin de - public class ScGameSceneGeneration : MonoBehaviour {
