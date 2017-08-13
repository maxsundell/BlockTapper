using UnityEngine;

public class DifficultyManager
{

    static float secondsToMaxDifficulty = 60f;

    public static float getDifficultyPercent()
    {

        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);

    }
	
}
