using UnityEngine;
using System.Collections;
public class MovingShadows : MonoBehaviour
{
	public float windSpeedX;
 	public float windSpeedZ;
 	private float lightCookieSize;
 	private Vector3 initPos;
 	
	void Start()
 	{
 		initPos = transform.position;
 		lightCookieSize = GetComponent<Light>().cookieSize;
 	}
	void Update()
 	{
 		Vector3 pos = transform.position;
 		float xPos = Mathf.Abs(pos.x);
 		float zPos = Mathf.Abs(pos.z);
 		float xLimit = Mathf.Abs(initPos.x) + lightCookieSize;
 		float zLimit = Mathf.Abs(initPos.z) + lightCookieSize;
 		if (xPos >= xLimit)
 		pos.x = initPos.x;
 		if (zPos >= zLimit)
 		pos.z = initPos.z;
 		transform.position = pos;
 		float windX = Time.deltaTime * windSpeedX;
 		float windZ = Time.deltaTime * windSpeedZ;
 		transform.Translate(windX, 0, windZ, Space.World);
 	}
}
