using UnityEngine;
public class PictureInPicture : MonoBehaviour
{
    public enum hAlignment { left, center, right };
    public enum vAlignment { top, middle, bottom };
    public hAlignment horAlign = hAlignment.left;
    public vAlignment verAlign = vAlignment.top;
    public enum UnitsIn { pixels, screen_percentage };
    public UnitsIn unit = UnitsIn.pixels;
    public int width = 50;
    public int height = 50;
    public int xOffset = 0;
    public int yOffset = 0;
    public bool update = true;
    private int hsize, vsize, hloc, vloc;
    void Start()
    {
        AdjustCamera();
    }
    void Update()
    {
        if (update)
            AdjustCamera();
    }
    void AdjustCamera()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;
        float xOffPercent = xOffset * swPercent;
        float yOffPercent = yOffset * shPercent;
        int xOff;
        int yOff;
        if (unit == UnitsIn.screen_percentage)
        {
            hsize = width * (int)swPercent;
            vsize = height * (int)shPercent;
            xOff = (int)xOffPercent;
            yOff = (int)yOffPercent;
        }
        else
        {
            hsize = width;
            vsize = height;
            xOff = xOffset;
            yOff = yOffset;
        }
        switch (horAlign)
        {
            case hAlignment.left:
                hloc = xOff;
                break;
            case hAlignment.right:
                int justifiedRight = (sw - hsize);
                hloc = (justifiedRight - xOff);
                break;
            case hAlignment.center:
                float justifiedCenter = (sw * 0.5f) - (hsize * 0.5f);
                hloc = (int)(justifiedCenter - xOff);
                break;
        }
        switch (verAlign)
        {
            case vAlignment.top:
                int justifiedTop = sh - vsize;
                vloc = (justifiedTop - (yOff));
                break;
            case vAlignment.bottom:
                vloc = yOff;
                break;
            case vAlignment.middle:
                float justifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
                vloc = (int)(justifiedMiddle - yOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);
    }
}