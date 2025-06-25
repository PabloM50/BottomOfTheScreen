using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{

    //speed of a player
    [SerializeField] private float _speed;

    // Objests that we will find path to
    [SerializeField] private List<GameObject> _objects = new List<GameObject>();

    // To which object we are
    private GameObject _target;


    // object that moves to other object(Player)
    [SerializeField] private NavMeshAgent navMeshAgent;

    // waiting target position 
    [SerializeField] private Transform _waitingPosition;

    // just to make sure event is calld twice
    [SerializeField] private bool _isWaiting;

    



    void Start()
    {
        StartMovement();   
        ChangeSpeed(_speed);
    }
    
    #region Movement Function
    private void StartMovement() {
        _isWaiting = false;
        _target = ChooseObject();
        Vector3 _targetPosition = _target.transform.position;
        navMeshAgent.SetDestination(_targetPosition);
        Debug.Log("Started Movement");
    }


    private GameObject ChooseObject() {
        int len = _objects.Count;
        int randomIndex = Random.Range(0, len); // Select a random index
        Debug.Log(len);
        if(len == 0) {
            Debug.Log("NO MORE Trees");
            StartWaiting();
        }
        return _objects[randomIndex];
    }

    private void StartWaiting() {
        _isWaiting = true;
        Vector3 _targetPosition = _waitingPosition.position;
        navMeshAgent.SetDestination(_targetPosition);
    }
    #endregion

    #region Handling event
    private void OnEnable()
    {
        TrainingTree.OnTrainingEnd += HandleTrainingEnd;
        TrainingTree.OnTreeGrown += HandleTreeGrown;
    }

    private void OnDisable()
    {
        TrainingTree.OnTrainingEnd -= HandleTrainingEnd;
        TrainingTree.OnTreeGrown -= HandleTreeGrown;
    }


    #endregion



    private void HandleTrainingEnd(TrainingEndData trainingEndData) {
        GameObject _treeCollider = trainingEndData._treeColliderObject;
        _objects.Remove(_treeCollider);
        if(_objects.Count == 0) {
            StartWaiting();
        }
        else {
            StartMovement();
        }
        
        
    }

    private void HandleTreeGrown(TreeGrownData treeGrownData) {
        GameObject _treeCollider = treeGrownData._treeColliderObject;
        
        _objects.Add(_treeCollider);
        if(_isWaiting) {
            StartMovement();
        }
    }


    public bool ChangeSpeed(float newSpeed) {
        if(newSpeed < 0) {
            return false;
        }
        _speed = newSpeed;
        navMeshAgent.speed = newSpeed;
        return true;
    }
    
    

    



}
