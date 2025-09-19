using UnityEngine;

public static class ScreenChecker
{
    // Минимальная ширина экрана для "планшет/ПК"
    private static int desktopWidthThreshold = 1000;

    public static bool IsMobileScreen()
    {
        // Можно проверять только ширину, либо использовать Application.platform для точности
        if (Application.isMobilePlatform || Screen.width < desktopWidthThreshold)
            return true;
        return false;
    }
}