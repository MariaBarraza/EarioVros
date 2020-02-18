namespace Platform2DUtils.GameplaySystem
{
    using UnityEngine;

    public class GameplaySystem
    {
        ///<summary>
        /// Returns a Vector2 with Horizontal and Vertical axes.
        ///</summary>
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs.
        ///</summary>
        ///<param name="t">Transform component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        public static void TMovement(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed);
        }
        
        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs and multiplied by delta time.
        ///</summary>
        ///<param name="t">Transform component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        public static void TMovementDelta(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        }

        ///<summary>
        /// Returns if jump button was buttondown.
        ///</summary>
        public static bool JumpBtn
        {
            get => Input.GetButtonDown("Jump");
        }

        
        public static void Jump(Rigidbody2D rb2D, float jumpForce)
        {
            //rb2D.AddRelativeForce (new Vector2 (0, jumpForce));
            //rb2D.AddForce(new Vector2(0, jumpForce));
             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
    }
}
