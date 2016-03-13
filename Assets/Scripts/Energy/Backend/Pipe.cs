using UnityEngine;
using System.Collections;

public class Pipe {

	public Node from { get; set;}
	public Node to { get; set;}

	public float current { get; set; }

	public Pipe(Node from, Node to) {
		this.from = from;
		this.to = to;
		current = 0;
	}

}
