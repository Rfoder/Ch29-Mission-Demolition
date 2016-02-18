using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	static public FollowCam S;

	public float 			easing = 0.05f;
	public Vector3		minXY;
	public bool _________________________;

	public GameObject 		poi;
	public float 			camZ;

	// Use this for initialization
	void Awake () {
		S = this;
		camZ = this.transform.position.z;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 destination;
		if (poi == null) 
		{
			destination = Vector3.zero;
		} else {
			destination = poi.transform.position;

			if (poi.tag == "Projectile") {
				if ( poi.rigidbody.IsSleeping() ) {
					poi = null;
					return;
				  }
				}
			}
			

		//Vector3 destination = poi.transform.position;

		// limit the x and y to min values
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);

		destination = Vector3.Lerp (transform.position, destination, easing);

		destination.z = camZ;

		transform.position = destination;

		this.camera.orthographicSize = destination.y + 10;
	}
}
