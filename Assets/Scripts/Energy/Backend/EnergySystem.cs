using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergySystem {

	List<Pipe> pipes;
	List<Node> nodes;

	public EnergySystem() {
		pipes = new List<Pipe> ();
		nodes = new List<Node> ();
	}

	public Node addNode(float current) {
		Node node = new Node (current);
		nodes.Add (node);
		return node;
	}

	public Pipe connect(Node from, Node to) {
		Pipe pipe = new Pipe (from, to);
		to.pipes.Add (pipe);
		from.pipes.Add (pipe);

		pipes.Add (pipe);

		return pipe;
	}

	public void updateFlow() {
		foreach (Node node in nodes) {
			spreadFlow (node);
		}

		foreach (Pipe pipe in pipes) {
			spreadFlow (pipe);
		}
	}

	private void spreadFlow(Node node) {
		foreach (Pipe pipe in node.pipes) {
			pipe.current += node.current / node.pipes.Count;
		}
		node.current = 0;
	}

	private void spreadFlow(Pipe pipe) {
		pipe.from.current += pipe.current / 2;
		pipe.to.current += pipe.current / 2;

		pipe.current = 0;
	}

}
