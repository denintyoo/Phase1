using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumlahMati : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int _jumlah;
   public int Jumlah
    {
        set { _jumlah = value; text.text = $"x {_jumlah}"; }

        get { return _jumlah; } 

    }
    void Start()
    {
        Jumlah = 0;   
    }
}
