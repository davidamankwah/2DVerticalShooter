using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // This method is used to destroy the game object attached to this script.
  void DestroyGameObject()
  {
    // Call the Destroy() function provided by Unity to remove the game object.
    Destroy (gameObject);
  }
}
