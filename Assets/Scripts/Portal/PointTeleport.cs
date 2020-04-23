using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//把這個元件裝在一個點上
public class PointTeleport : MonoBehaviour
{
    public BezierPoint destinationPoint;
    public int nextScenePointIndex = 0;
    public int targetScene = -1;

    void Start()
    {

    }

    public BezierPoint teleportToDestinationPoint()
    {
        if (targetScene >= 0)
        {
            PlayerControll.atPoint = nextScenePointIndex;
            SceneManager.LoadScene(targetScene);
        }
        return destinationPoint != null && this.enabled ? destinationPoint : this.GetComponent<BezierPoint>();
    }
}
