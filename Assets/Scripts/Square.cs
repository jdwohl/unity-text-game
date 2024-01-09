using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Square(string name, int status, int desiredStatus, string correctEvidence, string explanation)
    {
        this.name = name;
        this.status = status;
        this.desiredStatus = desiredStatus;
        this.correctEvidence = correctEvidence;
        this.explanation = explanation;
    }
    public int status;
    public int desiredStatus;
    public string correctEvidence;
    public string explanation;
}
