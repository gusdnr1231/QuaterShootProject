using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI killCountText;

    private int killCount = 0;
    public int KillCount => killCount;

    void Start()
    {
        killCount = 0;
        killCountText.text = $"KILL : {killCount}";
    }
    
    public void PlusKillCount()
    {
        killCount++;
		killCountText.text = $"KILL : {killCount}";
	}
}
