using UnityEngine;
using System.Collections;
public class LaserAim : MonoBehaviour
{
 public float lineWidth = 0.2f;
 public Color regularColor = new Color(0.15f, 0, 0, 1);
 public Color firingColor = new Color(0.31f, 0, 0, 1);
 public Material lineMat;
 private Vector3 lineEnd;
 private Projector proj;
 private LineRenderer line;
 void Start()
 {
 line = gameObject.AddComponent<LineRenderer>();
 line.material = lineMat;
 line.material.SetColor("_TintColor", regularColor);
 line.SetVertexCount(2);
 line.SetWidth(lineWidth, lineWidth);
 proj = GetComponent<Projector>();
 }
 void Update()
 {
 RaycastHit hit;
 Vector3 fwd = transform.TransformDirection(Vector3.forward);
 if (Physics.Raycast(transform.position, fwd, out hit))
 {
 lineEnd = hit.point;
 float margin = 0.5f;
 proj.farClipPlane = hit.distance + margin;
 }
 else
 {
 lineEnd = transform.position + fwd * 10f;
 }
 line.SetPosition(0, transform.position);
 line.SetPosition(1, lineEnd);
 if (Input.GetButton("Fire1"))
 {
 float lerpSpeed = Mathf.Sin(Time.time * 10f);
 lerpSpeed = Mathf.Abs(lerpSpeed);
 Color lerpColor = Color.Lerp(regularColor,
 firingColor, lerpSpeed);
 line.material.SetColor("_TintColor", lerpColor);
 }
 if (Input.GetButtonUp("Fire1"))
 {
 line.material.SetColor("_TintColor", regularColor);
 }
 }
}