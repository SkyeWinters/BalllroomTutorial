using UnityEngine;

public class LineRendererAnimator : MonoBehaviour
{
    [SerializeField] TrailRenderer line;

    public void Animation_ResetLine()
    {
        line.Clear();
    }
}
