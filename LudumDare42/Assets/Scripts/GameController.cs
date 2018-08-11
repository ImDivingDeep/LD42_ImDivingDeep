using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject _player;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {

        _player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.WorldToViewportPoint(_player.transform.position);

        Debug.Log(pos);

        if (pos.x < 0.3) MoveCamera(new Vector2(-1, 0));
        if (0.7 < pos.x) MoveCamera(new Vector2(1, 0));
        if (pos.y < 0.3) MoveCamera(new Vector2(0, -1));
        if (0.7 < pos.y) MoveCamera(new Vector2(0, 1));

    }

    void MoveCamera(Vector2 dir)
    {
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, Camera.main.transform.position + new Vector3(dir.x, dir.y, 0.0f), ref velocity, 0.6f);
    }
}
