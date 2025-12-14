using UnityEngine;

public class AppleFarmAppleScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer appleMask;
    [SerializeField] float paintSpeed; 
    [SerializeField] Color paint;

    private void OnEnable()
    {
        appleMask.color = new Color(1, 1, 1, 0);
        paint = appleMask.color;

    }
    public void ApplePainting()
    {
        paint.a += paintSpeed * Time.deltaTime;
        appleMask.color = paint;
    }

}
