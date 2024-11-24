namespace ExtractIconBorder;

public static class ImageProcessor
{
    public static Bitmap ProcessImage(Bitmap originalBitmap, int blackTolerance, int ignoreBorder)
    {
        var newWidth = originalBitmap.Width - ignoreBorder * 2;
        var newHeight = originalBitmap.Height - ignoreBorder * 2;

        var croppedBitmap = new Bitmap(newWidth, newHeight);

        using (var g = Graphics.FromImage(croppedBitmap))
        {
            g.DrawImage(originalBitmap, -ignoreBorder, -ignoreBorder);
        }

        var bounds = UpdateBlackToTransparent(croppedBitmap, blackTolerance);

        ClearMarkedArea(croppedBitmap, bounds);

        return new Bitmap(croppedBitmap, 36, 36);
    }

    private static (Point topLeft, Point bottomRight) UpdateBlackToTransparent(Bitmap bitmap, int blackTolerance)
    {
        List<Point> blackPoints = [];
        var originalBitmap = (Bitmap)bitmap.Clone();

        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                var pixelColor = bitmap.GetPixel(x, y);
                if (ImageHelper.IsNearBlack(pixelColor, blackTolerance))
                {
                    bitmap.SetPixel(x, y, Color.Transparent);
                    blackPoints.Add(new Point(x, y));
                }
            }
        }

        var left = -1;
        var right = -1;
        var top = -1;
        var bottom = -1;

        foreach (var point in blackPoints)
        {
            if (point.X == 0 || point.Y == 0 || point.X == bitmap.Width - 1 || point.Y == bitmap.Height - 1)
            {
                continue;
            }

            if (top == -1 || point.Y > top)
            {
                top = point.Y;
            }

            if (bottom == -1 || point.Y < bottom)
            {
                bottom = point.Y;
            }

            if (right == -1 || point.X > right)
            {
                right = point.X;
            }

            if (left == -1 || point.X < left)
            {
                left = point.X;
            }
        }
        
        // 比較 right 和 right-1 的黑色像素占比
        if (right > left + 1)
        {
            var rightRatio = CalculateAlphaRatio(bitmap, right);
            var rightMinusOneRatio = CalculateAlphaRatio(bitmap, right - 1);

            if (rightMinusOneRatio > rightRatio)
            {
                RestoreColumn(bitmap, originalBitmap, right); 
                right--;
            }
        }

        return (new Point(left, bottom), new Point(right, top));
    }

    private static void ClearMarkedArea(Bitmap bitmap, (Point topLeft, Point bottomRight) bounds)
    {
        var (topLeft, bottomRight) = bounds;

        if (topLeft.X != -1 && topLeft.Y != -1 && bottomRight.X != -1 && bottomRight.Y != -1)
        {
            for (var y = topLeft.Y; y <= bottomRight.Y; y++)
            {
                for (var x = topLeft.X; x <= bottomRight.X; x++)
                {
                    bitmap.SetPixel(x, y, Color.Transparent);
                }
            }
        }
    }
    
    private static double CalculateAlphaRatio(Bitmap bitmap, int column)
    {
        var blackPixelCount = 0;
        for (var y = 0; y < bitmap.Height; y++)
        {
            var pixelColor = bitmap.GetPixel(column, y);
            if (pixelColor.A == 0)
            {
                blackPixelCount++;
            }
        }

        return (double)blackPixelCount / bitmap.Height;
    }
    
    private static void RestoreColumn(Bitmap targetBitmap, Bitmap sourceBitmap, int column)
    {
        for (var y = 0; y < targetBitmap.Height; y++)
        {
            var originalColor = sourceBitmap.GetPixel(column, y);
            targetBitmap.SetPixel(column, y, originalColor);
        }
    }
    
}