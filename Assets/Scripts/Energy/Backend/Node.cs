using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {

	public List<Pipe> pipes { get; set; }

	public float current {get; set;}

	public Node(float current) {
		pipes = new List<Pipe> ();
		this.current = current;
	}
}
