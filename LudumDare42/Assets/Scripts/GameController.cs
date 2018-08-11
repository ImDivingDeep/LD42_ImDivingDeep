using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject _player;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {

        _player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -15.0f);

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.WorldToViewportPoint(_player.transform.position);

        Debug.Log(pos);

        if (pos.x < 0.3f) MoveCamera(new Vector2(-1, 0));
        else if (0.7f < pos.x) MoveCamera(new Vector2(1, 0));
        if (pos.y < 0.3f) MoveCamera(new Vector2(0, -1));
        else if (0.7f < pos.y) MoveCamera(new Vector2(0, 1));

    }

    void MoveCamera(Vector2 dir)
    {
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, Camera.main.transform.position + new Vector3(dir.x * 3, dir.y * 3, 0.0f), ref velocity, 0.4f);
    }
}
