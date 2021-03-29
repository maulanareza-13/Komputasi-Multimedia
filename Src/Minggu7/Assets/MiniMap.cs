using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniMap : MonoBehaviour
{

   public Transform target;
   public GameObject marker;
   public GameObject mapGUI;
   public float height = 10.0f;
   public float distance = 10.0f;
   public bool rotate = true;
   private Vector3 camAngle;
   private Vector3 camPos;
   private Vector3 targetAngle;
   private Vector3 targetPos;
   private Camera cam;
   void Start(){
   cam = GetComponent<Camera> ();
   camAngle = transform.eulerAngles;
   targetAngle = target.transform.eulerAngles;
   camAngle.x = 90;
   camAngle.y = targetAngle.y;
   transform.eulerAngles = camAngle;
} 
   void Update(){
   targetPos = target.transform.position;
   camPos = targetPos;
   camPos.y += height;
   transform.position = camPos;
   cam.orthographicSize = distance;
   Vector3 compassAngle = new Vector3();
   compassAngle.z = target.transform.eulerAngles.y;
   if (rotate)
{
   mapGUI.transform.eulerAngles = compassAngle;
   marker.transform.eulerAngles = new Vector3();
}
   else
{
   marker.transform.eulerAngles = -compassAngle;
 }
 }
} 
