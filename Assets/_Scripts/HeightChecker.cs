using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightChecker : MonoBehaviour
{
   [SerializeField] Rigidbody rbToTrack;
   [SerializeField] float YRange;

   public float oldY;
   public float currentY;

   public void Start()
   {
        oldY = rbToTrack.transform.position.y;
   }

   public void Update()
   {
        oldY = currentY;
        currentY = rbToTrack.transform.position.y;

        if(oldY + YRange < currentY)
        {
            Debug.LogWarning("RB exceeeded expected Y value range with value of: " + currentY.ToString()+ " at: " + rbToTrack.transform.position.ToString());
            GameObject marker = new();
            marker.name = "HeightInvalid";
            marker.transform.position = rbToTrack.transform.position;
            
        }

        
   }
}
