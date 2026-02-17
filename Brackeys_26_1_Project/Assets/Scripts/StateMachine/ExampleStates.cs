using UnityEngine;

public class StateA : IState
{
    public void Awake(StateController _controller)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnter() { Debug.Log("Entered A"); }
    public void OnExit() { Debug.Log("Exited A"); }
    public void OnUpdate() { Debug.Log("Updating A"); }
    public void FixedUpdate()
    {

    }

    public string GetStateName()
    {
        return $"A";
    }
}

public class StateB : IState
{
    public void Awake(StateController _controller)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnter() { Debug.Log("Entered B"); }
    public void OnExit() { Debug.Log("Exited B"); }
    public void OnUpdate() { Debug.Log("Updating B"); }
    public void FixedUpdate()
    {

    }

    public string GetStateName()
    {
        return $"B";
    }
}
