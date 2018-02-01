using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public bool IsLit = false;
	public bool isOnAtStart = false;

    private MeshRenderer lightMesh;

	// Use this for initialization
	void Start () {

        lightMesh = this.gameObject.GetComponentInChildren<MeshRenderer>();
        lightMesh.enabled = isOnAtStart;
        IsLit = isOnAtStart;
	}

    public void toggleLight()
    {
        IsLit = !IsLit;
        lightMesh.enabled = !lightMesh.enabled;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toggleLight();
        }
    }
}
