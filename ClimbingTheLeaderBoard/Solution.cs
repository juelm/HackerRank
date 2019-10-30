using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

	// Complete the climbingLeaderboard function below.
	static int[] climbingLeaderboard(int[] scores, int[] alice)
	{
		int[] ranks = new int[alice.Length];
		//bool equalsPrior = false;
		//bool isGreatest = false;
		//bool isSmallest = false;
		int scoreIndex = 0;
		HashSet<int> ahead = new HashSet<int>();
		int target = 0;
		bool firstTime = true;

		for (int i = alice.Length - 1; i >= 0; i--)
		{
			target = alice[i];
			if (target > scores[0])
			{
				ranks[i] = 1;
				continue;
			}
			else if (target < scores[scores.Length - 1])
			{
				if (firstTime)
				{

					for (int q = scoreIndex; q < scores.Length; q++)
					{
						ahead.Add(scores[q]);

					}
					ranks[i] = ahead.Count() + 1;
					firstTime = false;
				}
				else
				{
					ranks[i] = ahead.Count() + 1;
				}
			}
			else
			{
				while (scoreIndex < scores.Length)
				{
					int currentScore = scores[scoreIndex];
					ahead.Add(currentScore);
					if (target == currentScore)
					{
						ranks[i] = ahead.Count();
						break;
					}
					else if (target > currentScore)
					{
						ranks[i] = ahead.Count();
						break;
					}
					else
					{
						scoreIndex++;
					}
				}

			}

		}
		return ranks;
	}

	static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int scoresCount = Convert.ToInt32(Console.ReadLine());

		int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
		;
		int aliceCount = Convert.ToInt32(Console.ReadLine());

		int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
		;
		int[] result = climbingLeaderboard(scores, alice);

		textWriter.WriteLine(string.Join("\n", result));

		textWriter.Flush();
		textWriter.Close();
	}
}
