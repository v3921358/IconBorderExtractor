namespace ExtractIconBorder;

public static class ImageHelper
{
    public static bool IsImageFile(string filePath)
    {
        string[] validExtensions = [".jpg", ".jpeg", ".png", ".bmp", ".gif"];
        var extension = Path.GetExtension(filePath).ToLower();
        return validExtensions.Contains(extension);
    }

    public static bool IsNearBlack(Color color, int tolerance)
    {
        return color.R <= tolerance && color.G <= tolerance && color.B <= tolerance;
    }
}