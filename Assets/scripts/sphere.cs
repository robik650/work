using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class sphere : MonoBehaviour
{
     Rigidbody rb;
     public float y;
     public float x;
     public GameObject sphera;
     public Transform sphera1;
     public Vector3 check1;
     public Vector3 check2;
     public Vector3 check3;
     public Vector3 check4;
     public Transform startpos;
     public Transform currpos;
     public GameObject path;
     public int counttap;
     public Slider height, length;

    void Start()
    {    
         StartCoroutine(Check1());
         StartCoroutine(Check2());
         StartCoroutine(Check3());
         StartCoroutine(Check4());
         rb = GetComponent<Rigidbody>();
         startpos.transform.position =currpos.transform.position;
    }
    void OnMouseDown()
   {
       counttap++;
       StartCoroutine(Tap());
       if(check1==check2&&check3==check1&&check3==check2&&check4==check1&&check4==check2&&check4==check3){
       rb.AddForce(transform.up * y + transform.forward * x ,ForceMode.Impulse);
       StartCoroutine(Shooting());
       }
       else{
       Debug.Log("None");
       }
   }
    void Update()
   {
       sphera1.transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z);
       if(check1==check2&&check3==check1&&check3==check2&&check4==check1&&check4==check2&&check4==check3)
       startpos.transform.position =currpos.transform.position;
       else 
       StartCoroutine(Shooting());
       
       if(counttap==2){
       currpos.transform.position = startpos.transform.position;
       GetComponent<Rigidbody>().drag = 1000;
       StartCoroutine(Drag());
       }

       x=length.value;
       y=height.value;
   }
    IEnumerator Check1()
    {
       yield return new WaitForSeconds(0.11f);
        check1 = sphera.transform.position;
       StartCoroutine(Check1());
   }
   IEnumerator Check2(){
       yield return new WaitForSeconds(0.22f);
       check2 = sphera.transform.position;
       StartCoroutine(Check2());
   }
   IEnumerator Check3(){
       yield return new WaitForSeconds(0.33f);
       check3 = sphera.transform.position;
       StartCoroutine(Check3());
   }
   IEnumerator Check4(){
       yield return new WaitForSeconds(0.43f);
       check4 = sphera.transform.position;
       StartCoroutine(Check4());
   }
   IEnumerator Shooting(){
       yield return new WaitForSeconds(0.001f);
       Instantiate(path,sphera1.transform.position,transform.rotation);
      
       
    }
     IEnumerator Tap(){
       yield return new WaitForSeconds(0.2f);
       counttap=0;
    }
    IEnumerator Drag()
    {
        yield return new WaitForSeconds(0.3f);
      GetComponent<Rigidbody>().drag = 0.33F;
    }
}

