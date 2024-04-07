using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusmodel : MonoBehaviour
{
    public statusmodel(int status, string message)
    {
        this.status = status;
        this.message = message;
    }

    public int status { get; set; }
    public string message { get; set; }



}
