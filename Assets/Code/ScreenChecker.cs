using UnityEngine;

public static class ScreenChecker
{
    // ����������� ������ ������ ��� "�������/��"
    private static int desktopWidthThreshold = 1000;

    public static bool IsMobileScreen()
    {
        // ����� ��������� ������ ������, ���� ������������ Application.platform ��� ��������
        if (Application.isMobilePlatform || Screen.width < desktopWidthThreshold)
            return true;
        return false;
    }
}