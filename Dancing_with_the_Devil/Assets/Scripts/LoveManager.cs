using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class LoveManager : MonoBehaviour
{
    [SerializeField] private float curLove = 60;
    [SerializeField] private float maxLove = 100;
    [SerializeField] private bool isGameOver;
    [SerializeField] private Slider loveMeter;

    private void Start()
    {
        loveMeter.value = curLove;
        loveMeter.maxValue = maxLove;
    }

    // Pass a float to increment the love meter. Use negative numbers to decrement.
    public void UpdateLove(float love)
    {
        // Updates health
        curLove += love;

        // Prevents health over maximum
        if (curLove > maxLove)
        {
            curLove = maxLove;
        } 

        // Sets dead if character dies
        else if (curLove <= 0)
        {
            curLove = 0;
            isGameOver = true;
        }

        // Action
        if (isGameOver)
        {
            // TODO: Cut to ending dialog? Cause some action? TBD
        }
    }

    // Returns the total love
    public double GetCurLove()
    {
        return curLove;
    }
}