 using System.Collections;
 using UnityEngine;
 
 public class FirstBoss : Enemy2D
 {
     private float movementDuration = 1f;
     private float waitBeforeMoving = 1f;
     private bool hasArrived = false;

     private void Update()
     {
         if(!hasArrived)
         {
             hasArrived = true;
             float randX = Random.Range(-5.0f, 5.0f);
             float randY = Random.Range(-5.0f, 5.0f);
             StartCoroutine(MoveToPoint(new Vector2(randX, -randY)));
         }
     }

    /// <summary>
    /// Makes the object move in random directions.
    /// </summary>
    /// <param="targetPos">Vector2 con la posición a moverse<param>
     private IEnumerator MoveToPoint(Vector2 targetPos)
     {
         float timer = 0.0f;
         Vector2 startPos = transform.position;
 
         while (timer < movementDuration)
         {
             timer += Time.deltaTime;
             float t = timer / movementDuration;
             t = t * t * t * (t * (6f * t - 15f) + 10f);
             transform.position = Vector2.Lerp(startPos, targetPos, t);
 
             yield return null;
         }
 
         yield return new WaitForSeconds(waitBeforeMoving);
         hasArrived = false;
     }

     void OnTriggerEnter2D(Collider2D other)
     {
         KillPlayer(other);
     }
 }