using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergySystemScript : MonoBehaviour {

	private EnergySystem energySystem;

	private NodeScript[,] nodes = new NodeScript[4,3];
	public GameObject node;

	private float timer = 0;
	private float energyTimer = 0;

	// Use this for initialization
	void Start () {
		this.energySystem = new EnergySystem();

		initalizeNodes ();
		initalizeConnections ();

		nodes[0,0].setEnergy(100f);
	}

	private void initalizeNodes() {
		for (int x = 0; x < nodes.GetLength(0); x++) {
			for (int y = 0; y < nodes.GetLength(1); y++) {
				GameObject nodeObject = (GameObject)  GameObject.Instantiate (node, new Vector3 (x, y, 0), Quaternion.identity);
				nodes[x,y] = nodeObject.GetComponent<NodeScript> ();
				nodes[x,y].setNodeModel(energySystem.addNode (nodes[x,y].initialEnergy));
			}
		}
	}

	private void initalizeNode(NodeScript node) {
		node.setNodeModel(energySystem.addNode (node.initialEnergy));
	}

	private void initalizeConnections() {
		for (int x = 0; x < nodes.GetLength(0); x++) {
			for (int y = 0; y < nodes.GetLength(1); y++) {
				if (x + 1 < nodes.GetLength(0)) {
					initializeConnection (nodes[x,y], nodes[x+1,y]);
				}
				if (y + 1 < nodes.GetLength(1)) {
					initializeConnection (nodes[x,y], nodes[x,y+1]);
				}
			}
		}
	}

	private void initializeConnection(NodeScript from, NodeScript to) {
		if (to != null) {
			energySystem.connect (from.nodeModel, to.nodeModel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1) {
			energySystem.updateFlow ();
			timer -= 1;
			energyTimer++;
			if (energyTimer > 2) {
				nodes [0, 0].setEnergy (100);
				energyTimer = 0;
			}
		}
	}
}
