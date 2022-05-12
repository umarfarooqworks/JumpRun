using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour
{
    public PathCreator Path;
    public int TotalDistance;
    int ditanceCovered;
    public GameObject PathPrefab;
    List<Transform> Platforms = new List<Transform>();
    public Transform Parent;

    private void Awake()
    {
        GameController.instance.CurrentTrack = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitTracksAlongPath();
    }

    void InitTracksAlongPath()
    {
        while (ditanceCovered < TotalDistance)
        {
            GameObject temp = Instantiate(PathPrefab, Parent); //
            temp.AddComponent<PathFollower>().pathCreator = Path;
            temp.GetComponent<PathFollower>().speed = 0f;
            temp.GetComponent<PathFollower>().distanceTravelled = ditanceCovered;
            ditanceCovered += 19;

            Platforms.Add(temp.transform);
        }

        Invoke(nameof(ResetRotations), 0.01f);
    }
    void ResetRotations()
    {
        foreach (Transform x in Platforms)
        {
            x.GetComponent<PathFollower>().enabled = false;
            x.rotation = Quaternion.identity;
        }
    }
}
