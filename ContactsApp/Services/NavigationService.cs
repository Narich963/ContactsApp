﻿using System.Windows;

namespace ContactsApp.Services;

public static class NavigationService
{
    private static readonly Stack<Window> NavigationStack = new Stack<Window>();
    static NavigationService()
    {
        NavigationStack.Push(Application.Current.MainWindow);
    }

    public static void NavigateTo(Window window)
    {
        if (NavigationStack.Count > 0)
            NavigationStack.Peek().Hide();

        NavigationStack.Push(window);
        window.Show();
    }
    public static bool NavigateBack()
    {
        if (NavigationStack.Count <= 1)
            return false;

        NavigationStack.Pop().Hide();
        NavigationStack.Peek().Show();
        return true;
    }
    public static bool CanNavigateBack()
    {
        return NavigationStack.Count > 1;
    }
}
