using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class HighlightCotroller : MonoBehaviour {

    protected Highlighter h;

	// Use this for initialization
	void Start () {
        h = GetComponent<Highlighter>();
	}
	
	// Update is called once per frame
	void Update () {
        h.ConstantOn(new Color(0, 0, 1));
	}
}
