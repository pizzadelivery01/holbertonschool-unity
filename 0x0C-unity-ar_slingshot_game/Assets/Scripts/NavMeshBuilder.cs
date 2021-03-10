using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Builds NavMesh during runtime.
/// </summary>
public class NavMeshBuilder : MonoBehaviour
{
    NavMeshSurface surface;
    ARPlane plane;

    void Start()
    {
        plane = GetComponent<ARPlane>();
        surface = GetComponent<NavMeshSurface>();
    }

    /// <summary>
    /// Subscribes to boundary changes to rebuild the NavMesh.
    /// </summary>
    public void Select()
    {
        surface.BuildNavMesh();
        plane.boundaryChanged += BuildNavMesh;
    }

    void BuildNavMesh(ARPlaneBoundaryChangedEventArgs e)
    {
        surface.BuildNavMesh();
    }
    
}