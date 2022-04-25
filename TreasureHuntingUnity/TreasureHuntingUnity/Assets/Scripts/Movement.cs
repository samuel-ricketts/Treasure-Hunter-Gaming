using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
Rigidbody rb;
 public float speed;
 
 void Start () {
 rb = GetComponent<Rigidbody>();
 }
 void Update () {
 float mH = Input.GetAxis ("Horizontal");
 float mV = Input.GetAxis ("Vertical");
 rb.velocity = new Vector3 (mH * speed, mV * speed, 0);
 }


}
