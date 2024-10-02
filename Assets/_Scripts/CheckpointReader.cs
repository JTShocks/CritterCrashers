using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CheckpointReader : MonoBehaviour
{

    TextMeshProUGUI checkpointText;
    public TextMeshProUGUI startLineText;
    // Start is called before the first frame update
    void OnEnable()
    {
        CheckpointManager.RacerCrossedStartingLine += CrossedStartingLine;
        CheckpointManager.RacerAdvanced += ChangeText;
    }
    void OnDisable()
    {
        CheckpointManager.RacerCrossedStartingLine -= CrossedStartingLine;
        CheckpointManager.RacerAdvanced -= ChangeText;
    }

    void Awake()
    {
        checkpointText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void ChangeText(Racer racer)
    {
        checkpointText.text = "Next checkpoint: " + racer.nextCheckpoint.name;
    }
    void CrossedStartingLine(Racer racer)
    {
        checkpointText.text = racer.name + " crossed the starting line.";
    }
}
