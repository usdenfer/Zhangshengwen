using UnityEngine;
using System.Collections;

public class Refresh : MonoBehaviour {
    public UI_Control_ScrollFlow _ScrollFlow;
	// Use this for initialization
	void Start () {
        _ScrollFlow.Refresh();
	}	
}
