using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralaxing : MonoBehaviour {

    public Transform[] backgrounds; //array of thing to be parallax
    private float[] parralaxScales; //speed
    public float smoothingAmount = 1f;

    private Transform cam;
    private Vector3 previousCamPosition;

    void Awake ()
    {
        cam = Camera.main.transform;
    }

	// Use this for initialization
	void Start () {
        previousCamPosition = cam.position;

        parralaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parralaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * parralaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothingAmount * Time.deltaTime);
        }

        previousCamPosition = cam.position;
	}
}
