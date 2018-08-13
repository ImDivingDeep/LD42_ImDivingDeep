using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private static GameController s_Instance = null;
    private GameObject healthBar;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static GameController instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(GameController)) as GameController;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("GameController");
                s_Instance = obj.AddComponent(typeof(GameController)) as GameController;
                Debug.Log("Could not locate an AManager object. AManager was Generated Automaticly.");
            }

            return s_Instance;
        }
    }

    public GameObject _player;
    private Vector3 velocity = Vector3.zero;

    public int EnemyRangeOfSight;

    // Use this for initialization
    void Start () {

        healthBar = GameObject.FindGameObjectWithTag("HealthBar");

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.WorldToViewportPoint(_player.transform.position);

        if (pos.x < 0.3f) MoveCamera(new Vector2(-1, 0));
        else if (0.7f < pos.x) MoveCamera(new Vector2(1, 0));
        if (pos.y < 0.3f) MoveCamera(new Vector2(0, -1));
        else if (0.7f < pos.y) MoveCamera(new Vector2(0, 1));

    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }

    void MoveCamera(Vector2 dir)
    {
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, Camera.main.transform.position + new Vector3(dir.x * 3, dir.y * 3, 0.0f), ref velocity, 0.4f);
    }

    public void SetupCamera(GameObject player)
    {
        _player = player;
        Debug.Log(_player.name);
        Camera.main.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, Camera.main.transform.position.z);
    }

    public void UpdateHealthbar()
    {
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(_player.GetComponent<SheepController>().currentHealth * 5, healthBar.GetComponent<RectTransform>().sizeDelta.y);
        healthBar.transform.parent.Find("Text").GetComponent<Text>().text = _player.GetComponent<SheepController>().currentHealth + "/" + _player.GetComponent<SheepController>().maxHealth;
    }
}
