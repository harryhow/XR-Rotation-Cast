using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
    
    Vector3 center;
	public OSC oscReference;
    
    public float speed = 0.1f;


	// Use this for initialization
	void Start () {
	   center = transform.position;
	   oscReference.SetAllMessageHandler(OnReceive);
	}

	void OnReceive(OscMessage message){
		if ( message.address == "/helmet/Bob" ) {
			Debug.Log("received: [" + message.address + "]" + " messages");
			newPosition.x = Mathf.Cos( Time.frameCount * speed ) + center.x;

			//noisinessGameObject.transform.localScale = new Vector3(scaled,scaled,scaled);

		} else if ( message.address == "/helmet/Mary" ) {
			Debug.Log("received: [" + message.address + "]" + " messages");

			newPosition.y = Mathf.Sin( Time.frameCount * speed ) + center.y;

			//brightnessGameObject.GetComponent<Renderer>().material.color = c;

		}
	}

	Vector3 newPosition;
	// Update is called once per frame
	void Update () {
	  newPosition = transform.position;

//	   newPosition.x = Mathf.Cos( Time.frameCount * speed ) + center.x;
//       newPosition.y = Mathf.Sin( Time.frameCount * speed ) + center.y;
	   transform.position = newPosition;

	}
}
