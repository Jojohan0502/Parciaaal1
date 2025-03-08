using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public TMP_Text rankingText; // Texto donde se mostrará el ranking

    void Start()
    {
        string allScores = PlayerPrefs.GetString("AllScores", ""); // Obtener todos los puntajes

        if (string.IsNullOrEmpty(allScores))
        {
            rankingText.text = "No hay registros aún.";
            return;
        }

        // Separar los puntajes en una lista
        List<(string, int)> rankingList = new List<(string, int)>();

        string[] scoreEntries = allScores.Split(';');
        foreach (string entry in scoreEntries)
        {
            if (string.IsNullOrEmpty(entry)) continue; // Ignorar cadenas vacías

            string[] parts = entry.Split(':');
            if (parts.Length == 2)
            {
                string playerName = parts[0];
                int playerScore = int.Parse(parts[1]);
                rankingList.Add((playerName, playerScore));
            }
        }

        // Ordenar de mayor a menor puntaje
        rankingList.Sort((a, b) => b.Item2.CompareTo(a.Item2));

        // Mostrar solo los primeros 10
        string rankingTextContent = " **Ranking** \n";
        for (int i = 0; i < rankingList.Count && i < 10; i++)
        {
            rankingTextContent += $"{i + 1}. {rankingList[i].Item1} - {rankingList[i].Item2} puntos\n";
        }

        rankingText.text = rankingTextContent;
    }
}
