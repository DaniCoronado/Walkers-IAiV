using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  public class ScMainCameraControl
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - Controls of the main camera
/// </summary>
public class ScMainCameraControl : MonoBehaviour {

    public static float cameraPosition_X = 0;
    public static float cameraPosition_Y = (1f / 2.5f) * ScGameGlobalData.GS_scale_Z * 10f;
    public static float cameraPosition_Z = (-1f / 1.5f) * ScGameGlobalData.GS_scale_Z * 10f;
    public static Vector3 cameraPosition = new Vector3(cameraPosition_X, cameraPosition_Y, cameraPosition_Z);

    public static Quaternion cameraRotation = Quaternion.Euler(45f, 0f, 0f);

    // Use this for initialization
    /// <summary>
    /// ///////////  void Start ()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - Putting the camera in place
    /// </summary>
    void Start () {
        transform.localPosition = cameraPosition;
        transform.localRotation = cameraRotation;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
