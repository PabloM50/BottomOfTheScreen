using UnityEngine;

public class TrainingTreeColider : MonoBehaviour
{
    [SerializeField] private TrainingTree trainingTree;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            trainingTree.Train();
        }
        Debug.Log("Entered");
        
    }
}
