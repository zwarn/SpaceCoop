using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeScript : MonoBehaviour {

	public float initialEnergy;

	public Node nodeModel;
	public Gradient gradient;
	private TextMesh debugInfo;
	private SpriteRenderer renderer;

	public void setNodeModel(Node nodeModel) {
		this.nodeModel = nodeModel;
	}

	void Awake() {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Start() {
		
	}

	void Update() {
		this.renderer.color = gradient.Evaluate (nodeModel.current / 100);
	}

	public void setEnergy(float energy) {
		nodeModel.current = energy;
	}

}
