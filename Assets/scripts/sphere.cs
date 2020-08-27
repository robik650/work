using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sphere : MonoBehaviour
{
    Rigidbody rb;
    public int y;
     public int x;
     public GameObject sphera;
     public Vector3 check1;
     public Vector3 check2;
     public Vector3 check3;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(Check1());
         StartCoroutine(Check2());
         StartCoroutine(Check3());
        rb = GetComponent<Rigidbody>();
    }
   void OnMouseDown()
   {
       if(check1==check2&&check3==check1&&check3==check2)
       rb.AddForce(transform.up * y + transform.forward * x ,ForceMode.Impulse);
       else
       Debug.Log("None");
   }
    IEnumerator Check1(){
       yield return new WaitForSeconds(0.2f);
        check1 = sphera.transform.position;
       StartCoroutine(Check1());
   }
   IEnumerator Check2(){
       yield return new WaitForSeconds(0.031f);
       check2 = sphera.transform.position;
       StartCoroutine(Check2());
   }
   IEnumerator Check3(){
       yield return new WaitForSeconds(0.42f);
       check3 = sphera.transform.position;
       StartCoroutine(Check3());
   }
}
