using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopTextScript : MonoBehaviour
{
	
	// Update is called once per frame
	void Update () {
        var text = GetComponent<Text>();
        text.text = string.Format("Score: {0:0.##}", Time.timeSinceLevelLoad);
	}
}
