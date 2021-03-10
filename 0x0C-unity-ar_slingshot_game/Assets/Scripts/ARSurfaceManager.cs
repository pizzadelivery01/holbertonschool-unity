using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSurfaceManager : MonoBehaviour
{
	public ARPlaneManager m_ARPlaneManager;
	public ARRaycastManager m_RaycastManager;
	public GameObject m_SearchingUI;
	public GameObject m_SelectUI;
	bool m_isPlanesFound = false;
	static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
	public GameObject m_startButton;
	

    // Start is called before the first frame update
    void Awake()
    {
        m_ARPlaneManager.planesChanged += OnPlanesChanged;
    }
	void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
	{
		if(!m_isPlanesFound && m_ARPlaneManager.trackables.count > 0)
		{
			OnPlanesFound();
		}
		else if (m_isPlanesFound && m_ARPlaneManager.trackables.count == 0)
		{
			OnPlanesExit();
		}
	}
	void OnPlanesFound()
	{
		m_isPlanesFound = true;
		m_SearchingUI.SetActive(false);
		m_SelectUI.SetActive(true);
	}
	void OnPlanesExit()
	{
		m_isPlanesFound = false;
		m_SearchingUI.SetActive(true);
		m_SelectUI.SetActive(false);
	}
	bool TryGetTouchPosition(out Vector2 touchPosition)
	{
		if (Input.touchCount > 0)
		{
			touchPosition = Input.GetTouch(0).position;
			return true;
		}
		touchPosition = default;
		return false;
	}
	void GameStart()
    {
        m_startButton.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (m_ARPlaneManager.enabled)
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (m_RaycastManager.Raycast(touchPosition, s_Hits))
            {
                m_ARPlaneManager.enabled = false;
                foreach (ARPlane plane in m_ARPlaneManager.trackables)
                {
                    if (plane.trackableId != s_Hits[0].trackableId)
                    {
                        plane.gameObject.SetActive(false);
                    }
					else
                    {
                        plane.GetComponent<NavMeshBuilder>().Select();
                    }
                }
                m_SelectUI.SetActive(false);
                m_startButton.SetActive(true);
                Button btn = m_startButton.GetComponent<Button>();
                btn.onClick.AddListener(GameStart);
            }
        }
	}
}