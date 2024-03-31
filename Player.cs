using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public static int score;
	public static void Defeat()
	{
		score = 0;
	}
	public static List<Square> squares;
	void Awake()
	{
		squares = new List<Square>();
	}
	void Update()
	{
		if (squares.Count == 0)
		{
			Victory();
		}
	}

	public static void Defeat1()
	{
		UI.ShowDefeatPanel();
		score = 0;
	}

	public static void Victory()
	{
		UI.ShowVictoryPanel();
	}
	public static void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
