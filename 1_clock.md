# Clock Tutorial
https://catlikecoding.com/unity/tutorials/basics/game-objects-and-scripts/

Did a standard 3D project

using UnityEngine; // So you don't need UnityEngine.MonoBehaviour
public class Clock : MonoBehaviour // Lets us create components
{
    [SerializeField]               // So this becomes part of a scene's data
    Transform hoursPivot;

    void Awake() {} // special method for code that runs once
    void Update() {} // looping code
}

