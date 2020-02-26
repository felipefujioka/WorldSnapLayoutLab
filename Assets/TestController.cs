using System.Collections;
using System.Linq;
using Cinemachine;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public SnapLayoutElement ElementPrefab;
    public SnapLayout layout;
    public CinemachineSmoothPath cameraPath;
    public CinemachineVirtualCamera vCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunTest());
        
    }

    private IEnumerator RunTest()
    {
        for (int i = 0; i < 20; i++)
        {
            var instance = layout.AddElement(ElementPrefab);

            var waypointsList = cameraPath.m_Waypoints.ToList();

            var lastWaypoint = waypointsList.Last();

            var newWaypoint = new CinemachineSmoothPath.Waypoint();
            newWaypoint.position = lastWaypoint.position + new Vector3(0, 0, instance.ElementHeight()); 
            
            waypointsList.Add(newWaypoint);

            cameraPath.m_Waypoints = waypointsList.ToArray();

            Camera.main.transform.DOMove(cameraPath.EvaluatePosition(waypointsList.Count), 1.5f).Play()
                .OnComplete(() => { Camera.main.transform.DOMove(cameraPath.EvaluatePosition(0), 1.5f).Play(); });
            
            yield return new WaitForSecondsRealtime(5f);
        }
    }
}
