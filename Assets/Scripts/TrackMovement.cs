using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour {

    public float speed = 2;

    public Transform InitialPosition;
    public Transform EndPosition;

    public List<GameObject> Tracks;

    Vector3 movement;

    // Use this for initialization
    void Start () {
        movement = new Vector3(0, 0, speed * -1);
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Tracks.Count; i++)
        {
            if (Tracks[i].transform.position.z > EndPosition.transform.position.z)
                Tracks[i].transform.Translate(movement);
            else
                Tracks[i].transform.position = InitialPosition.position;
        }
	}
}
