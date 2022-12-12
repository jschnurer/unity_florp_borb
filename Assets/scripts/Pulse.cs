using UnityEngine;

public class Pulse : MonoBehaviour
{
    // Grow parameters
    public float ApproachSpeed = 0.2f;
    public float GrowthBound = 2f;
    public float ShrinkBound = 0.5f;
    private float CurrentRatio = 1;

    // And something to do the manipulating
    private readonly bool _keepGoing = true;
    private bool _isGrowing = true;

    private void Update()
    {
        if (!_keepGoing)
        {
            return;
        }

        if (_isGrowing)
        {
            if (CurrentRatio < GrowthBound)
            {
                CurrentRatio = Mathf.MoveTowards(CurrentRatio, GrowthBound, ApproachSpeed * Time.deltaTime);
                transform.localScale = Vector3.one * CurrentRatio;
            }
            else
            {
                _isGrowing = false;
            }
        }
        else
        {
            if (CurrentRatio > ShrinkBound)
            {
                CurrentRatio = Mathf.MoveTowards(CurrentRatio, ShrinkBound, ApproachSpeed * Time.deltaTime);
                transform.localScale = Vector3.one * CurrentRatio;
            }
            else
            {
                _isGrowing = true;
            }
        }
    }
}
